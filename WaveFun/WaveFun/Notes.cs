using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveFun
{
    public class Note
    {
        public float Frequency { get; set; }
        public TimeSpan Duration { get; set; }

        public Note(float _Frequency, TimeSpan _Duration)
        {
            Duration = _Duration;
            Frequency = _Frequency;
        }
    }

    public static class Pitches
    {
        public const float E3 = 164.81f;
        public const float G3 = 196.0f;
        public const float A3 = 220.0f;
        public const float Bb3 = 233.08f;
        public const float B3 = 246.94f;
        public const float C4 = 261.63f;
        public const float Db4 = 277.18f;
        public const float D4 = 293.67f;
        public const float Eb4 = 311.13f;
        public const float E4 = 329.63f;
        public const float F4 = 349.23f;
        public const float Gb4 = 369.99f;
        public const float G4 = 392.0f;
        public const float Ab4 = 415.30f;
        public const float A4 = 440.0f;
        public const float Bb4 = 466.16f;
        public const float B4 = 493.88f;
        public const float C5 = 523.25f;
    }

    public static class examples
    {
        public const float A = 100.0f;
        public const float B = 150.0f;
        public const float C = 200.0f;
        public const float D = 250.0f;
        public const float E = 300.0f;
        public const float F = 350.0f;
        public const float G = 400.0f;
        public const float H = 450.0f;
        public const float _ = 0.0f;
    }

}
