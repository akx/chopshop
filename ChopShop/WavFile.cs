/*
 * Date: 18.4.2010
 * Time: 23:50
 */
using System;
using System.IO;
using System.Text;

namespace ChopShop
{
	/// <summary>
	/// Description of WavFile.
	/// </summary>
	public class WavFile
	{
		private int nChannels;
		private long nFrames;
		private int sampleWidth;
		private uint sampleRate;
		private int formatTag;
		private int frameSize;
		private long dataStart;
		private long dataEnd;
		private Stream stream;
		
		public int NChannels {
			get { return nChannels; }
		}
		
		public long NFrames {
			get { return nFrames; }
		}
		
		public int SampleWidth {
			get { return sampleWidth; }
		}
		
		public uint SampleRate {
			get { return sampleRate; }
		}
		
		public int FrameSize {
			get { return frameSize; }
		}
		
		public float Duration {
			get { return nFrames / (float)sampleRate / frameSize; }
		}
		
		
		public WavFile(Stream s)
		{
			if(s != null) {
				stream = s;
				ParseWav();
			}
		}
		
		public WavFile() {
			stream = null;
		}
		
		private string readASCII(BinaryReader br, int len) {
			return System.Text.Encoding.ASCII.GetString(br.ReadBytes(len));
		}
		
		private void ParseWav() {
			BinaryReader br = new BinaryReader(stream);
			
			string hdr = readASCII(br, 4);
			if(hdr != "RIFF") throw new Exception("Not a RIFF file, can't be a WAV. hdr = " + hdr);
			UInt32 fullLength = br.ReadUInt32();
			hdr = readASCII(br, 4);
			if(hdr != "WAVE") throw new Exception("First chunk in RIFF file not a WAVE, can't handle this");
			while(true) {
				string ident = readASCII(br, 4);
				UInt32 chunkLen = br.ReadUInt32();
				//System.Diagnostics.Debug.Print("Chunk: {0}, length {1}", ident, chunkLen);
				long pos = stream.Position;
				long end = pos + chunkLen;
				if(ident == "fmt ") {
					//#wFormatTag, self._nchannels, self._framerate, dwAvgBytesPerSec, wBlockAlign = struct.unpack('<hhllh', chunk.read(14))
					formatTag = br.ReadUInt16(); // 2
					if(formatTag != 1) throw new Exception("Not PCM");
					nChannels = br.ReadUInt16(); // 2
					sampleRate = br.ReadUInt32(); // 4
					uint avgbps = br.ReadUInt32(); // dwavgbps // 4
					int blockalign = br.ReadUInt16(); // blockal // 2
					
					sampleWidth = br.ReadUInt16();
					frameSize = sampleWidth / 8; // Bits to bytes
					//System.Diagnostics.Debug.Print("avgbps: {0}, ba {1}", avgbps, blockalign);
				} else if(ident == "data") {
					nFrames = chunkLen / frameSize;
					dataStart = pos;
					dataEnd = end;
					break;
				} else {
					throw new Exception("Unhandleable chunk \"" + ident + "\" (position " + (stream.Position - 8) + ")");
				}
				stream.Seek(end, SeekOrigin.Begin);
			}
		}
		
		public void Rewind() {
			if(stream != null) stream.Seek(dataStart, SeekOrigin.Begin);
		}
		
		public void SetFormat(int nChannels, int sampleWidth, uint sampleRate) {
			formatTag = 1;
			this.nChannels = nChannels;
			this.sampleWidth = sampleWidth;
			this.sampleRate = sampleRate;
			frameSize = sampleWidth / 8;
		}
		
		public byte[] ReadRaw(uint nSamples) {
			BinaryReader br = new BinaryReader(stream);
			
			byte[] rawSamples = br.ReadBytes((int)(nSamples * frameSize * nChannels));
			return rawSamples;
			//int[] samples = new int[nSamples];
			//Buffer.BlockCopy(rawSamples, 0, samples, 0, rawSamples.Length);
			//return samples;
		}
		
		public void Write(Stream s, byte[] data) {
			BinaryWriter bw = new BinaryWriter(s, Encoding.ASCII);
			// Riff chunk will be 8(4:WAVE+4:LLLL) + 8(4:FMT +4:LLLL) + 16 (format chunk) + 8(4:data+4:LLLL) + data.length long
			// ie. 8+8+16+8+L = 40 + L
			bw.Write("RIFF".ToCharArray());
			bw.Write((UInt32)(40 + data.Length));
			bw.Write("WAVE".ToCharArray());
			bw.Write("fmt ".ToCharArray());
			bw.Write((UInt32)(16));
			bw.Write((UInt16)0x0001); // Format tag
			bw.Write((UInt16)nChannels); // channels
			bw.Write((UInt32)sampleRate); // srate
			bw.Write((UInt32)(nChannels*sampleRate*frameSize)); // data rate
			bw.Write((UInt16)(nChannels*frameSize)); // block align
			bw.Write((UInt16)sampleWidth); // bits per sample
			bw.Write("data".ToCharArray());
			bw.Write((UInt32)(data.Length));
			bw.Write(data);
			
		}
	}
}
