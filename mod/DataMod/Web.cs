using System;
using System.Net;
using CityWebServer.Extensibility;

namespace data
{
    class Web : RequestHandlerBase
    {
        public Web(IWebServer server)
            : base(server, new Guid("1a255904-bf72-406e-b5e2-c5a43fdd9bba"), "MariusSample", "Rychard", 100, "/Marius")
        {   
        } 

        public override IResponseFormatter Handle(HttpListenerRequest request)
        {
            const String content = "SampleMariusPage";
            return HtmlResponse(content);
        }
    }

}