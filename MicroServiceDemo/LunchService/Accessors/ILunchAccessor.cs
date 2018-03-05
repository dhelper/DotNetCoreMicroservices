using System.Collections.Generic;
using LunchService.Controllers;

namespace LunchService.Accessors
{
    public interface ILunchAccessor
    {
        Lunch GetByLocation(string location);
        Lunch CreateNewLunch(IEnumerable<Friend> friends, string location);
    }
}