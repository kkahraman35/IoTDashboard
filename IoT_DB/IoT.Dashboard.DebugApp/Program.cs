using IoT.Dashboard.Common;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Configuration;

namespace IoT.Dashboard.DebugApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Configure(container);

            //var repo = container.Resolve<IUserProfilesRepository>();
            //var profile = repo.GetUserProfile(1);
            //Console.WriteLine(profile.UserName);

            var queue = container.Resolve<ISignalsQueueProvider>();
            queue.AddSignalToQueue("d5GnjP0bdX", 42, DateTimeOffset.Now);
            string s; decimal d; DateTimeOffset o;
            queue.GetSignalFromQueue(out s, out d, out o);


            Console.ReadKey();
        }
    }
}
