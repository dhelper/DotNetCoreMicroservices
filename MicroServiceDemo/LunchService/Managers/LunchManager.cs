using System.Linq;
using LunchService.Accessors;
using LunchService.Controllers;

namespace LunchService
{
    public class LunchManager
    {
        private readonly ILunchAccessor _lunchAccessor;

        public LunchManager(ILunchAccessor lunchAccessor)
        {
            _lunchAccessor = lunchAccessor;
        }

        public Lunch GetLunchByLocation(string location)
        {
            return _lunchAccessor.GetByLocation(location);
        }

        public void AskFriendsToJoinLunch(string location)
        {
            if(_lunchAccessor.GetByLocation(location) != null)
            {
                throw new LunchAlreadyExistException("Your already have plans for today");
            }

            var friends = Enumerable.Empty<Friend>();
            _lunchAccessor.CreateNewLunch(friends);
        }
    }
}
