using System;

namespace IoT.Dashboard.Common
{
    public interface ISignalsQueueProvider : IDisposable
    {
        void AddSignalToQueue(string deviceKey, decimal signalValue, DateTimeOffset signalTime);
        bool GetSignalFromQueue(out string deviceKey, out decimal signalValue, out DateTimeOffset signalTime);
    }
}
