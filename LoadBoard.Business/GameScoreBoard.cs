using LeadBoard.Entity;
using LoadBoard_Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace LoadBoard.Business
{
    public class GameScoreBoard: IGameScoreBoard
    {
        private DbContext _context;
        public GameScoreBoard(DbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<ResponseBase> CreateScore(ScoreBoardModel score)
        {
            ResponseBase response = new ResponseBase();

            try
            {

                await _context.Set<LoadBoard_Data.Score>().AddAsync(new LoadBoard_Data.Score
                {
                   Date = DateTime.Now,
                   GameId = score.GameId,
                   Score1 = score.Score,
                   UserId = score.UserId
                });
                await _context.SaveChangesAsync();

                response.ErroCode = 1002;

                response.ErrorMessage = "score Created successs";


            }
            catch (Exception ex)
            {
                //log  exception here
                //manage error from external json 
                response.ErroCode = 1000;
                response.ErrorMessage = "Somthing went wrong";
            }

            return response;
        }

        public async Task<ScoreBoardResponse> GetByGame(int gameId)
        {
            ScoreBoardResponse response = new ScoreBoardResponse();
            try
            {


                response.scoreList = await (from res in _context.Set<Score>()
                                           join u in _context.Set<LoadBoard_Data.User>() on res.UserId equals u.UserId
                                           join g in _context.Set<LoadBoard_Data.Game>() on res.GameId equals g.Id
                                           select new ScoreBoardModel
                                           {
                                               Id = res.Id,
                                               GameId = res.GameId.Value,
                                               GameName = g.GameName,
                                               Score = (float)res.Score1.Value,
                                               UserId = res.UserId.Value,
                                               UserName = u.UserName
                                           }).Where(x=>x.GameId == gameId).OrderByDescending(x => x.Score).ToListAsync();
            }
            catch (Exception ex)
            {
                //log  exception here
                //manage error from external json 
                response.ErroCode = 1000;
                response.ErrorMessage = "Somthing went wrong";
            }

            return response;
        }

        public async Task<ScoreBoardResponse> GetScore(int limit)
        {
            ScoreBoardResponse response = new ScoreBoardResponse();
            try
            {


                response.scoreList = await (from res in _context.Set<Score>()
                                            join u in _context.Set<LoadBoard_Data.User>() on res.UserId equals u.UserId
                                            join g in _context.Set<LoadBoard_Data.Game>() on res.GameId equals g.Id
                                            select new ScoreBoardModel
                                            {
                                                Id = res.Id,
                                                GameId = res.GameId.Value,
                                                GameName = g.GameName,
                                                Score = (float)res.Score1.Value,
                                                UserId = res.UserId.Value,
                                                UserName = u.UserName
                                            }).OrderByDescending(x=>x.Score).ToListAsync();
            }
            catch (Exception ex)
            {
                //log  exception here
                //manage error from external json 
                response.ErroCode = 1000;
                response.ErrorMessage = "Somthing went wrong";
            }

            return response;
        }
    }
}
