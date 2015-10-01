/*
 * Date: 18.4.2010
 * Time: 23:37
 */
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using System.Threading;

namespace ChopShop
{
	public partial class MainForm : Form
	{
		FileStream inputFileStream;
		WavFile inputWavFile;
		public MainForm()
		{
			InitializeComponent();
			ValidateInputFile();
			UpdateSliceBoxes();
		}
		
		
		void InputBrowseBtnClick(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.CheckFileExists = true;
			ofd.DefaultExt = ".wav";
			ofd.Filter = "WAV files|*.wav";
			if(ofd.ShowDialog() == DialogResult.OK) {
				inputFileBox.Text = ofd.FileName;
				ValidateInputFile();
			}
		}
		
		void ValidateInputFile() {
			if(inputFileStream != null) {
				inputFileStream.Close();
				inputWavFile = null;
			}
			FileStream fs = null;
			WavFile wf;
			try {
				fs = new FileStream(inputFileBox.Text, FileMode.Open, FileAccess.Read, FileShare.Read);
				wf = new WavFile(fs);
			} catch(Exception e) {
				infoLabel.ForeColor = Color.Maroon;
				infoLabel.Text = "Nope, not a valid file:\n" + e.Message;
				if(fs != null) fs.Close();
				return;
			}
			infoLabel.ForeColor = SystemColors.ControlText;
			inputFileStream = fs;
			inputWavFile = wf;
			infoLabel.Text = String.Format("Sample Rate: {0}\nSample Resolution: {1} bits\nChannels: {2}\nDuration: {3}", wf.SampleRate, wf.SampleWidth, wf.NChannels, TimeSpan.FromSeconds(wf.Duration));
			durationBox.Maximum = (decimal)wf.Duration;
			ValidateSettings();
		}
		
		bool ValidateSettings() {
			bool isValid = true;
			if(inputWavFile == null) {
				statLbl.Text = "Protip: Choose input file.";
				isValid = false;
			} else if(outputDirBox.Text.Length == 0 || !(new DirectoryInfo(outputDirBox.Text).Exists)) {
				statLbl.Text = "Protip: Choose output directory.";
				isValid = false;
			} else if(!durationRadio.Checked && !slicesRadio.Checked) {
				statLbl.Text = "Protip: Choose an output method.";
				isValid = false;
			} else if(durationRadio.Checked && durationBox.Value == 0) {
				statLbl.Text = "A little longer slices would be nicer.";
				isValid = false;
			} else if(durationRadio.Checked && durationBox.Value >= (decimal)inputWavFile.Duration) {
				statLbl.Text = "That'll give you exactly one slice. No go.";
				isValid = false;
			} else if(slicesRadio.Checked && slicesBox.Value <= 1) {
				statLbl.Text = "Gonna need more slices than that.";
				isValid = false;
			}
			if(isValid) statLbl.Text = "All good, man.";
			chopButton.Enabled = isValid;
			UpdateSliceBoxes();
			return isValid;
		}
		
		void sliceTypeChanged(object sender, EventArgs e)
		{
			ValidateSettings();
		}
		
		void UpdateSliceBoxes() {
			if(inputWavFile != null) {
				decimal dur = (decimal)inputWavFile.Duration;
				if(durationRadio.Checked) {
					slicesBox.Value = Math.Ceiling((decimal)(durationBox.Value > 0 ? Math.Ceiling(dur / durationBox.Value) : 1));
				} else {
					durationBox.Value = (decimal)(dur / slicesBox.Value);
				}
			}
			slicesBox.Enabled = slicesRadio.Checked;
			durationBox.Enabled = durationRadio.Checked;
			
		}
		
		void SliceBoxesValueChanged(object sender, EventArgs e)
		{
			ValidateSettings();
		}
		
