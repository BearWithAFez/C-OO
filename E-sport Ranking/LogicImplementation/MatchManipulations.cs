using System;
using System.Collections.Generic;
using DataEntities;
using LogicInterfaces;
using DataAccessImplementation;
using DataAccessInterfaces;

namespace LogicImplementation
{
    class MatchManipulations : IMatchManipulations
    {
        private IGameRankingDataAccess backend = new GameRankingDataAccess();
        public void AddOrUpdateSoloMatch(SoloMatch match)
        {
            throw new NotImplementedException();
        }

        public void AddOrUpdateTeamMatch(TeamMatch match)
        {
            throw new NotImplementedException();
        }

        public List<MatchType> GetMatches(GameType game, ParticipantTypes soloOrTeam, MatchCategories matchCategory)
        {
            throw new NotImplementedException();
        }

        public List<MatchType> GetMatchesAll(GameType game)
        {
            throw new NotImplementedException();
        }
    }
}
