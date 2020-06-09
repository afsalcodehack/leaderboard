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
    public class GameUser: IGameUser
    {
        private DbContext _context;
        public GameUser(DbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<ResponseBase> CreateUser(UserModel user)
        {
            ResponseBase response = new ResponseBase();

            try
            {

                await _context.Set<LoadBoard_Data.User>().AddAsync(new LoadBoard_Data.User
                {
                    UserName = user.UserName
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

        public async Task<UserResponse> GetAllUser()
        {
            UserResponse response = new UserResponse();
            try
            {
                response.Users = await _context.Set<LoadBoard_Data.User>().Select(x => new UserModel
                {
                    UserId = x.UserId,
                    UserName = x.UserName
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
