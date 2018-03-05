using System.Linq;
using System.Threading.Tasks;
using LunchService.Accessors;
using LunchService.Controllers;

namespace LunchService
{
    public class LunchManager
    {
        private readonly ILunchAccessor _lunchAccessor;
        private readonly IUserAccessor _userAccessor;

        public LunchManager(ILunchAccessor lunchAccessor, IUserAccessor userAccessor)
        {
            _lunchAccessor = lunchAccessor;
            _userAccessor = userAccessor;
        }

        public Lunch GetLunchByLocation(string location)
        {
            return _lunchAccessor.GetByLocation(location);
        }

        public async Task<Lunch> AskFriendsToJoinLunchAsync(string location)
        {
            if(_lunchAccessor.GetByLocation(location) != null)
            {
                throw new LunchAlreadyExistException("Your already have plans for today");
            }

            var friends = await _userAccessor.GetFriendsByLocationAsync(location);
            return _lunchAccessor.CreateNewLunch(friends, location);
        }
    }
}
