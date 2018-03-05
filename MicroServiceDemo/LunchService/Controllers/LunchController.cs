using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace LunchService.Controllers
{
    [Route("api/[controller]")]
    public class LunchesController : Controller
    {
        [HttpGet]
        public IEnumerable<Friend> Get()
        {
            return new[] {new Friend {Name = "Jasse"}, new Friend {Name = "Dave"}};
        }
    }

    public class Friend
    {
        public string Name { get; set; }
    }
}
