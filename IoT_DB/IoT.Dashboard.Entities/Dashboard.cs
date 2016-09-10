using System.Collections.Generic;

namespace IoT.Dashboard.Entities
{
    public class Dashboard
    {
        public int DashboardId { get; set; }

        public int UserProfileId { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public virtual ICollection<DashboardDevice> DashboardDevices { get; set; }
    }
}
