using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveFun
{
    public class WaveHeader
    {
        public string sGroupID = "RIFF";
        public uint dwFileLength = 0;
        public string sRiffType = "WAVE";
    }

    public class WaveFormatChunk
    {
        public string sChunkID = "fmt ";
        public uint dwChunkSize = 16; 
        public ushort wFormatTag = 1;
        public ushort wChannels = 2;
        public uint dwSamplesPerSec = 44100;
        public uint dwAvgBytesPerSec = 176400;           // dwSamplesPerSec * wBlockAlign
        public ushort wBlockAlign = (ushort) 4;         // (Channels * (BitsPerSample / 8))
        public ushort wBitsPerSample = 16;
    }

    public class WaveDataChunk
    {
        public string sChunkID = "data";
        public uint dwChunkSize = 0;
        public short[] shortArray = new short[0];
    }

    public class fileData
    {
        //header
        public string sGroupID = "RIFF";
        public uint dwFileLength = 0;
        public string sRiffType = "WAVE";

        //Format
        public string sChunkID = "fmt ";
        public uint dwChunkSize = 16;
        public ushort wFormatTag = 1;
        public ushort wChannels = 2;
        public uint dwSamplesPerSec = 44100;
        public uint dwAvgBytesPerSec = 176400;           // dwSamplesPerSec * wBlockAlign
        public ushort wBlockAlign = (ushort)4;         // (Channels * (BitsPerSample / 8))
        public ushort wBitsPerSample = 16;

        //data
        public string sChunkID2 = "data";
        public uint dwChunkSize2 = 0;
        public short[] shortArray = new short[0];
    }
}
