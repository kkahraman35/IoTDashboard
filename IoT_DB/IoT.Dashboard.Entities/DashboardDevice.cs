using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IoT.Dashboard.Entities
{
    public class DashboardDevice
    {
        [Key, Column(Order = 0)]
        public int DashboardId { get; set; }

        [Key, Column(Order = 1)]
        public int DeviceId { get; set; }

        public virtual Device Device { get; set; }
    }
}
