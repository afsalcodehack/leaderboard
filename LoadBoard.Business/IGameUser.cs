using LeadBoard.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoadBoard.Business
{
    public interface IGameUser
    {
        Task<ResponseBase> CreateUser(UserModel user);

        Task<UserResponse> GetAllUser();
    }
}
