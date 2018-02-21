using System;
using System.Collections.Generic;
using DataEntities;
using LogicInterfaces;
using DataAccessImplementation;
using DataAccessInterfaces;

namespace LogicImplementation
{
    class RankingSource : IRankingSource
    {
        private IGameRankingDataAccess backend = new GameRankingDataAccess();
        public List<PlayerGameRankingType> GetGameRankings(GameType game, ParticipantTypes soloOrTeam, Ranks rank)
        {
            throw new NotImplementedException();
        }

        public List<PlayerGameRankingType> GetGameRankingsAll(GameType game, ParticipantTypes soloOrTeam)
        {
            throw new NotImplementedException();
        }
    }
}
