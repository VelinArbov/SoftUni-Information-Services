using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SIS.HTTP
{
    public class HttpServer : IHttpServer
    {
        private readonly IList<Route> routeTable;
        private readonly TcpListener tcpListener;
        //TODO: actions 
        public HttpServer(int port, IList<Route> routeTable)
        {
            this.routeTable = routeTable;
            this.tcpListener = new TcpListener(IPAddress.Loopback, port);
        }

        public async Task StartAsync()
        {
            this.tcpListener.Start();
            while (true)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();

                await Task.Run(() => ProcessClientAsync(tcpClient));




            }
        }

        public async Task ResetAsync()
        {
            this.Stop();
            await this.StartAsync();
        }

        public void Stop()
        {
            this.tcpListener.Stop();
        }


        private async Task ProcessClientAsync(TcpClient tcpClient)
        {
            using NetworkStream networkStream = tcpClient.GetStream();
            try
            {


                byte[] requestBytes = new byte[1000000]; // TODO: Use buffer
                int bytesRead = await networkStream.ReadAsync(requestBytes, 0, requestBytes.Length);
                string requestAsString = Encoding.UTF8.GetString(requestBytes, 0, bytesRead);


                var request = new HttpRequest(requestAsString);
                var route = this.routeTable.FirstOrDefault(
                    x => x.HttpMethod == request.Method
                    && x.Path == request.Path);
                HttpResponse response;
                if (route == null)
                {
                    response = new HttpResponse(HttpResponseCode.NotFound, new byte[0]);

                }
                else
                {
                    response = route.Action(request);
                }


                response.Headers.Add(new Header("Server", "SoftUniServer/1.0"));
                response.Cookies.Add(new ResponseCookie("SessionId", Guid.NewGuid().ToString())
                { HttpOnly = true, MaxAge = 3600 });

                var responseBytes = Encoding.UTF8.GetBytes(response.ToString());
                await networkStream.WriteAsync(responseBytes, 0, responseBytes.Length);
                await networkStream.WriteAsync(response.Body, 0, response.Body.Length);
                Console.WriteLine(request);
                Console.WriteLine(new string('=', 60));
            }
            catch (Exception ex)
            {
                var errorResponseCode = new HttpResponse(
                    HttpResponseCode.InternalServerError,
                    Encoding.UTF8.GetBytes(ex.Message));
                errorResponseCode.Headers.Add(new Header("Content-Type", "text/plain"));

                var responseBytes = Encoding.UTF8.GetBytes(errorResponseCode.ToString());
                await networkStream.WriteAsync(responseBytes, 0, responseBytes.Length);
                await networkStream.WriteAsync(errorResponseCode.Body, 0, errorResponseCode.Body.Length);
            }
        }




    }
}
