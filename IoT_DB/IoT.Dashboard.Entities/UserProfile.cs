using System.Collections.Generic;

namespace IoT.Dashboard.Entities
{
    public class UserProfile
    {
        public int UserProfileId { get; set; }

        public string UserName { get; set; }

        public byte[] Salt { get; set; }

        public byte[] PasswordHash { get; set; }

        public virtual ICollection<Device> Devices { get; set; }

        public virtual ICollection<Dashboard> Dashboards { get; set; }
    }
}
