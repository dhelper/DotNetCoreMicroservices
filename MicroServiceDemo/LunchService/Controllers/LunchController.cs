using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace LunchService.Controllers
{
    [Route("api/[controller]")]
    public class LunchesController : Controller
    {
        [HttpGet]
        public IEnumerable<Friend> GetMyLunchPlans()
        {
            return new[] {new Friend {Name = "Jasse"}, new Friend {Name = "Dave"}};
        }

        [HttpGet("Free/{city}")]
        public IEnumerable<Friend> GetAvailableFriendsByCity([FromQuery] string city)
        {
            return new[] {new Friend {Name = "Jasse"}, new Friend {Name = "Dave"}};
        }

        [HttpPost()]
        public void AskFriendsToJoinByLocation([FromBody]string location)
        {
            // get all in same location
            // create new lunch for date
        }
    }

  

    public class Lunch
    {
        public int Id { get; set; }
        public IEnumerable<Friend> Friends { get; set; }
        public string Location { get; set; }
    }

    public class Friend
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
