using IoT.Dashboard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT.Dashboard.DebugApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new IoTDbContext();
            var profile = db.UserProfiles
                .Where(x => x.UserProfileId == 1)
                .FirstOrDefault();

            Console.WriteLine(profile.UserName);
            Console.ReadKey();
        }
    }
}
