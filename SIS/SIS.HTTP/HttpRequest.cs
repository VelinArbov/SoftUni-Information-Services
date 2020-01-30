

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using SIS.HTTP.Enums;
using SIS.HTTP.Exceptions;

namespace SIS.HTTP
{
    public class HttpRequest
    {
        public HttpRequest(string httpRequestAsString)
        {
            this.Headers = new List<Header>();
            this.Cookies= new List<Cookie>();

            var lines = httpRequestAsString.Split(
                new string[] { GlobalConstants.NewLine },
                StringSplitOptions.None);
            var httpInfoHeader = lines[0];
            var infoHeaderParts = httpInfoHeader.Split(' ');
            if (infoHeaderParts.Length != 3)
            {
                throw new HttpServerException("Invalid HTTP header line.");
            }




            var httpMethod = infoHeaderParts[0];
            //  Enum.TryParse(httpMethod, true, out HttpMethodType result);
            this.Method = httpMethod switch
            {
                "POST" => HttpMethodType.Post,
                "GET" => HttpMethodType.Get,
                "PUT" => HttpMethodType.Put,
                "DELETE" => HttpMethodType.Delete,
                _ => HttpMethodType.Unknown

            };



            this.Path = infoHeaderParts[1];
            var httpVersionType = infoHeaderParts[2];
            this.Version = httpVersionType switch
            {
                "HTTP/1.0" => HttpVersionType.Http10,
                "HTTP/1.1" => HttpVersionType.Http11,
                "HTTP/2.0" => HttpVersionType.Http20,
                _ => HttpVersionType.Http11

            };


            bool isInHeader = true;

            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                StringBuilder bodyBuilder = new StringBuilder();
                if (string.IsNullOrEmpty(line))
                {
                    isInHeader = false;
                    continue;
                }

                if (isInHeader)
                {
                    var headerParts = line.Split(new string[] {": "},2, StringSplitOptions.None);
                    if (headerParts.Length != 2)
                    {
                        throw  new HttpServerException($"Invalid header: {line}");
                    }

                    var header = new Header(headerParts[0],headerParts[1]);
                    this.Headers.Add(header);
                    if (headerParts[0] == "Cookie")
                    {
                        var cookiesAsString = headerParts[1];
                        var cookies = cookiesAsString.Split(new string[] {"; "}, StringSplitOptions.RemoveEmptyEntries);


                        foreach (var cookieAsString in cookies)
                        {
                         
                            var cookieParts =cookieAsString.Split(new char[]{'='},2);
                            if(cookieParts.Length == 2)
                            {
                                this.Cookies.Add(new Cookie(cookieParts[0],cookieParts[1]));
                            }


                        }
                        


                    }
                }
                else
                {
                    bodyBuilder.AppendLine(line);



                }


            }




        }


        public HttpMethodType Method { get; set; }


        public string Path { get; set; }

        public HttpVersionType Version { get; set; }


        public ICollection<Header> Headers { get; set; }

        public IList<Cookie> Cookies { get; set; }


        public string Body { get; set; }


    }
}
