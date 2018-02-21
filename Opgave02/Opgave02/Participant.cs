using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave02
{
    public class Participant
    {
        public Participant(string name, List<int> preferences)
        {
            this.Name = name;
            this.Preferences = preferences;
        }
        public string Name { get; }
        public List<int> Preferences { get; }
    }
}
