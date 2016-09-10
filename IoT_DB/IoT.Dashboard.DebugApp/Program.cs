using IoT.Dashboard.Interfaces;
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
            var repo = container.Resolve<IUserProfilesRepository>();

            var profile = repo.GetUserProfile(1);

            Console.WriteLine(profile.UserName);
            Console.ReadKey();
        }
    }
}
