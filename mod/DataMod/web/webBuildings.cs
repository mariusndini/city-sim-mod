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
            : base(server, new Guid("03897cb0-d53f-4189-a613-e7d22705dc2q"), "webBuilding", "Marius", 100, "/webBuilding")
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