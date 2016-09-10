using System;

namespace IoT.Dashboard.Entities
{
    public class Signal
    {
        public int SignalId { get; set; }

        public int DeviceId { get; set; }

        public DateTimeOffset SignalTime { get; set; }

        public decimal SignalValue { get; set; }
    }
}
