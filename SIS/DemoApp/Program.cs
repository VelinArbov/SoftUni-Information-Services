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
            routeTable.Add(new Route("/",HttpMethodType.Get,Index));
            routeTable.Add(new Route("/users/login",HttpMethodType.Get,Login));
            routeTable.Add(new Route("/users/login",HttpMethodType.Post,DoLogin));
            routeTable.Add(new Route("/users/login",HttpMethodType.Get,Contact));
            routeTable.Add(new Route("/favicon.ico",HttpMethodType.Get,FavIcon));



            var httpServer = new HttpServer(80,routeTable);
            await httpServer.StartAsync();
        }

        private static HttpResponse FavIcon(HttpRequest request)
        {
            var byteContent = File.ReadAllBytes("wwwrooot/favicon.ico");
            return new FileResponse(byteContent, "image/x-icon");

        }

        private static HttpResponse Contact(HttpRequest request)
        {
            var content = "<h1>Contact</h1>";
     
            return new HtmlResponse(content);
        }


        public static HttpResponse Index(HttpRequest request)
        {
            var content = "<h1>Home page</h1>";
        

            return new HtmlResponse(content);
        }

        public static HttpResponse Login(HttpRequest request)
        {
            var content = "<h1>Login page</h1>";

            return new HtmlResponse(content);
        }


        public static HttpResponse DoLogin(HttpRequest request)
        {
            var content = "<h1>Login page</h1>";


            return new HtmlResponse(content);
        }
    }

}
