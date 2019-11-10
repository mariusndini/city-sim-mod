using System;
using ICities;
using UnityEngine;
using ColossalFramework.UI;
using System.IO;

namespace data
{
    public static class SaveData
    {
       

        // PATH WHERE FILES ARE SAVED - only works on windows
        static string path = "C:\\Users\\marius\\Documents\\GitHub\\city-sim-mod\\data"; //Application.persistentDataPath;
        static int counter = 0;

        //for Mac need to provide full path - is issue with folder permissons 
        //static string path = "/Users/i830729/Library/Application Support/unityColossalSkylines/";
        public static void WriteString(int cnt, string cim, string bdr, string genInfo, string allCarsInfo, string vehicleData, string incomeData, string trafficData, string districtData)
        {


            System.IO.File.WriteAllText(path + "/cimdata_" + cnt + ".csv", cim);
            System.IO.File.WriteAllText(path + "/buildingdata_" + cnt + ".csv", bdr);
            System.IO.File.WriteAllText(path + "/genInfo_" + cnt + ".csv", genInfo);
            System.IO.File.WriteAllText(path + "/allcarsdata_" + cnt + ".csv", allCarsInfo);
            System.IO.File.WriteAllText(path + "/vehicledata_" + cnt + ".csv", vehicleData);
            System.IO.File.WriteAllText(path + "/income_" + cnt + ".csv", incomeData);
            System.IO.File.WriteAllText(path + "/traffic_" + cnt + ".csv", trafficData);
            System.IO.File.WriteAllText(path + "/district_" + cnt + ".csv", districtData);

        }//end write string

        public static void getData()
        {
            ExceptionPanel p2;
            p2 = UIView.library.ShowModal<ExceptionPanel>("ExceptionPanel");

            StreamReader file = new StreamReader("C:/Cities/cmd" + counter + ".csv");
            string line;

            line = file.ReadLine();
            p2.SetMessage("City Citizen", "Command - " + line, false);
            file.Close();

            counter++;

        }
       
    }//end writer class
}//end data
