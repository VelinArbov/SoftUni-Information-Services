using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SIS.HTTP;

namespace SIS.MVCFramework
{
   public class WebHost
    {

        public static async Task StartAsync(IMvcApplication application)
        {

            var routeTable = new List<Route>();
            application.ConfugreServices();
            application.Configure(routeTable);
            var httpServer = new HttpServer(80, routeTable);
            await httpServer.StartAsync();
        }
    }
}
