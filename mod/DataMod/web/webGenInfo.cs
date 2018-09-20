using System;
using System.Net;
using CityWebServer.Extensibility;

namespace data
{
    class webGenInfo : RequestHandlerBase
    {
        public webGenInfo(IWebServer server)
            : base(server, new Guid("8a255904-bf72-406e-b5e2-c5a43fdd9bba"), "webGenInfo", "Marius", 100, "/webGenInfo")
        {  
        } 

        public override IResponseFormatter Handle(HttpListenerRequest request)
        {

            GenInfo geninfo = new GenInfo();
             

            return HtmlResponse(geninfo.getStats());
        }
    }

}  