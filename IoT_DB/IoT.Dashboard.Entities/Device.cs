namespace IoT.Dashboard.Entities
{
    public class Device
    {
        public int DeviceId { get; set; }

        public int UserProfileId { get; set; }

        public string DeviceKey { get; set; }

        public string Name { get; set; }

        public string Units { get; set; }
    }
}
