using System;

namespace IoT.Dashboard.Common
{
    public interface ISignalsQueueProvider : IDisposable
    {
        void AddSignalToQueue(string deviceKey, string changeKey, decimal signalValue, DateTimeOffset signalTime);
        bool GetSignalFromQueue(out string deviceKey, out string changeKey, out decimal signalValue, out DateTimeOffset signalTime);
    }
}
