
using System.IO;
using System.Runtime.CompilerServices;
using SIS.HTTP;
using SIS.HTTP.Response;

namespace SIS.MVCFramework

{
    public abstract class Controller
    {
        protected HttpResponse View([CallerMemberName]string viewName = null)
        {

            var layout = File.ReadAllText("Views/Shared/_Layout.html");
            var controlerName = this.GetType().Name.Replace("Controller",string.Empty);
            var html = File.ReadAllText("Views/"+controlerName + "/" + viewName+ ".html");
            var bodyWithLayout = layout.Replace("@RenderBody()", html);
            return new HtmlResponse(bodyWithLayout);
        }


    }
}