		void ChopButtonClick(object sender, EventArgs e)
		{
			if(!ValidateSettings()) return;
			chopButton.Enabled = false;
			BackgroundWorker bw = new BackgroundWorker();
			bw.DoWork += _DoSlicing;
			bw.WorkerReportsProgress = true;
			int pbw = pictureBox1.ClientSize.Width;
			int pbh = pictureBox1.ClientSize.Height;
			Bitmap b = new Bitmap(pbw, pbh, PixelFormat.Format32bppRgb);
			pictureBox1.Image = b;
			Graphics g = Graphics.FromImage(b);
			
			bw.ProgressChanged += delegate(object wsender, ProgressChangedEventArgs pce) { 
				progressBar.Value = pce.ProgressPercentage;
				if(pce.UserState != null) {
					object[] o = pce.UserState as object[];
					string s = o[0] as string;
					byte[] sb = o[1] as byte[];
					if(s != null) statLbl.Text = s + " ...";
					if(sb != null) {
						g.FillRectangle(new SolidBrush(Color.FromArgb(64,0,0,0)), new RectangleF(0, 0, pbw, pbh));
						for(int x=0;x<Math.Min(pbw, sb.Length);x++) {
							
							g.DrawLine(new Pen(Utils.HsvToRgb(pce.ProgressPercentage * 3.6, 1, 1)), x, pbh, x, pbh - ((float)sb[x]) / 255.0f * (float)pbh);
						}
						pictureBox1.Image = b;
					}
				}
			};
			bw.RunWorkerCompleted += delegate(object wsender, RunWorkerCompletedEventArgs rwce) { 
				ValidateSettings();
				statLbl.Text = "All done, baby.";
			};
			bw.RunWorkerAsync();
			
		}

		void _DoSlicing(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker w = sender as BackgroundWorker;
			inputWavFile.Rewind();
			uint samplesPerSlice = 0;
			
			if(durationRadio.Checked) {
				samplesPerSlice = (uint)(durationBox.Value * (decimal)inputWavFile.SampleRate);
			} else {
				samplesPerSlice = (uint)(((decimal)inputWavFile.Duration / slicesBox.Value) * inputWavFile.SampleRate);
			}
			System.Diagnostics.Debug.Print("Samples per slice: {0}", samplesPerSlice);
			System.Diagnostics.Debug.Print("nFrames: {0}", inputWavFile.NFrames);
			int n = (int)Math.Ceiling(inputWavFile.NFrames / inputWavFile.NChannels / (float)samplesPerSlice);
			byte[] iSlice = new byte[pictureBox1.ClientRectangle.Width];
			for(int i=0;i<n;i++) {
				string fileBaseName = String.Format("{0}_{1:D4}.wav", System.IO.Path.GetFileNameWithoutExtension(inputFileStream.Name), i+1);
				string fileName = System.IO.Path.Combine(outputDirBox.Text, fileBaseName);
				System.Diagnostics.Debug.Print("Debug: {0} {1}", fileName, i);
				object[] derp = {fileBaseName, iSlice};
				w.ReportProgress((int)(i / (float)(n-1) * 100), derp);
				using(FileStream ofs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write)) {
					WavFile owf = new WavFile();
					owf.SetFormat(inputWavFile.NChannels, inputWavFile.SampleWidth, inputWavFile.SampleRate);
					byte[] data = inputWavFile.ReadRaw(samplesPerSlice);
					Array.Copy(data, iSlice, iSlice.Length);
					owf.Write(ofs, data);
				}
				Thread.Sleep((n<100?40:15));
				
			}
		}
		
		void OutputDirBrowseBtnClick(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			fbd.ShowNewFolderButton = true;
			fbd.SelectedPath = System.IO.Path.GetDirectoryName(inputFileBox.Text);
			if(fbd.ShowDialog() == DialogResult.OK) {
				outputDirBox.Text = fbd.SelectedPath;
			}
			ValidateSettings();
		}
		
		void FigureOutPathButtonClick(object sender, EventArgs e)
		{
			FileInfo fi;
			try {
				fi = new FileInfo(inputFileBox.Text);
				if(!fi.Exists) throw new Exception("File doesn't exist.");
			} catch(Exception exc) {
				MessageBox.Show("Can't do much with a file like that! (Error: " + exc.Message + ")");
				return;
			}
			
			string baseDir = Path.GetDirectoryName(inputFileBox.Text);
			string baseName = Path.GetFileNameWithoutExtension(inputFileBox.Text);
			string newDir = Path.Combine(baseDir, baseName + "_chopped");
			DirectoryInfo di = new DirectoryInfo(newDir);
			try {
				if(!di.Exists) {
					di.Create();
					statLbl.Text = "Directory created.";
				}
			} catch(Exception exc) {
				MessageBox.Show("Couldn't create the directory, sorry: " + exc.Message);
				return;
			}
			outputDirBox.Text = di.FullName;
			ValidateSettings();
		}
	}
}
