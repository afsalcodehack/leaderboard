using System;
using System.Collections.Generic;
using System.Text;

namespace LeadBoard.Entity
{
    public class GameResponse: ResponseBase
    {
        public List<GameModel> Games { get; set; }
    }

    public class GameModel
    {
        public int Id { get; set; }
        public string GameName { get; set; }
    }
}
