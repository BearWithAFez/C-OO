using System;
using System.Collections.Generic;
using DataEntities;
using LogicInterfaces;
using DataAccessInterfaces;
using DataAccessImplementation;

namespace LogicImplementation
{
    class TeamManipulations : ITeamManipulations
    {
        private IGameRankingDataAccess backend = new GameRankingDataAccess();
        public bool AddOrUpdateTeam(TeamType team)
        {
            throw new NotImplementedException();
        }

        public List<MatchType> GetGameMatchesForTeam(GameType game, TeamType team)
        {
            throw new NotImplementedException();
        }

        public List<GameType> GetGamesForTeam(TeamType team)
        {
            throw new NotImplementedException();
        }

        public List<MatchType> GetMatchesForTeam(TeamType team)
        {
            throw new NotImplementedException();
        }

        public List<TeamType> GetTeams()
        {
            throw new NotImplementedException();
        }

        public List<TeamType> GetTeamsforGame(GameType game)
        {
            throw new NotImplementedException();
        }
    }
}
