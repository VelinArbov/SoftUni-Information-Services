using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SIS.HTTP;
using SIS.HTTP.Enums;
using SIS.HTTP.Response;
using SIS.MVCFramework;

namespace DemoApp
{
    class StartUp : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            routeTable.Add(new Route("/", HttpMethodType.Get, Index));
            routeTable.Add(new Route("/Tweets/Create", HttpMethodType.Get, CreateTweet));
            routeTable.Add(new Route("/favicon.ico", HttpMethodType.Get, FavIcon));
        }

        public void ConfugreServices()
        {

            var db = new ApplicationDbContext();
            db.Database.EnsureCreated();

            private static HttpResponse FavIcon(HttpRequest request)
            {
                var byteContent = File.ReadAllBytes("wwwrooot/favicon.ico");
                return new FileResponse(byteContent, "image/x-icon");

            }




            public static HttpResponse Index(HttpRequest request)
            {
                var content = "<form action = '/Tweets/Create' method ='post'><textarea name ='tweetName'></textarea><input type='submit'  name ='Submit'></form>";


                return new HtmlResponse(content);
            }

        }
    }
}
