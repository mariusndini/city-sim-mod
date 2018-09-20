using System;
using System.Net;
using CityWebServer.Extensibility;

namespace data
{
    class webIncome : RequestHandlerBase
    {
        public webIncome(IWebServer server)
            : base(server, new Guid("4a255904-bf72-406e-b5e2-c5a43fdd9bba"), "webIncome", "Marius", 100, "/webIncome")
        {  
        } 

        public override IResponseFormatter Handle(HttpListenerRequest request)
        {

            incomeExpenseStats inoutSats = new incomeExpenseStats();


            return HtmlResponse(inoutSats.doPoll());
        }
    }

}  