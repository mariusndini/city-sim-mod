/*using ICities;
using UnityEngine;
using ColossalFramework;
using System;
using System.Globalization;
using ColossalFramework.Globalization;
using System.Collections.Generic;

namespace data
{
    public class DistrictStats
    {
        public double waterbuffer = 0, sewagebuffer = 0, watercapacity = 0, sewagecapacity = 0, garbage = 0;
        public int dmcount = 0, dmusage = 0, dmproduction = 0, deadamount = 0;
        public int finalcrimerate = 0, citizencount = 0, sickcount = 0, groundpollution = 0;
        public int dmincome = 0, education1rate = 0, education2rate = 0, education3rate = 0,
            educated0 = 0, educated1 = 0, educated2 = 0, educated3 = 0;
        public List<DistrictEducationData> educationData = new List<DistrictEducationData>();

        string data;

        public DistrictStats()
        {
            DistrictManager dm = Singleton<DistrictManager>.instance;
            int i = 0;
            //for (int i = 0; i < dm.m_districts.m_size; i++)
            {
                //if (!dm.m_districts.m_buffer[i].m_flags.IsFlagSet(District.Flags.Created)) continue;
                //if (dm.m_districts.m_buffer[i].m_flags.IsFlagSet(District.Flags.CustomName)) continue;
                //citizencount += (int)dm.m_districts.m_buffer[i].m_populationData.m_finalCount;

                int localcitizencount = (int)(dm.m_districts.m_buffer[i].m_adultData.m_finalCount
                    + dm.m_districts.m_buffer[i].m_childData.m_finalCount
                    + dm.m_districts.m_buffer[i].m_youngData.m_finalCount
                    + dm.m_districts.m_buffer[i].m_teenData.m_finalCount
                    + dm.m_districts.m_buffer[i].m_seniorData.m_finalCount);
                groundpollution += dm.m_districts.m_buffer[i].GetGroundPollution();
                dmcount++;
                citizencount += localcitizencount;
                dmusage += dm.m_districts.m_buffer[i].GetElectricityConsumption();
                dmproduction += dm.m_districts.m_buffer[i].GetElectricityCapacity();
                waterbuffer += dm.m_districts.m_buffer[i].GetWaterConsumption();
                sewagebuffer += dm.m_districts.m_buffer[i].GetSewageAccumulation();
                sewagecapacity += dm.m_districts.m_buffer[i].GetSewageCapacity();
                watercapacity += dm.m_districts.m_buffer[i].GetWaterCapacity();
                garbage += dm.m_districts.m_buffer[i].GetGarbageAccumulation();
                sickcount += dm.m_districts.m_buffer[i].GetSickCount();
                finalcrimerate += (int)dm.m_districts.m_buffer[i].m_finalCrimeRate;
                dmincome += (int)dm.m_districts.m_buffer[i].GetIncomeAccumulation();
                //deadamount += (int)dm.m_districts.m_buffer[i].GetDeadAmount();
                deadamount += (int)dm.m_districts.m_buffer[i].GetDeadCount();
                education1rate = (int)dm.m_districts.m_buffer[i].GetEducation1Rate();
                education2rate = (int)dm.m_districts.m_buffer[i].GetEducation2Rate();
                education3rate = (int)dm.m_districts.m_buffer[i].GetEducation3Rate();
                educated0 = (int)dm.m_districts.m_buffer[i].m_educated0Data.m_finalCount;
                educated1 = (int)dm.m_districts.m_buffer[i].m_educated1Data.m_finalCount;
                educated2 = (int)dm.m_districts.m_buffer[i].m_educated2Data.m_finalCount;
                educated3 = (int)dm.m_districts.m_buffer[i].m_educated3Data.m_finalCount;
                educationData.Add(dm.m_districts.m_buffer[i].m_educated0Data);
                educationData.Add(dm.m_districts.m_buffer[i].m_educated1Data);
                educationData.Add(dm.m_districts.m_buffer[i].m_educated2Data);
                educationData.Add(dm.m_districts.m_buffer[i].m_educated3Data);


                data = waterbuffer + "," + sewagebuffer + "," + watercapacity + "," + sewagecapacity + "," + garbage + "," + dmcount + "," + dmusage + "," + dmproduction + "," + deadamount + "," + finalcrimerate + "," + citizencount + "," + sickcount + "," + groundpollution + "," + dmincome + "," + education1rate + "," + education2rate + "," + education3rate + "," + educated0 + "," + educated1 + "," + educated2 + "," + educated3;


            }

        }

        public string getStats()
        {
            string header = "waterbuffer,sewagebuffer,watercapacity,sewagecapacity,garbage,dmcount,dmusage,dmproduction,deadamount,finalcrimerate,citizencount,sickcount,groundpollution,dmincome,education1rate,education2rate,education3rate,educated0,educated1,educated2,educated3";

            return header + Environment.NewLine + data;

        }//end get stats method

    }//end class
     

}
*/