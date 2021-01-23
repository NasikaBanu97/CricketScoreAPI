using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CricketScoreAPI.Model;
using CricketScoreAPI.Services.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CricketScoreAPI.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("Player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayer _player;
        public PlayerController(IPlayer player)
        {
            _player = player;
        }

        [HttpPost]
        [Route("AddPlayer")]
        public JsonResponse AddPlayer(Player model)
        {
            return _player.AddPlayer(model);
        }

        [HttpPost]
        [Route("UpdatePlayer")]
        public JsonResponse UpdatePlayer(Player model)
        {
            return (_player.UpdatePlayer(model));
        }

        [HttpPost]
        [Route("FetchPlayerByID")]
        public JsonResponse FetchPlayerByID(Player model)
        {
            return (_player.FetchPlayerByID(model.ID));
        }

        [HttpGet]
        [Route("FetchAllPlayer")]
        public JsonResponse FetchAllPlayer()
        {
            return (_player.FetchAllPlayer());
        }

        [HttpPost]
        [Route("DeletePlayerByID")]
        public JsonResponse DeletePlayerByID(Player model)
        {
            return (_player.DeletePlayerByID(model.ID));
        }

        [Route("Sample")]
        public string SamplePlayerByID()
        {
            return "s";
        }
    }
}
