using ICities;
using UnityEngine;
using ColossalFramework.UI;
using System.IO;

namespace data
{
    public static class SaveData
    {
       

        // PATH WHERE FILES ARE SAVED - only works on windows
        static string path = "C:\\citydata"; //Application.persistentDataPath;
        static int counter = 0;

        //for Mac need to provide full path - is issue with folder permissons 
        //static string path = "/Users/i830729/Library/Application Support/unityColossalSkylines/";
        public static void WriteString(string cim, string bdr, string genInfo, string allCarsInfo, string vehicleData, string districtData, string trafficData)
        {
            string cimDataPath = path + "/cimdata.csv";
            System.IO.File.WriteAllText(cimDataPath, cim);
 
            string buildingDataPath = path + "/buildingdata.csv";
            System.IO.File.WriteAllText(buildingDataPath, bdr);
            
            string genDataPath = path + "/genInfo.csv";
            System.IO.File.WriteAllText(genDataPath, genInfo);

            string allcarsDataPath = path + "/allcarsdata.csv";
            System.IO.File.WriteAllText(allcarsDataPath, allCarsInfo);

            string vehiclePath = path + "/vehicledata.csv";
            System.IO.File.WriteAllText(vehiclePath, vehicleData);

            System.IO.File.WriteAllText(path + "/inout.csv", districtData);

            System.IO.File.WriteAllText(path + "/traffic.csv", trafficData);

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
