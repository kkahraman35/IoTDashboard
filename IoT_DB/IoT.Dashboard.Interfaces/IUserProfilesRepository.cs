using IoT.Dashboard.Entities;

namespace IoT.Dashboard.Interfaces
{
    public interface IUserProfilesRepository
    {
        UserProfile GetUserProfile(int userProfileId);
        UserProfile GetUserProfile(string userName, string password);
    }
}
