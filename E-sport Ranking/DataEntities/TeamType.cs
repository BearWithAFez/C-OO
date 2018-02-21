using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities
{
    public class TeamType : IEquatable<TeamType>
    {
        public List<PlayerType> Members { get; set; }

        public string Name { get; set; }

        public static bool operator ==(TeamType a, TeamType b)
        {
            return ((a.Name == b.Name) && (a.Members.SequenceEqual(b.Members)));
        }

        public static bool operator !=(TeamType a, TeamType b)
        {
            return !(a == b);
        }

        public bool Equals(TeamType other)
        {
            return (this == other);
        }

        public override bool Equals(object other)
        {
            if (!(other is TeamType))
            {
                return false;
            }
            else
            {
                return (this.Equals((TeamType)other));
            }
        }

        public override string ToString() // Nog testen als dit klopt!!!!!
        {
            string players = "";
            for (int i = 0; i < Members.Count; i++)
            {
                players += Members[i];
                players += ", ";
            }
            return $"{this.Name} - {players}";
        }
    }
}
