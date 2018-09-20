using ICities;
using UnityEngine;
using ColossalFramework.UI;
using ColossalFramework;
using System;

namespace data
{
    class TrafficInfo
    {
        NetManager networks;
        NetNode node;
        public TrafficInfo(){
            networks = Singleton<NetManager>.instance;
            node = networks.m_nodes.m_buffer[9217];
            
        }//end traffic data

        public string getData()
        {
            string data = "NodeID, Road1, Road2, Road3, Road4" + Environment.NewLine;

            for (int i = 0; i < networks.m_nodes.m_buffer.Length; i++) {
                NetNode thisNode = networks.m_nodes.m_buffer[i];
                if ((thisNode.Info+"").Contains("Road"))
                {
                    UInt16 segment0 = thisNode.m_segment0;
                    UInt16 segment1 = thisNode.m_segment1;
                    UInt16 segment2 = thisNode.m_segment2;
                    UInt16 segment3 = thisNode.m_segment3;

                    Byte trafficDensity0 = networks.m_segments.m_buffer[segment0].m_trafficDensity;
                    Byte trafficDensity1 = networks.m_segments.m_buffer[segment1].m_trafficDensity;
                    Byte trafficDensity2 = networks.m_segments.m_buffer[segment2].m_trafficDensity;
                    Byte trafficDensity3 = networks.m_segments.m_buffer[segment3].m_trafficDensity;
                    
                    data = data + i+","+trafficDensity0 + ","+ trafficDensity1 + ","+ trafficDensity2 + "," + trafficDensity3 + Environment.NewLine;

                }


            }


            //Byte trafficDensity0 = networks.m_segments.m_buffer[segment0].m_trafficDensity;
            //Byte trafficDensity1 = networks.m_segments.m_buffer[segment1].m_trafficDensity;
            //Byte trafficDensity2 = networks.m_segments.m_buffer[segment2].m_trafficDensity;
            //Byte trafficDensity3 = networks.m_segments.m_buffer[segment3].m_trafficDensity;

            return data;

        }

    }
}
