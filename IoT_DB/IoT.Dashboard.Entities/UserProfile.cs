namespace IoT.Dashboard.Entities
{
    public class UserProfile
    {
        public int UserProfileId { get; set; }

        public string UserName { get; set; }

        public byte[] Salt { get; set; }

        public byte[] PasswordHash { get; set; }
    }
}
