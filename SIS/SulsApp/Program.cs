using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SIS.HTTP;
using SIS.HTTP.Enums;
using SIS.MVCFramework;
using SulsApp.Controllers;

namespace SulsApp
{
    public static class Program
    {
       public  static async  Task Main()
       {

           await WebHost.StartAsync(new StartUp());


       }
    }
}
