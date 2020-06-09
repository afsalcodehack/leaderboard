using System;
using System.Collections.Generic;
using System.Text;

namespace LeadBoard.Entity
{

    public class UserResponse : ResponseBase
    {
        public List<UserModel> Users { get; set; }
    }
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

    }
}
