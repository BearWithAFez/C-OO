using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities
{
    public class TeamMatch : MatchType, IEquatable<TeamMatch>
    {
        public List<int> Scores { get; set; }

        public List<TeamType> Teams { get; set; }

        public static bool operator ==(TeamMatch a, TeamMatch b)
        {
            return (b.Scores.SequenceEqual(a.Scores) && a.Teams.SequenceEqual(b.Teams));
        }

        public static bool operator !=(TeamMatch a, TeamMatch b)
        {
            return !(a == b);
        }

        public bool Equals(TeamMatch other)
        {
            return (this == other);
        }

        public override bool Equals(object other)
        {
            if (!(other is TeamMatch))
            {
                return false;
            }
            else
            {
                return (this.Equals((TeamMatch)other));
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()} - {this.Teams.ToString()} - {this.Scores.ToString()}";
        }
    }
}
