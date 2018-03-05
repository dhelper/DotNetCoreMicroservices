using System.Collections.Generic;
using LunchService.Controllers;

namespace LunchService.Accessors
{
    public interface ILunchAccessor
    {
        Lunch GetByLocation(string location);
        void CreateNewLunch(IEnumerable<Friend> friends);
    }
}