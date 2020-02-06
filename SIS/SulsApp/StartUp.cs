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
          
        }

        public void ConfugreServices()
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureCreated();
        }
    }
}
