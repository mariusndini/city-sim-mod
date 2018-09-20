using ICities;
using UnityEngine;
using ColossalFramework.UI;
using ColossalFramework;
using System;

namespace data
{
    class GenInfo
    {
        public string getStats()
        {
            Bindings dataBinding = new Bindings();
            string headers = "population,temperature,cash,gameDate,timeOfDay,";
            string generalInfo = (dataBinding.population + "").Replace(",", "") + ",";
            generalInfo += dataBinding.temperature + ",";
            generalInfo += dataBinding.cash + ",";
            generalInfo += dataBinding.gameTime + ",";
            generalInfo += dataBinding.timeOfDay + ",";

            foreach (StatisticType t in Enum.GetValues(typeof(StatisticType)))
            {
                try
                {
                    StatisticsManager sm = Singleton<StatisticsManager>.instance;
                    StatisticBase sb = sm.Get(t);
                    if (sb != null)
                    {
                        headers += t + ",";
                        generalInfo += sb.GetLatestFloat() + ",";
                    }
                }
                catch
                {

                }
            }//end for

            headers += "savetime";
            generalInfo += DateTime.Now.ToString("h:mm:ss tt");

            return headers + Environment.NewLine + generalInfo;

        }



    }
}
