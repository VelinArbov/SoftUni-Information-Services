

using System.IO;
using SIS.HTTP;
using SIS.HTTP.Response;
using SIS.MVCFramework;

namespace SulsApp.Controllers
{
     class UsersController : Controller
    {

        public HttpResponse Login(HttpRequest request)
        {
         
            return this.View();
        }

        public HttpResponse Register(HttpRequest request)
        {

            return this.View();
        }

    }
}
