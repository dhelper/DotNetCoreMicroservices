using System.Collections.Generic;

namespace LunchService.Controllers
{
    public class Lunch
    {
        public int Id { get; set; }
        public IEnumerable<Friend> Friends { get; set; }
        public string Location { get; set; }
    }
}