﻿using System;
using System.Net;
using CityWebServer.Extensibility;
using CityWebServer.Extensibility.Responses;
using ColossalFramework;

namespace CityWebServer.RequestHandlers
{
    public class BudgetRequestHandler : RequestHandlerBase
    {
        public BudgetRequestHandler(IWebServer server)
            : base(server, new Guid("87205a0d-1b53-47bd-91fa-9cddf0a3bd9e"), "Budget", "Marius", 100, "/Budget")
        {
        }

        public override IResponseFormatter Handle(HttpListenerRequest request)
        {
            // TODO: Expand upon this to expose substantially more information.
            var economyManager = Singleton<EconomyManager>.instance;
            long income;
            long expenses;
            economyManager.GetIncomeAndExpenses(new ItemClass(), out income, out expenses);

            Decimal formattedIncome = Math.Round(((Decimal)income / 100), 2);
            Decimal formattedExpenses = Math.Round(((Decimal)expenses / 100), 2);

            var content = String.Format("Income: {0:C}{2}Expenses: {1:C}", formattedIncome, formattedExpenses, Environment.NewLine);

            return new PlainTextResponseFormatter(content, HttpStatusCode.OK);
        }
    }
}