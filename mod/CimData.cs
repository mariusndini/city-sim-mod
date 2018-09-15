// Makes UnityEngine and Cities: Skylines API classes available for use
using ICities;
using UnityEngine;
using ColossalFramework.UI;
using ColossalFramework;
using System;

namespace data
{
    class CimData
    {
        private int dataLimit = 1500;

        string m = "";

        public string getStats()
        {
            CitizenManager instance = Singleton<CitizenManager>.instance;
            EconomyManager econManager = Singleton<EconomyManager>.instance;

            m = m + "ID,flags,home,work,visiting,health,agegroup,education,wellbeing,gender,subculture,happiness,family,class,name,taxRate" + Environment.NewLine;

            int counter = 0;
            for (int i = 0; i < instance.m_citizens.m_buffer.Length; i++)
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

                    counter++;

                }// end if 

                if (counter > dataLimit)
                {
                    return m;
                }

            }//end for 

            return m;
            

        }

    }
}
