using System;
using System.Collections.Generic;
using LunchService.Controllers;

namespace LunchService.Accessors
{
    public class LunchAccessor : ILunchAccessor
    {
        public LunchAccessor()
        {
        }
        public Lunch GetByLocation(string location)
        {
            throw new NotImplementedException();
        }

        public void CreateNewLunch(IEnumerable<Friend> friends)
        {
            throw new NotImplementedException();
        }
    }
}
