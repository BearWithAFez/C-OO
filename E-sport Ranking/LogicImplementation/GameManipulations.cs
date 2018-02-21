using System;
using System.Collections.Generic;
using DataEntities;
using LogicInterfaces;
using DataAccessInterfaces;
using DataAccessImplementation;

namespace LogicImplementation
{
    class GameManipulations : IGameManipulations
    {
        private IGameRankingDataAccess backend = new GameRankingDataAccess();
        public void AddOrUpdateGame(GameType game)
        {
            throw new NotImplementedException();
        }

        public List<GameType> GetGames()
        {
            throw new NotImplementedException();
        }
    }
}
