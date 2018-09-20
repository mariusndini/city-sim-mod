// Makes UnityEngine and Cities: Skylines API classes available for use
using ICities;
using UnityEngine;
using System;



// the namespace makes the names of your classes unique. 
// Naming: You can just use the name of your mod, it doesn't really matter. Spaces are not allowed.
namespace data
{


    // This defines a class that implements IUserMod. 
    // The class defines the name and description displayed in the content manager.
    // The game searches for these classes. Every working mod must contain one class implementing IUserMod.
    // Naming: Just append "Mod" to the name of your mod, like "NetworkSkins" -> "NetworkSkinsMod". Spaces are not allowed.
    public class DatMod: IUserMod
    {
        // this defines the title of your mod displayed in content manager
        public string Name {
            get {
                return "Data Mod";
            } 
        }

        // this defines the description of your mod displayed in content manager
        public string Description {
            get{
                return "Data Transfer Mod - City Data to CSV";
            }
        }
        // END MY FIST MOD Gen Info

    }

}