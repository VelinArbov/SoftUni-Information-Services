using System;
using System.Collections.Generic;
using System.Text;
using SIS.HTTP.Enums;

namespace SIS.MVCFramework
{
    public class HttpGetAttribute : HttpMethodAttribute
    {
        public HttpGetAttribute()
        {
            
        }

        public HttpGetAttribute(string url):base(url)
        {
        }


        public override HttpMethodType Type => HttpMethodType.Get;

    }
   
}
