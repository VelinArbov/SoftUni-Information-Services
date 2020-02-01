using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SIS.HTTP;
using SIS.HTTP.Enums;
using SIS.HTTP.Response;


namespace DemoApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
          


            var routeTable = new List<Route>();
          



            var httpServer = new HttpServer(80,routeTable);
            await httpServer.StartAsync();
        }

        private static HttpResponse CreateTweet(HttpRequest request)
        {
            return  new HtmlResponse("");
        }

      
     
    }

}
