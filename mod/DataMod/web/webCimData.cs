using System;
using System.Net;
using CityWebServer.Extensibility;

namespace data
{
    class webCimData : RequestHandlerBase
    {
        public webCimData(IWebServer server)
            : base(server, new Guid("9a255904-bf72-406e-b5e2-c5a43fdd9bba"), "webCimData", "Marius", 100, "/webCimData")
        {  
        } 
         
        public override IResponseFormatter Handle(HttpListenerRequest request)
        {

            CimData cimdata = new CimData();

            return HtmlResponse(cimdata.getStats());
        }
    }

}  