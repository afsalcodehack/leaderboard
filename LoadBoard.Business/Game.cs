using LeadBoard.Entity;
using LoadBoard_Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadBoard.Business
{
    public class Game : IGame
    {
        private DbContext _context;
        public Game(DbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<ResponseBase> CreateGame(GameModel game)
        {
            ResponseBase response = new ResponseBase();

            try
            {

                await _context.Set<LoadBoard_Data.Game>().AddAsync(new LoadBoard_Data.Game
                {
                    GameName = game.GameName
                });

               await _context.SaveChangesAsync();

                response.ErroCode = 1002;
                response.ErrorMessage = "Game Created successs";


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

        public async Task<GameResponse> GetAllGames()
        {
            GameResponse response = new GameResponse();
            try
            {
                response.Games = await _context.Set<LoadBoard_Data.Game>().Select(x => new GameModel
                {
                    Id = x.Id,
                    GameName = x.GameName
                }).ToListAsync();
              
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
