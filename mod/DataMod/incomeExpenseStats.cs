using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using ColossalFramework;
using ColossalFramework.Globalization;
using ColossalFramework.UI;
using ICities;


namespace data
{
    class incomeExpenseStats
    {
        private static IncomeExpensesPoll[] basicExpensesPolls;

        public string doPoll()
        {
            string myData = "Service,sub,lvl,Income,Expense" + Environment.NewLine;

            for (int i = 0; i < basicExpensesPolls.Length; i++)
            {
                basicExpensesPolls[i].Poll(Settings.moneyFormat, LocaleManager.cultureInfo);
                myData = myData + basicExpensesPolls[i].service + "," + basicExpensesPolls[i].income + "," + basicExpensesPolls[i].expenses + Environment.NewLine;

            }

            return myData;
        }

        public incomeExpenseStats()
        {
            InitializePolls();
        }

        private static void InitializePolls()
        {
            basicExpensesPolls = new IncomeExpensesPoll[]
            {
                new IncomeExpensesPoll(ItemClass.Service.Electricity, null, null),
                new IncomeExpensesPoll(ItemClass.Service.Water, null, null),
                new IncomeExpensesPoll(ItemClass.Service.Garbage, null, null),
                new IncomeExpensesPoll(ItemClass.Service.HealthCare, null, null),
                new IncomeExpensesPoll(ItemClass.Service.FireDepartment, null, null),
                new IncomeExpensesPoll(ItemClass.Service.PoliceDepartment, null, null),
                new IncomeExpensesPoll(ItemClass.Service.Education, null, null),
                new IncomeExpensesPoll(ItemClass.Service.Monument, null, null),
                new IncomeExpensesPoll(ItemClass.Service.Beautification, null, null),
                new IncomeExpensesPoll(ItemClass.Service.Road, null, null),

                new IncomeExpensesPoll(ItemClass.Service.None, null, null),
                new IncomeExpensesPoll(ItemClass.Service.Residential, null, null),
                new IncomeExpensesPoll(ItemClass.Service.Commercial, null, null),
                new IncomeExpensesPoll(ItemClass.Service.Industrial, null, null),
                new IncomeExpensesPoll(ItemClass.Service.Office, null, null),
                new IncomeExpensesPoll(ItemClass.Service.PublicTransport, null, null),
                new IncomeExpensesPoll(ItemClass.Service.Residential, ItemClass.SubService.ResidentialLow, null, null),
                new IncomeExpensesPoll(ItemClass.Service.Residential, ItemClass.SubService.ResidentialHigh, null, null),
                new IncomeExpensesPoll(ItemClass.Service.Commercial, ItemClass.SubService.CommercialLow, null, null),
                new IncomeExpensesPoll(ItemClass.Service.Commercial, ItemClass.SubService.CommercialHigh, null, null),
                new IncomeExpensesPoll(ItemClass.Service.Tourism, null, null),
                new IncomeExpensesPoll(ItemClass.Service.Citizen, null, null),

                new IncomeExpensesPoll(ItemClass.Service.PublicTransport, ItemClass.SubService.PublicTransportMetro, null, null),
                new IncomeExpensesPoll(ItemClass.Service.PublicTransport, ItemClass.SubService.PublicTransportTrain, null, null),
                new IncomeExpensesPoll(ItemClass.Service.PublicTransport, ItemClass.SubService.PublicTransportShip, null, null),
                new IncomeExpensesPoll(ItemClass.Service.PublicTransport, ItemClass.SubService.PublicTransportPlane, null, null)

            };
        }//end init



        private sealed class IncomeExpensesPoll
        {
            private ItemClass.Service m_Service;
            private ItemClass.SubService m_SubService;
            private ItemClass.Level m_Level;
            private long m_Income = 9223372036854775807L;
            private long m_Expenses = 9223372036854775807L;
            private string m_IncomeString = "N/A";
            private string m_ExpensesString = "N/A";
            private bool m_Bound;
            private string m_IncomeFieldName;
            private string m_ExpensesFieldName;
            public string incomeString
            {
                get
                {
                    return this.m_IncomeString;
                }
            }

            public string service
            {
                get
                {
                    return this.m_Service.ToString()+","+ m_SubService.ToString() +","+m_Level;
                }
            }

            public string expensesString
            {
                get
                {
                    return this.m_ExpensesString;
                }
            }
            public double income
            {
                get
                {
                    return (double)this.m_Income;
                }
            }
            public double expenses
            {
                get
                {
                    return (double)this.m_Expenses;
                }
            }
            public IncomeExpensesPoll(ItemClass.Service service, string incomeFieldName, string expensesFieldName)
            {
                this.m_Service = service;
                this.m_SubService = ItemClass.SubService.None;
                this.m_Level = ItemClass.Level.None;
                this.m_ExpensesFieldName = expensesFieldName;
            }
            public IncomeExpensesPoll(ItemClass.Service service, ItemClass.SubService subService, string incomeFieldName, string expensesFieldName)
            {
                this.m_Service = service;
                this.m_SubService = subService;
                this.m_Level = ItemClass.Level.None;
                this.m_ExpensesFieldName = expensesFieldName;
            }
            public IncomeExpensesPoll(ItemClass.Service service, ItemClass.SubService subService, ItemClass.Level level, string incomeFieldName, string expensesFieldName)
            {
                this.m_Service = service;
                this.m_SubService = subService;
                this.m_Level = level;
                this.m_ExpensesFieldName = expensesFieldName;
            }
            public void Poll(string moneyFormat, CultureInfo moneyLocale)
            {
                long num = 0L;
                long num2 = 0L;
                if (Singleton<EconomyManager>.exists)
                {
                    Singleton<EconomyManager>.instance.GetIncomeAndExpenses(this.m_Service, this.m_SubService, this.m_Level, out num, out num2);
                }
                if (num != this.m_Income)
                {
                    this.m_Income = num;
                    this.m_IncomeString = ((double)this.m_Income / 100.0).ToString(moneyFormat, moneyLocale);
                }
                if (num2 != this.m_Expenses)
                {
                    this.m_Expenses = num2;
                    this.m_ExpensesString = ((double)this.m_Expenses / 100.0).ToString(moneyFormat, moneyLocale);
                }
            }


        }

    }


    


}
