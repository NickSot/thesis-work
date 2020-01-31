using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class PacketInformation
    {
        public string Orig_H { get; set; }
        public int Orig_P { get; set; }
        public string Resp_H { get; set; }
        public int Resp_P { get; set; }
        public string Proto { get; set; }
        public string Service { get; set; }
        public double Duration { get; set; }
        public long Orig_Bytes { get; set; }
        public string Conn_State { get; set; }
        public bool Local_Orig { get; set; }
        public bool Local_Resp { get; set; }
        public int Missed_Bytes{ get; set; }
        public string History { get; set; }
        public int Orig_Packets { get; set; }
        public int Resp_IP_Bytes{ get; set; }
        public int Resp_Packets { get; set; }
        public int Orig_IP_Bytes { get; set; }
        public SortedSet<string> Tunnel_Parents{ get; set; }
    }
}
