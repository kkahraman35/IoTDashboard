using IoT.Dashboard.Entities;

namespace IoT.Dashboard.Common
{
    public interface IUserProfilesRepository
    {
        UserProfile GetUserProfile(int userProfileId);
        UserProfile GetUserProfile(string userName, string password);
    }
}
