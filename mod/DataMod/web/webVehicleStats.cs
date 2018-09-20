using System;
using System.Net;
using CityWebServer.Extensibility;

namespace data
{
    class webVehicleStats : RequestHandlerBase
    {
        public webVehicleStats(IWebServer server)
            : base(server, new Guid("3a255904-bf72-406e-b5e2-c5a43fdd9bba"), "webVehicleStats", "Marius", 100, "/webVehicleStats")
        {  
        } 

        public override IResponseFormatter Handle(HttpListenerRequest request)
        {
             
            vehiclestats vehicle = new vehiclestats();
            

            return HtmlResponse(vehicle.getAllVehicles());
        }
    }

}  