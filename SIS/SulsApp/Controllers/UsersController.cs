

using System.IO;
using SIS.HTTP;
using SIS.HTTP.Response;
using SIS.MVCFramework;

namespace SulsApp.Controllers
{
     class UsersController : Controller
    {


        public HttpResponse Login()
        {
         
            return this.View();
        }

        [HttpPost("/Users/Login")]
        public HttpResponse DoLogin()
        {

            return this.View();
        }


        public HttpResponse Register()
        {

            return this.View();
        }

        [HttpPost("/Users/Register")]
        public HttpResponse DoRegister()
        {

            return this.View();
        }

    }
}
