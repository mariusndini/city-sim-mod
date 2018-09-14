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
    public class CityLoader : ILoadingExtension
    { 
 
        // called when level is loaded
        public void OnLevelLoaded(LoadMode mode)
        {
            CityInformation ci = new CityInformation();
        }//end get cim data

        // When level created? or load created? 
        public void OnCreated(ILoading loading) { }
        // called when unloading begins
        public void OnLevelUnloading(){}
        // called when unloading finished
        public void OnReleased(){
        }

    }//end city beautifier class

       
}