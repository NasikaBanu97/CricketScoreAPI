using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricketScoreAPI.Model
{
    public class JsonResponse
    {
        public string Status { get; set; } = "S";
        public string Message { get; set; } = "Success";
        public Object Data { get; set; }
    }
}
