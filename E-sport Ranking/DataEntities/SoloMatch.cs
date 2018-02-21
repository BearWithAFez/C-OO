using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities
{
    public class SoloMatch : MatchType, IEquatable<SoloMatch>
    {
        public List<PlayerType> Players { get; set; }

        public List<int> Scores { get; set; }

        public static bool operator ==(SoloMatch a, SoloMatch b)
        {
            return  (b.Scores.SequenceEqual(a.Scores)&&a.Players.SequenceEqual(b.Players));
        }

        public static bool operator !=(SoloMatch a, SoloMatch b)
        {
            return !(a == b);
        }

        public bool Equals(SoloMatch other)
        {
            return (this == other);
        }

        public override bool Equals(object other)
        {
            if (!(other is SoloMatch))
            {
                return false;
            }
            else
            {
                return (this.Equals((SoloMatch)other));
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()} - {this.Players.ToString()} - {this.Scores.ToString()}";
        }
    }
}