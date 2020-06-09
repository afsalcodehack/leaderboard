using System;
using System.Collections.Generic;
using System.Text;

namespace LeadBoard.Entity
{

    public class ScoreBoardResponse :ResponseBase
    {
        public List<ScoreBoardModel> scoreList { get; set; }
    }

    public class ScoreBoardModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public int GameId { get; set; }

        public string UserName { get; set; }

        public string GameName { get; set; }

        public float Score { get; set; }
    }
}
