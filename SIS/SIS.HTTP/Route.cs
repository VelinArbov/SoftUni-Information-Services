using System;
using SIS.HTTP;
using SIS.HTTP.Enums;

public class Route
{

    public Route(string path, HttpMethodType httpMethod, Func<HttpRequest, HttpResponse> action)
    {
        this.Path = path;
        this.HttpMethod = httpMethod;
        this.Action = action;
    }

    public string Path { get; set; }

    public HttpMethodType HttpMethod { get; set; }

    public Func<HttpRequest, HttpResponse> Action { get; set; }

    public override string ToString()
    {
        return $"{this.HttpMethod} => {this.Path}";
    }
}