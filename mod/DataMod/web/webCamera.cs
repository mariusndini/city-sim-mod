using System;
using System.Net;
using CityWebServer.Extensibility;

namespace data
{
    class webCamera : RequestHandlerBase
    {
        public webCamera(IWebServer server)
            : base(server, new Guid("1a255904-bf72-406e-b5e2-c5a43fdd9bba"), "webCamera", "Marius", 100, "/webCamera")
        {  
        } 

        public override IResponseFormatter Handle(HttpListenerRequest request)
        {
            float zoom = 200f;
            float x;
            float y;
            float z; 

            float.TryParse(request.QueryString["x"], out x);
            float.TryParse(request.QueryString["y"], out y);
            float.TryParse(request.QueryString["z"], out z);
            float.TryParse(request.QueryString["zoom"], out zoom);

            Camera.MoveCamera(zoom, x,y,z, 45f, 45f); 

            return HtmlResponse(zoom + "," +x + "," +y + "," +z);
        }
    }

} 