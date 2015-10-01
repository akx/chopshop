/*
 * Date: 18.4.2010
 * Time: 23:37
 */
namespace ChopShop
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.outputDirBrowseBtn = new System.Windows.Forms.Button();
			this.figureOutPathButton = new System.Windows.Forms.Button();
			this.inputBrowseBtn = new System.Windows.Forms.Button();
			this.outputDirBox = new System.Windows.Forms.TextBox();
			this.inputFileBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.infoLabel = new System.Windows.Forms.Label();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.statLbl = new System.Windows.Forms.ToolStripStatusLabel();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.chopButton = new System.Windows.Forms.Button();
			this.slicesBox = new System.Windows.Forms.NumericUpDown();
			this.durationBox = new System.Windows.Forms.NumericUpDown();
			this.slicesRadio = new System.Windows.Forms.RadioButton();
			this.durationRadio = new System.Windows.Forms.RadioButton();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.slicesBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.durationBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.outputDirBrowseBtn);
			this.groupBox1.Controls.Add(this.figureOutPathButton);
			this.groupBox1.Controls.Add(this.inputBrowseBtn);
			this.groupBox1.Controls.Add(this.outputDirBox);
			this.groupBox1.Controls.Add(this.inputFileBox);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(708, 113);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Files";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(7, 63);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Output Directory";
			// 
			// outputDirBrowseBtn
			// 
			this.outputDirBrowseBtn.Location = new System.Drawing.Point(668, 83);
			this.outputDirBrowseBtn.Name = "outputDirBrowseBtn";
			this.outputDirBrowseBtn.Size = new System.Drawing.Size(34, 23);
			this.outputDirBrowseBtn.TabIndex = 2;
			this.outputDirBrowseBtn.Text = "...";
			this.outputDirBrowseBtn.UseVisualStyleBackColor = true;
			this.outputDirBrowseBtn.Click += new System.EventHandler(this.OutputDirBrowseBtnClick);
			// 
			// figureOutPathButton
			// 
			this.figureOutPathButton.Location = new System.Drawing.Point(668, 60);
			this.figureOutPathButton.Name = "figureOutPathButton";
			this.figureOutPathButton.Size = new System.Drawing.Size(34, 22);
			this.figureOutPathButton.TabIndex = 2;
			this.figureOutPathButton.Text = "▼";
			this.figureOutPathButton.UseVisualStyleBackColor = true;
			this.figureOutPathButton.Click += new System.EventHandler(this.FigureOutPathButtonClick);
			// 
			// inputBrowseBtn
			// 
			this.inputBrowseBtn.Location = new System.Drawing.Point(668, 37);
			this.inputBrowseBtn.Name = "inputBrowseBtn";
			this.inputBrowseBtn.Size = new System.Drawing.Size(34, 22);
			this.inputBrowseBtn.TabIndex = 2;
			this.inputBrowseBtn.Text = "...";
			this.inputBrowseBtn.UseVisualStyleBackColor = true;
			this.inputBrowseBtn.Click += new System.EventHandler(this.InputBrowseBtnClick);
			// 
			// outputDirBox
			// 
			this.outputDirBox.Location = new System.Drawing.Point(7, 83);
			this.outputDirBox.Name = "outputDirBox";
			this.outputDirBox.Size = new System.Drawing.Size(655, 22);
			this.outputDirBox.TabIndex = 2;
			// 
			// inputFileBox
			// 
			this.inputFileBox.Location = new System.Drawing.Point(7, 37);
			this.inputFileBox.Name = "inputFileBox";
			this.inputFileBox.Size = new System.Drawing.Size(655, 22);
			this.inputFileBox.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Input WAV";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.infoLabel);
			this.groupBox2.Location = new System.Drawing.Point(12, 132);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(198, 128);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Information";
			// 
			// infoLabel
			// 
			this.infoLabel.Location = new System.Drawing.Point(7, 20);
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Size = new System.Drawing.Size(169, 97);
			this.infoLabel.TabIndex = 0;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.progressBar,
									this.statLbl});
			this.statusStrip1.Location = new System.Drawing.Point(0, 278);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(732, 22);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// progressBar
			// 
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(100, 16);
			this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			// 
			// statLbl
			// 
			this.statLbl.Name = "statLbl";
			this.statLbl.Size = new System.Drawing.Size(37, 17);
			this.statLbl.Text = "Soup.";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.chopButton);
			this.groupBox3.Controls.Add(this.slicesBox);
			this.groupBox3.Controls.Add(this.durationBox);
			this.groupBox3.Controls.Add(this.slicesRadio);
			this.groupBox3.Controls.Add(this.durationRadio);
			this.groupBox3.Location = new System.Drawing.Point(519, 132);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(201, 128);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Slicing";
			// 
			// chopButton
			// 
			this.chopButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chopButton.Location = new System.Drawing.Point(7, 78);
			this.chopButton.Name = "chopButton";
			this.chopButton.Size = new System.Drawing.Size(188, 39);
			this.chopButton.TabIndex = 3;
			this.chopButton.Text = "Chop it up, baby";
			this.chopButton.UseVisualStyleBackColor = true;
			this.chopButton.Click += new System.EventHandler(this.ChopButtonClick);
			// 
			// slicesBox
			// 
			this.slicesBox.Location = new System.Drawing.Point(116, 50);
			this.slicesBox.Maximum = new decimal(new int[] {
									1000,
									0,
									0,
									0});
			this.slicesBox.Minimum = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.slicesBox.Name = "slicesBox";
			this.slicesBox.Size = new System.Drawing.Size(79, 22);
			this.slicesBox.TabIndex = 2;
			this.slicesBox.Value = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.slicesBox.ValueChanged += new System.EventHandler(this.SliceBoxesValueChanged);
			// 
			// durationBox
			// 
			this.durationBox.DecimalPlaces = 3;
			this.durationBox.Location = new System.Drawing.Point(116, 20);
			this.durationBox.Maximum = new decimal(new int[] {
									10000,
									0,
									0,
									0});
			this.durationBox.Name = "durationBox";
			this.durationBox.Size = new System.Drawing.Size(79, 22);
			this.durationBox.TabIndex = 1;
			this.durationBox.ValueChanged += new System.EventHandler(this.SliceBoxesValueChanged);
			// 
			// slicesRadio
			// 
			this.slicesRadio.Location = new System.Drawing.Point(7, 50);
			this.slicesRadio.Name = "slicesRadio";
			this.slicesRadio.Size = new System.Drawing.Size(79, 24);
			this.slicesRadio.TabIndex = 0;
			this.slicesRadio.TabStop = true;
			this.slicesRadio.Text = "Slices:";
			this.slicesRadio.UseVisualStyleBackColor = true;
			this.slicesRadio.CheckedChanged += new System.EventHandler(this.sliceTypeChanged);
			// 
			// durationRadio
			// 
			this.durationRadio.Location = new System.Drawing.Point(7, 20);
			this.durationRadio.Name = "durationRadio";
			this.durationRadio.Size = new System.Drawing.Size(103, 24);
			this.durationRadio.TabIndex = 0;
			this.durationRadio.TabStop = true;
			this.durationRadio.Text = "Duration (s):";
			this.durationRadio.UseVisualStyleBackColor = true;
			this.durationRadio.CheckedChanged += new System.EventHandler(this.sliceTypeChanged);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Black;
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureBox1.Location = new System.Drawing.Point(217, 132);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(296, 128);
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(732, 300);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "ChopShop";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.slicesBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.durationBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button figureOutPathButton;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ToolStripProgressBar progressBar;
		private System.Windows.Forms.ToolStripStatusLabel statLbl;
		private System.Windows.Forms.Button chopButton;
		private System.Windows.Forms.NumericUpDown durationBox;
		private System.Windows.Forms.NumericUpDown slicesBox;
		private System.Windows.Forms.Button outputDirBrowseBtn;
		private System.Windows.Forms.Button inputBrowseBtn;
		private System.Windows.Forms.TextBox outputDirBox;
		private System.Windows.Forms.TextBox inputFileBox;
		private System.Windows.Forms.RadioButton slicesRadio;
		private System.Windows.Forms.RadioButton durationRadio;
		private System.Windows.Forms.Label infoLabel;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
