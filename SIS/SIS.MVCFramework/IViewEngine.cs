using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.MVCFramework
{
    public interface IViewEngine
    {

        string GetHtml(string templateHtml, object model);

    }
}
