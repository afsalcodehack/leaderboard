using System;
using System.Collections.Generic;
using System.Text;

namespace LeadBoard.Entity
{
    public class ResponseBase
    {
        public int ErroCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
