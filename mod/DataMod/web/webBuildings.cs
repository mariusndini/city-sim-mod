using System;
using System.Net;
using CityWebServer.Extensibility;
using ColossalFramework;
using System.Collections.Generic;

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

            //BuildingData buildings = new BuildingData();
            //return HtmlResponse(buildings.getStats());
            var buildingManager = Singleton<BuildingManager>.instance;

            if (request.Url.AbsolutePath.StartsWith("/Building/List"))
            {
                List<ushort> buildingIDs = new List<ushort>();

                var len = buildingManager.m_buildings.m_buffer.Length;
                for (ushort i = 0; i < len; i++) 
                {
                    if (buildingManager.m_buildings.m_buffer[i].m_flags == Building.Flags.None) { continue; }

                    buildingIDs.Add(i);
                }

                return JsonResponse(buildingIDs);
            }//END IF

            return JsonResponse("");

        }
    }

}   