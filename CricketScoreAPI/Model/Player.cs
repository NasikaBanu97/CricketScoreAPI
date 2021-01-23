using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricketScoreAPI.Model
{
    public class Player
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleID { get; set; }
        public int TeamID { get; set; }
        public string Profile { get; set; }
    }
}
