
using System.IO;
using System.Runtime.CompilerServices;
using SIS.HTTP;
using SIS.HTTP.Response;
using SIS.MVCFrameworkFramework;

namespace SIS.MVCFramework

{
    public abstract class Controller
    {
        public HttpRequest Request { get; set; }
        protected HttpResponse View<T>( T viewModel= null,[CallerMemberName]string viewName = null)
        where T : class
        {

            IViewEngine viewEngine = new ViewEngine();

            var controlerName = this.GetType().Name.Replace("Controller", string.Empty);
            var html = File.ReadAllText("Views/" + controlerName + "/" + viewName + ".html");
            html = viewEngine.GetHtml(html, null);


            var layout = File.ReadAllText("Views/Shared/_Layout.html");
            var bodyWithLayout = layout.Replace("@RenderBody()", html);
            bodyWithLayout = viewEngine.GetHtml(bodyWithLayout, viewModel);
            return new HtmlResponse(bodyWithLayout);
        }



        protected HttpResponse View([CallerMemberName]string viewName = null)
        {

            return this.View<object>(null, viewName);
        }


    }
}