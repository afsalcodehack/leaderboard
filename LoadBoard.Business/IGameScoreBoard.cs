using LeadBoard.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoadBoard.Business
{
    public interface IGameScoreBoard
    {
        Task<ScoreBoardResponse> GetScore(int limit);

        Task<ScoreBoardResponse> GetByGame(int gameId);

        Task<ResponseBase> CreateScore(ScoreBoardModel score);
    }
}
