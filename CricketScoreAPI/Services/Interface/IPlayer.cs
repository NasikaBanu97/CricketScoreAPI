using CricketScoreAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricketScoreAPI.Services.Interface
{
    public interface IPlayer
    {
        public JsonResponse AddPlayer(Player model);
        public JsonResponse UpdatePlayer(Player model);
        public JsonResponse FetchAllPlayer();
        public JsonResponse FetchPlayerByID(int ID);
        public JsonResponse DeletePlayerByID(int ID);
    }
}
