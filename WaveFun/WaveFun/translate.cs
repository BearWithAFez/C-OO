using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveFun
{
    public class translate
    {
        public List<Note> noten;
        public translate(string s)
        {
            noten = new List<Note>();
            s = s.ToUpper();
            Note n = new Note(0.0f, new TimeSpan(0, 0, 0, 0, 200));

            foreach (Char c in s)
            {
                n = new Note(0.0f, new TimeSpan(0, 0, 0, 0, 200));
                switch (c)
                {
                    case 'A':
                        n.Frequency = examples.A;
                        noten.Add(n);
                        break;

                    case 'B':
                        n.Frequency = examples.B;
                        noten.Add(n);
                        break;

                    case 'C':
                        n.Frequency = examples.C;
                        noten.Add(n);
                        break;

                    case 'D':
                        n.Frequency = examples.D;
                        noten.Add(n);
                        break;

                    case 'E':
                        n.Frequency = examples.E;
                        noten.Add(n);
                        break;

                    case 'F':
                        n.Frequency = examples.F;
                        noten.Add(n);
                        break;

                    case 'G':
                        n.Frequency = examples.G;
                        noten.Add(n);
                        break;

                    case 'H':
                        n.Frequency = examples.H;
                        noten.Add(n);
                        break;

                    default:
                        n.Frequency = examples._;
                        noten.Add(n);
                        break;
                }
            }
        }
    }
}
