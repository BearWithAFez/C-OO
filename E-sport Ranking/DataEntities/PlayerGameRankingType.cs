using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities
{
    public class PlayerGameRankingType : IEquatable<PlayerGameRankingType>, IComparable<PlayerGameRankingType>
    {
        public GameType Game { get; set; }

        public PlayerType Player { get; set; }

        public int Points { get; set; }

        public Ranks Ranking { get; set; }

        public static bool operator ==(PlayerGameRankingType a, PlayerGameRankingType b)
        {
            return ((a.Game == b.Game) && (a.Player == b.Player) && (a.Points == b.Points) && (a.Ranking == b.Ranking));
        }

        public static bool operator !=(PlayerGameRankingType a, PlayerGameRankingType b)
        {
            return !(a == b);
        }

        public bool Equals(PlayerGameRankingType other)
        {
            return (this == other);
        }

        public override bool Equals(object other)
        {
            if (!(other is PlayerGameRankingType))
            {
                return false;
            }
            else
            {
                return (this.Equals((PlayerGameRankingType)other));
            }
        }

        public override string ToString()
        {
            return $"{this.Game} - {this.Player} - {this.Points} - {this.Ranking}";
        }

        public int CompareTo(PlayerGameRankingType that)
        {
            if (this.Game != that.Game) throw new Exception("Game's komen niet overeen.");
            return this.Points.CompareTo(that.Points);
        }
    }
}
