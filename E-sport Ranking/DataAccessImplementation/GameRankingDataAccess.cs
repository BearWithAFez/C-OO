using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataEntities;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace DataAccessImplementation
{
    public class GameRankingDataAccess : IGameRankingDataAccess
    {
        public GameRankingDataAccess()
        {
            try { LoadTeamList(); }
            catch { Teams = new List<TeamType>(); }

            try { LoadGameList(); }
            catch { Games = new List<GameType>(); }

            try { LoadMatchList(); }
            catch { MatchList = new List<MatchType>(); }

            try { LoadPlayerList(); }
            catch { Players = new List<PlayerType>(); }

            try { LoadRankingList(); }
            catch { RankingList = new List<PlayerGameRankingType>(); }

        }
        public List<GameType> Games
        {
            get;
            set;
        }

        public List<MatchType> MatchList
        {
            get;
            set;
        }

        public List<PlayerType> Players
        {
            get;
            set;
        }

        public List<PlayerGameRankingType> RankingList
        {
            get;
            set;
        }

        public List<TeamType> Teams
        {
            get;
            set;
        }

        public void ClearAllData()
        {
            Games = new List<GameType>();
            MatchList = new List<MatchType>();
            Players = new List<PlayerType>();
            RankingList = new List<PlayerGameRankingType>();
            Teams = new List<TeamType>();
        }

        public void SubmitGameListChanges()
        {
            var formatter = new BinaryFormatter();
            using (var bestand = File.OpenWrite("Games.bin"))
            {
                formatter.Serialize(bestand, Games);
            }
        }
        public void LoadGameList()
        {
            var formatter = new BinaryFormatter();
            using (var bestand = File.OpenRead("Games.bin"))
            {
               Games = (List<GameType>)formatter.Deserialize(bestand);
            }
        }

        public void SubmitmatchListChanges()
        {
            var formatter = new BinaryFormatter();
            using (var bestand = File.OpenWrite("Matches.bin"))
            {
                formatter.Serialize(bestand, MatchList);
            }
        }
        private void LoadMatchList()
        {
            var formatter = new BinaryFormatter();
            using (var bestand = File.OpenRead("Matches.bin"))
            {
                MatchList = (List<MatchType>)formatter.Deserialize(bestand);
            }
        }

        public void SubmitPlayerListChanges()
        {
            var formatter = new BinaryFormatter();
            using (var bestand = File.OpenWrite("Players.bin"))
            {
                formatter.Serialize(bestand, Players);
            }
        }
        private void LoadPlayerList()
        {
            var formatter = new BinaryFormatter();
            using (var bestand = File.OpenRead("Players.bin"))
            {
                Players = (List<PlayerType>)formatter.Deserialize(bestand);
            }
        }

        public void SubmitRankingListChanges()
        {
            var formatter = new BinaryFormatter();
            using (var bestand = File.OpenWrite("Rankings.bin"))
            {
                formatter.Serialize(bestand, RankingList);
            }
        }
        private void LoadRankingList()
        {
            var formatter = new BinaryFormatter();
            using (var bestand = File.OpenRead("Rankings.bin"))
            {
                RankingList = (List<PlayerGameRankingType>)formatter.Deserialize(bestand);
            }
        }

        public void SubmitTeamListChanges()
        {
            var formatter = new BinaryFormatter();
            using (var bestand = File.OpenWrite("Teams.bin"))
            {
                formatter.Serialize(bestand, Teams);
            }
        }
        private void LoadTeamList()
        {
            var formatter = new BinaryFormatter();
            using (var bestand = File.OpenRead("Teams.bin"))
            {
                Teams = (List<TeamType>)formatter.Deserialize(bestand);
            }
        }
    }
}
