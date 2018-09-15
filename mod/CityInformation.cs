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

        CameraController camera = GameObject.FindObjectOfType<CameraController>();

        // called when level is loaded
        public CityInformation()
        {
            panel = UIView.library.ShowModal<ExceptionPanel>("ExceptionPanel");
            panel.SetMessage("City Citizen", "" + "City Loaded - " + Application.persistentDataPath , false);




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

        public void getData(object stateInfo)
        {
            camera.m_targetSize = 250;
            camera.m_targetPosition = new Vector3(215.157f, 246.2631f, 285.6922f);
            camera.m_targetAngle = new Vector3(45, 45); 

            vehiclestats vehicle = new vehiclestats();
            DistrictStats districts = new DistrictStats();
            incomeExpenseStats inoutSats = new incomeExpenseStats();
            GenInfo geninfo = new GenInfo();
            CimData cimdata = new CimData();
            BuildingData buildings = new BuildingData();

            SaveData.WriteString(cimdata.getStats(), buildings.getStats(), geninfo.getStats(), vehicle.getAllVehicles(), vehicle.getStats(), inoutSats.doPoll() );
        }//end get Data

         
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