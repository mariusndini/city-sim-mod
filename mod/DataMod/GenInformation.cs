using ColossalFramework;
using System;


// the namespace makes the names of your classes unique. 
// Naming: You can just use the name of your mod, it doesn't really matter. Spaces are not allowed.
namespace data
{
    public class GeneralInformation
    {
        private string headers = "";
        private string generalInfo = "";
        public GeneralInformation()
        {

        }//nd get general info

        public string getData()
        {
            Bindings dataBinding = new Bindings();
            string headers = "population,temperature,cash,gameDate,timeOfDay<br>";
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

    }//end constructor

    

}




