using IoT.Dashboard.Common;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Configuration;

namespace IoT.Dashboard.AddSignalService.Controller
{
    public class AddSignalService : IAddSignalService
    {
        public AddSignalService()
        {
            var container = new UnityContainer();
            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Configure(container);

            _queueProvider = container.Resolve<ISignalsQueueProvider>();
        }

        public void AddSignal(string deviceKey, string changeKey, decimal signalValue, DateTimeOffset signalTime)
        {
            _queueProvider.AddSignalToQueue(deviceKey, changeKey, signalValue, signalTime);
        }

        private ISignalsQueueProvider _queueProvider;
    }
}
