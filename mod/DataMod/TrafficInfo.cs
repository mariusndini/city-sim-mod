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
            
        }//end traffic data

        public string getData()
        {
            string data = "NodeID,Road1,Road2,Road3,Road4,Road5,Road6,Road7,x,y,z" + Environment.NewLine;

            for (int i = 0; i < networks.m_nodes.m_buffer.Length; i++) {
                NetNode thisNode = networks.m_nodes.m_buffer[i];
                if ((thisNode.Info+"").Contains("Road"))
                {
                    UInt16 segment0 = thisNode.m_segment0;
                    UInt16 segment1 = thisNode.m_segment1;
                    UInt16 segment2 = thisNode.m_segment2;
                    UInt16 segment3 = thisNode.m_segment3;
                    UInt16 segment4 = thisNode.m_segment4;
                    UInt16 segment5 = thisNode.m_segment5;
                    UInt16 segment6 = thisNode.m_segment6;
                    UInt16 segment7 = thisNode.m_segment7;

                    Byte trafficDensity0 = networks.m_segments.m_buffer[segment0].m_trafficDensity;
                    Byte trafficDensity1 = networks.m_segments.m_buffer[segment1].m_trafficDensity;
                    Byte trafficDensity2 = networks.m_segments.m_buffer[segment2].m_trafficDensity;
                    Byte trafficDensity3 = networks.m_segments.m_buffer[segment3].m_trafficDensity;
                    Byte trafficDensity4 = networks.m_segments.m_buffer[segment4].m_trafficDensity;
                    Byte trafficDensity5 = networks.m_segments.m_buffer[segment5].m_trafficDensity;
                    Byte trafficDensity6 = networks.m_segments.m_buffer[segment6].m_trafficDensity;
                    Byte trafficDensity7 = networks.m_segments.m_buffer[segment7].m_trafficDensity;

                    data = data + i + "," + trafficDensity0 + "," + trafficDensity1 + "," + trafficDensity2 + "," +
                           trafficDensity3 + "," + trafficDensity4 + "," + trafficDensity5 + "," +
                           trafficDensity6 + "," + trafficDensity7 + "," + thisNode.m_position.x + "," + thisNode.m_position.y
                           + "," + thisNode.m_position.z +Environment.NewLine;

                }


            }

            return data;

        }

    }
}
