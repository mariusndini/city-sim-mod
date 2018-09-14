using ICities;
using UnityEngine;
using ColossalFramework.UI;

namespace data
{
    public static class SaveData
    {
        static ExceptionPanel panel;

        // PATH WHERE FILES ARE SAVED - only works on windows
        static string path = Application.persistentDataPath;

        //for Mac need to provide full path - is issue with folder permissons 
        //static string path = "/Users/i830729/Library/Application Support/unityColossalSkylines/";
        public static void WriteString(string cim, string bdr, string genInfo, string econInfo, string vehicleData, string districtData)
        {
            string cimDataPath = path + "/cimdata.csv";
            System.IO.File.WriteAllText(cimDataPath, cim);
 
            string buildingDataPath = path + "/buildingdata.csv";
            System.IO.File.WriteAllText(buildingDataPath, bdr);
            
            string genDataPath = path + "/genInfo.csv";
            System.IO.File.WriteAllText(genDataPath, genInfo);

            //string econDataPath = path + "/econdata.csv";
            //System.IO.File.WriteAllText(econDataPath, econInfo);

            string vehiclePath = path + "/vehicledata.csv";
            System.IO.File.WriteAllText(vehiclePath, vehicleData);

            System.IO.File.WriteAllText(path + "/inout.csv", districtData);

        }//end write string

        public static void printPath(){
            panel.SetMessage("City Citizen", "" + "Data Saved -> " + path, false);
             
        }
    }//end writer class
}//end data
