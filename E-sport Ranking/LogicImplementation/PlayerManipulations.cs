using System;
using System.Collections.Generic;
using DataEntities;
using LogicInterfaces;
using DataAccessImplementation;
using DataAccessInterfaces;

namespace LogicImplementation
{
    class PlayerManipulations : IPlayerManipulations
    {
        private IGameRankingDataAccess backend = new GameRankingDataAccess();
        public void AddOrUpdatePlayer(PlayerType player)
        {
            throw new NotImplementedException();
        }

        public List<MatchType> GetGameMatchesForPlayer(GameType game, PlayerType player)
        {
            throw new NotImplementedException();
        }

        public List<GameType> GetGamesForPlayer(PlayerType player)
        {
            throw new NotImplementedException();
        }

        public List<MatchType> GetMatchesForPlayer(PlayerType player)
        {
            throw new NotImplementedException();
        }

        public List<PlayerType> GetPlayers()
        {
            throw new NotImplementedException();
        }

        public List<PlayerType> GetPlayersForgame(GameType game)
        {
            throw new NotImplementedException();
        }
    }
}
