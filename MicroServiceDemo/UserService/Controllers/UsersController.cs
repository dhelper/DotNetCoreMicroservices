using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        [HttpGet("{location}")]
        public IEnumerable<User> GetUsersByLocation(string location)
        {
            switch (location)
            {
                case "London":
                    return new[]
                    {
                        new User {Id = 1, Name = "John"},
                        new User {Id = 1, Name = "Paul"},
                        new User {Id = 1, Name = "George"},
                        new User {Id = 1, Name = "Ringo"},
                    };
                case "Washington":
                    return new[]
                    {
                        new User {Id = 1, Name = "Donald"},
                        new User {Id = 1, Name = "Barak"},
                        new User {Id = 1, Name = "George"},
                    };
            }

            return new[]
            {
                        new User {Id = 1, Name = "Mike"},
                        new User {Id = 1, Name = "Sara"},
                        new User {Id = 1, Name = "Dave"},
            };
        }
    }

}
