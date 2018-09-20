using System;
using System.Net;
using CityWebServer.Extensibility;

namespace data
{
    class webTrafficData : RequestHandlerBase
    {
        public webTrafficData(IWebServer server)
            : base(server, new Guid("2a255904-bf72-406e-b5e2-c5a43fdd9bba"), "webTrafficData", "Marius", 100, "/webTrafficData")
        {  
        } 

        public override IResponseFormatter Handle(HttpListenerRequest request)
        {
            string content = "Error";
            TrafficInfo ti = new TrafficInfo();
            content = ti.getData();

            return HtmlResponse(content);
        }
    }

}