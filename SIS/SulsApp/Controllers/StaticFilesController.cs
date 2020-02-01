using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using SIS.HTTP;
using SIS.HTTP.Response;
using SIS.MVCFramework;

namespace SulsApp.Controllers
{
    public class StaticFilesController : Controller
    {
        public HttpResponse Bootstrap(HttpRequest request)
        {
            return  new FileResponse(File.ReadAllBytes("wwwroot/css/bootstrap.min.css"),"text/css");

        }

        public HttpResponse Reset(HttpRequest request)
        {
            return new FileResponse(File.ReadAllBytes("wwwroot/css/reset.css"), "text/css");

        }

        public HttpResponse Site(HttpRequest request)
        {
            return new FileResponse(File.ReadAllBytes("wwwroot/css/site.css"), "text/css");

        }

    }
}
