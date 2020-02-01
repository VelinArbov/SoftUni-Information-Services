using System;
using System.Collections.Generic;
using System.Text;
using SIS.HTTP.Enums;
using SIS.MVCFramework;
using SulsApp.Controllers;

namespace SulsApp
{
    public class StartUp : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            routeTable.Add(new Route("/", HttpMethodType.Get, new HomeController().Index));
            routeTable.Add(new Route("/css/bootstrap.min.css", HttpMethodType.Get, new StaticFilesController().Bootstrap));
            routeTable.Add(new Route("/css/site.css", HttpMethodType.Get, new StaticFilesController().Site));
            routeTable.Add(new Route("/css/reset.css", HttpMethodType.Get, new StaticFilesController().Reset));
            routeTable.Add(new Route("/Users/Login", HttpMethodType.Get, new UsersController().Login));
            routeTable.Add(new Route("/Users/Register", HttpMethodType.Get, new UsersController().Register));
        }

        public void ConfugreServices()
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureCreated();
        }
    }
}
