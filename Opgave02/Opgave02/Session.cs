using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave02
{
    public class Session
    {
        public Session(string name, int maxParticipants)
        {
            this.Name = name;
            this.MaxParticipants = maxParticipants;
        }
        public int MaxParticipants { get; }
        public string Name { get; }
    }
}
