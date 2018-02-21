using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WaveFun
{
    public class WaveGenerator
    {
        // Header, Format, Data chunks
        WaveHeader header;
        WaveFormatChunk format;
        WaveDataChunk data;

        public WaveGenerator(IEnumerable<Note> notes)
        {
            // Init chunks (basis waarden)
            header = new WaveHeader();
            format = new WaveFormatChunk();
            data = new WaveDataChunk();

            //totale tijdsduur
            uint milliseconds = 0;
            foreach (Note n in notes)
            {
                milliseconds += Convert.ToUInt32(n.Duration.TotalMilliseconds);
            }


            // aantal samples = samples per sec * aantal sec * channels 
            // maal mili sec en DAN delen door 1000 voor afrondings fouten
            uint numSamples = (uint)(((format.dwSamplesPerSec * milliseconds) / 1000) * format.wChannels);

            // Initialize the 16-bit array (waarden van sinus)
            data.shortArray = new short[numSamples];

            // Max amplitude for 16-bit audio
            int amplitude = 32760;  

            

            //Hoever je al zit in je Wav file
            uint sampleCount = 0;

            //pernoot
            foreach (var n in notes)
            {
                // The "angle" used in the function, adjusted for the number of channels and sample rate.
                // This value is like the period of the wave.
                double t = (Math.PI * 2 * n.Frequency) / (format.dwSamplesPerSec * format.wChannels);

                //aantal samples voor DEZE noot (samples per sec * kanalen * sec)
                var samplesThisNote = format.dwSamplesPerSec * format.wChannels * n.Duration.TotalSeconds;

                // START op juiste plaats WAV (cursor sampleCOunt)
                // Zolag je nog niet elke sample voor deze noot gedaan hebt (-1 wegens anders 1 te ver)
                // the sine wave for repeated notes of the same pitch
                for (uint i = sampleCount; i < (samplesThisNote + sampleCount) - 1; i++)
                {
                    // per kanaal (Links/rechts)
                    for (int channel = 0; channel < format.wChannels; channel++)
                    {
                        data.shortArray[i + channel] = Convert.ToInt16(amplitude * Math.Sin(t * i));
                    }
                }
                sampleCount += (uint)samplesThisNote;
            }
            // Calculate data chunk size in bytes
            data.dwChunkSize = (uint)(data.shortArray.Length * (format.wBitsPerSample / 8));

        }


        /// <summary>
        /// Saves the current wave data to the specified file.
        /// </summary>
        /// <param name="filePath"></param>
        public void Save(string filePath)
        {
            // Create a file (it always overwrites)
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                Save(fileStream);
            }
        }

        public void Save(Stream stream)
        {
            // Use BinaryWriter to write the bytes to the file
            using (var writer = new SafeBinaryWriter(stream))
            {
                // Write the header
                writer.Write(header.sGroupID.ToCharArray());
                writer.Write(header.dwFileLength);
                writer.Write(header.sRiffType.ToCharArray());

                // Write the format chunk
                writer.Write(format.sChunkID.ToCharArray());
                writer.Write(format.dwChunkSize);
                writer.Write(format.wFormatTag);
                writer.Write(format.wChannels);
                writer.Write(format.dwSamplesPerSec);
                writer.Write(format.dwAvgBytesPerSec);
                writer.Write(format.wBlockAlign);
                writer.Write(format.wBitsPerSample);

                // Write the data chunk
                writer.Write(data.sChunkID.ToCharArray());
                writer.Write(data.dwChunkSize);
                foreach (short dataPoint in data.shortArray)
                {
                    writer.Write(dataPoint);
                }

                writer.Seek(4, SeekOrigin.Begin);
                uint filesize = (uint)writer.BaseStream.Length;
                writer.Write(filesize - 8);

            }
        }
    }
}
