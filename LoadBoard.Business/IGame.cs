using LeadBoard.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoadBoard.Business
{
    public interface IGame
    {
        public Task<ResponseBase> CreateGame(GameModel game);

        public Task<GameResponse> GetAllGames();
    }
}
