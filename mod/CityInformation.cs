// Makes UnityEngine and Cities: Skylines API classes available for use
using ICities;
using UnityEngine;
using ColossalFramework.UI;
using ColossalFramework;
using System;
using System.IO;
using System.Threading;


// the namespace makes the names of your classes unique. 
// Naming: You can just use the name of your mod, it doesn't really matter. Spaces are not allowed.
namespace data
{
    public class CityInformation
    {
        static ExceptionPanel panel;
        Thread bgThread;

        static string m;
        static string d;
        static string econInfo;

        // called when level is loaded
        public CityInformation()
        {
            panel = UIView.library.ShowModal<ExceptionPanel>("ExceptionPanel");
            panel.SetMessage("City Citizen", "" + "City Loaded - " + Application.persistentDataPath , false);

            //NetWorking nw = new NetWorking();

            //threads runs in BG to save data to file service
            bgThread = new Thread(() =>
            {
                var autoEvent = new AutoResetEvent(true);

                //calls get Data on a timer
                System.Threading.Timer myTimer = new System.Threading.Timer(getData, autoEvent, 1000, 5000);
                autoEvent.WaitOne();
                myTimer.Change(0, 3000);

            });
            bgThread.IsBackground = true;
            bgThread.Start();
        }//end on level loaded 

        public static void getData(object stateInfo)
        {
            m = "";
            d = "";
            econInfo = "";

            vehiclestats vehicle = new vehiclestats();
            DistrictStats districts = new DistrictStats();
            incomeExpenseStats inoutSats = new incomeExpenseStats();

            getCimData();
            getBuildingData();
            //getEconData();//can be removed

            SaveData.WriteString(m, d, getGeneralInfo(), "", vehicle.getStats(), inoutSats.doPoll() );
        }//end get Data

        static public void getBuildingData()
        {
            BuildingManager instance = Singleton<BuildingManager>.instance;
            // CSV Headers
            //      |     Gen Info                                     |                    service problems                   |
            d = d + "id, flags, type, happiness, health, youngs, teens, adults, seniors, p_electric, p_heating, p_water, p_worker, p_health, p_service, p_tax, x,y,z" + Environment.NewLine;

            //BuildingManager bm = Singleton<BuildingManager>.instance; 
            for (int i = 0; i < 1500 /*instance.m_buildings.m_buffer.Length*/; i++)
            {

                if (!instance.m_buildings.m_buffer[i].m_flags.IsFlagSet(Building.Flags.Created)) continue;
                if (instance.m_buildings.m_buffer[i].m_flags.IsFlagSet(Building.Flags.Original)) continue;
                if (instance.m_buildings.m_buffer[i].m_flags.IsFlagSet(Building.Flags.Untouchable)) continue;
                if (instance.m_buildings.m_buffer[i].m_flags.IsFlagSet(Building.Flags.Deleted)) continue;

                var building = instance.m_buildings.m_buffer[i];
                //if (building.m_citizenCount > 0)
                {
                    d = d + i + ",";
                    d = d + (building.m_flags + "").Replace(",", "-") + ",";
                    d = d + building.Info + ",";

                    d = d + building.m_happiness + ",";
                    d = d + building.m_health + ",";
                    d = d + building.m_youngs + ",";
                    d = d + building.m_teens + ",";
                    d = d + building.m_adults + ",";
                    d = d + building.m_seniors + ",";

                    d = d + building.m_electricityProblemTimer + ",";
                    d = d + building.m_heatingProblemTimer + ",";
                    d = d + building.m_waterProblemTimer + ",";
                    d = d + building.m_workerProblemTimer + ",";
                    d = d + building.m_healthProblemTimer + ",";
                    d = d + building.m_serviceProblemTimer + ",";
                    d = d + building.m_taxProblemTimer + ",";

                    d = d + building.m_position.x + ",";
                    d = d + building.m_position.y + ",";
                    d = d + building.m_position.z + Environment.NewLine;

                }
            }//end loop through buildings

        }//end get building data

        static public string getGeneralInfo()
        { 

            Bindings dataBinding = new Bindings();
            string headers = "population,temperature,cash,gameDate,timeOfDay,";
            string generalInfo = (dataBinding.population+"").Replace(",", "")  + ",";
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



        }//end get general info

        static public void getEconData()
        {
            EconomyManager econManager = Singleton<EconomyManager>.instance;
            long income;
            long expenses;
            econManager.GetIncomeAndExpenses(new ItemClass(), out income, out expenses);
            Decimal formattedIncome = Math.Round(((Decimal)income) / 100, 2);
            Decimal formattedExpenses = Math.Round(((Decimal)expenses) / 100, 2);


             
            econInfo = "cityincome,cityexpenses,policyexpenses,budget, resi, resi" + Environment.NewLine;
            econInfo = econInfo + formattedIncome + ",";
            econInfo = econInfo + formattedExpenses + ",";

            econManager.GetIncomeAndExpenses(new ItemClass(), out income, out expenses);

            econInfo = econInfo + econManager.GetPolicyExpenses() + ",";
            econInfo = econInfo + econManager.GetBudget(new ItemClass()) + Environment.NewLine;


        }

        //gets all Cims in the game 
        static public void getCimData()
        {

            CitizenManager instance = Singleton<CitizenManager>.instance;
            EconomyManager econManager = Singleton<EconomyManager>.instance;

            m = m + "ID,flags,home,work,visiting,health,agegroup,education,wellbeing,gender,subculture,happiness,family,class,name,taxRate" + Environment.NewLine;

            for (int i = 0; i < 1500 /*instance.m_citizens.m_size*/; i++)
            {

                Citizen ci = instance.m_citizens.m_buffer[i];
                uint ciInt = ci.m_instance;
                CitizenInfo ciInfo = ci.GetCitizenInfo(ciInt);


                //only get citizens that live in our city -> the list includes tourists etc
                if (instance.m_citizens.m_buffer[i].m_flags != 0 && !ci.Dead && ci.m_homeBuilding > 0)
                {
                    m = m + ciInt + "," +
                            (ci.m_flags + "").Replace(",", "-") + "," +
                            ci.m_homeBuilding + "," +
                            ci.m_workBuilding + "," +
                            ci.m_visitBuilding + "," +
                            Citizen.GetHealthLevel(ci.m_health) + "," +
                            Citizen.GetAgeGroup(ci.Age) + "," +
                            ci.EducationLevel + "," +
                            ci.m_wellbeing + "," +
                            ciInfo.m_gender + "," +
                            ciInfo.m_subCulture + "," +
                            Citizen.GetHappinessLevel(Citizen.GetHappiness(ci.m_health, ci.m_wellbeing)) + "," +
                            ci.m_family + "," +
                            ciInfo.m_class + "," +
                            instance.GetInstanceName((ushort)ciInt) + "," +
                            econManager.GetTaxRate(ciInfo.m_class) + 
                            Environment.NewLine;
 
                }// end if 

            }//end for 

        }//end get cim data


         
        // When level created? or load created? 
        public void OnCreated(ILoading loading) { }
        // called when unloading begins
        public void OnLevelUnloading()
        {
            bgThread.Abort();
        }
        // called when unloading finished
        public void OnReleased()
        {
            bgThread.Abort();
        }

    }//end city  class











}//end namespace