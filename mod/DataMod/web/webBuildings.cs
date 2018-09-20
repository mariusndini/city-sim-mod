using System;
using System.Net;
using CityWebServer.Extensibility;

namespace data
{
    class webBuildings : RequestHandlerBase
    {
        public webBuildings(IWebServer server)
            : base(server, new Guid("7a255904-bf72-406e-b5e2-c5a43fdd9bba"), "webBuildings", "Marius", 100, "/webBuildings")
        {  
        } 

        public override IResponseFormatter Handle(HttpListenerRequest request)
        {

            BuildingData buildings = new BuildingData();

            return HtmlResponse(buildings.getStats());
        }
    }

}   