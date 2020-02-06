using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SIS.HTTP;
using SIS.HTTP.Enums;
using SIS.HTTP.Response;

namespace SIS.MVCFramework
{
    public class WebHost
    {

        public static async Task StartAsync(IMvcApplication application)
        {

            var routeTable = new List<Route>();
            application.ConfugreServices();
            application.Configure(routeTable);
            AutoRegisterStaticFilesRoute(routeTable);
            AutoRegisterNonStaticFilesRoute(routeTable, application);

            Console.WriteLine("Registred routes: ");
            foreach (var route in routeTable)
            {
                Console.WriteLine(route);
            }


            Console.WriteLine("Request: ");
            Console.WriteLine();


            var httpServer = new HttpServer(80, routeTable);
            await httpServer.StartAsync();
        }

        private static void AutoRegisterNonStaticFilesRoute(List<Route> routeTable, IMvcApplication application)
        {
            var types = application.GetType().Assembly.GetTypes()
                 .Where(type => type.IsSubclassOf(typeof(Controller)) && !type.IsAbstract);
            foreach (var type in types)
            {
                Console.WriteLine(type.FullName);
                var methods = type.GetMethods()
                    .Where(x => !x.IsSpecialName
                    && !x.IsConstructor
                    && x.IsPublic
                    && x.DeclaringType == type);
                foreach (var method in methods)
                {
                    string url = "/" + type.Name.Replace("Controller", string.Empty) + "/" + method.Name;

                    var attribute = method.GetCustomAttributes()
                        .FirstOrDefault(x => x.GetType()
                        .IsSubclassOf(typeof(HttpMethodAttribute)))
                         as HttpMethodAttribute;
                    var httpActionType = HttpMethodType.Get;
                    if (attribute != null)
                    {
                        httpActionType = attribute.Type;
                        if (attribute.Url != null)
                        {
                            url = attribute.Url;
                        }
                    }

                    routeTable.Add(new Route(url, httpActionType, (request) =>
                    {
                        var controller = Activator.CreateInstance(type) as Controller;
                        controller.Request = request;
                        var response = method.Invoke(controller, new object [] {}) as HttpResponse;
                        return response;
                    }));
                    Console.WriteLine("    " + url);
                }
            }
        }



        private static void AutoRegisterStaticFilesRoute(List<Route> routeTable)
        {
            var staticFiles = Directory.GetFiles("wwwroot", "*", SearchOption.AllDirectories);
            foreach (var staticFile in staticFiles)
            {
                var path = staticFile.Replace(@"wwwroot", string.Empty).Replace(@"\", "/");
                routeTable.Add(new Route(path, HttpMethodType.Get, (request) =>
               {
                   var fileInfo = new FileInfo(staticFile);
                   var contentTpe = fileInfo.Extension switch
                   {
                       ".css" => "text/css",
                       ".html" => "text/html",
                       ".js" => "text/javascript",
                       ".ico" => "image/x-icon",
                       ".png" => "image/png",
                       ".jpg" => "image/jpeg",
                       ".jpeg" => "image/jpeg",
                       ".gif" => "image/gif",
                       _ => "text/plain"
                   };
                   return new FileResponse(File.ReadAllBytes(staticFile), contentTpe);
               }));
            }

        }
    }
}
