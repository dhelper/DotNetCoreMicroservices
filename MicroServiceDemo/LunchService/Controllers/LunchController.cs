using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace LunchService.Controllers
{
    [Route("api/[controller]")]
    public class LunchesController : Controller
    {
        private readonly LunchManager _manager;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="manager"></param>
        public LunchesController(LunchManager manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// Get today's lunch friends
        /// </summary>
        /// <returns></returns>
        [HttpGet("{location}")]
        public IEnumerable<Friend> GetMyLunchPlans(string location)
        {
            return _manager.GetLunchByLocation(location).Friends;
        }

        /// <summary>
        /// Create new ;plans based on location
        /// </summary>
        /// <param name="location"></param>
        [HttpPost("/request")]
        public Lunch AskFriendsToJoinByLocation([FromBody]string location)
        {
            return _manager.AskFriendsToJoinLunch(location);
        }
    }
}
