using IoT.Dashboard.Interfaces;
using System.Linq;
using IoT.Dashboard.Entities;

namespace IoT.Dashboard.Data
{
    public class UserProfilesRepository : IUserProfilesRepository
    {
        public UserProfile GetUserProfile(int userProfileId)
        {
            var db = new IoTDbContext();
            var profile = db.UserProfiles
                .Where(x => x.UserProfileId == userProfileId)
                .FirstOrDefault();

            return profile;
        }

        public UserProfile GetUserProfile(string userName, string password)
        {
#warning Password is not verified
            var db = new IoTDbContext();
            var profile = db.UserProfiles
                .Where(x => x.UserName == userName)
                .FirstOrDefault();

            return profile;
        }
    }
}
