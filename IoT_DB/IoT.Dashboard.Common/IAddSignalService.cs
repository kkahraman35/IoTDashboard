using System;
using System.ServiceModel;

namespace IoT.Dashboard.Common
{
    [ServiceContract]
    public interface IAddSignalService
    {
        [OperationContract]
        void AddSignal(string deviceKey, string changeKey, decimal signalValue, DateTimeOffset signalTime);
    }
}
