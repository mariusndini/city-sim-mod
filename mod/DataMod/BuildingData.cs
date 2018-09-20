// Makes UnityEngine and Cities: Skylines API classes available for use
using ICities;
using UnityEngine;
using ColossalFramework.UI;
using ColossalFramework;
using System;

namespace data
{
    class BuildingData
    {
        private int dataLimit = 1500;

        string d = "";

        public string getStats()
        {
            BuildingManager instance = Singleton<BuildingManager>.instance;
            // CSV Headers
            //      |     Gen Info                                     |                    service problems                   |
            d = d + "id, flags, type, happiness, health, youngs, teens, adults, seniors, p_electric, p_heating, p_water, p_worker, p_health, p_service, p_tax, x,y,z" + Environment.NewLine;

            int count = 0;
            for (int i = 0; i < instance.m_buildings.m_buffer.Length; i++)
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
                    count++;
                }
                if (count>dataLimit)
                {
                    return d;
                }
            }//end loop through buildings

            return d;
        }//end get stats


    }
}
