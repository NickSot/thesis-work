using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Project
{
    class InputDataPreparator
    {
        Dictionary<string, int> protocolMap = new Dictionary<string, int>();
        Dictionary<string, int> connStateMap = new Dictionary<string, int>();
        Dictionary<string, int> historyMap = new Dictionary<string, int>();

        private List<PacketInformation> rawInputData;

        public InputDataPreparator(List<PacketInformation> rawInputData)
        {
            this.rawInputData = rawInputData;

            protocolMap.Add("tcp", 1);
            protocolMap.Add("udp", 2);
            protocolMap.Add("ip", 3);
            protocolMap.Add("icmp", 4);

            connStateMap.Add("S0", 1);
            connStateMap.Add("S1", 2);
            connStateMap.Add("SF", 3);
            connStateMap.Add("REJ", 4);
            connStateMap.Add("S2", 5);
            connStateMap.Add("S3", 6);
            connStateMap.Add("RSTO", 7);
            connStateMap.Add("RSTR", 8);
            connStateMap.Add("RSTOS0", 9);
            connStateMap.Add("RSTRH", 10);
            connStateMap.Add("SH", 11);
            connStateMap.Add("SHR", 12);
            connStateMap.Add("OTH", 13);

            historyMap.Add("S", 1);
            historyMap.Add("H", 2);
            historyMap.Add("A", 3);
            historyMap.Add("D", 4);
            historyMap.Add("F", 5);
            historyMap.Add("R", 6);
            historyMap.Add("C", 7);
            historyMap.Add("I", 8);
            historyMap.Add("s", 9);
            historyMap.Add("h", 10);
            historyMap.Add("a", 11);
            historyMap.Add("d", 12);
            historyMap.Add("f", 13);
            historyMap.Add("r", 14);
            historyMap.Add("c", 15);
            historyMap.Add("i", 16);
        }

        public long convertIPv4ToInt(string ipv4Address)
        {
            string[] octets = ipv4Address.Split('.');

            return Convert.ToUInt32(octets[3]) + Convert.ToUInt32(octets[2])*(long)Math.Pow(2, 8) + Convert.ToUInt32(octets[1])*(long)Math.Pow(2, 16) + Convert.ToUInt32(octets[0])*(long)Math.Pow(2, 24);
        }

        public ulong[] convertIPv6ToInt(string ipv6Address)
        {
            byte[] arrv6 = IPAddress.Parse(ipv6Address).GetAddressBytes();

            if (BitConverter.IsLittleEndian)
            {
                List<byte> byteList = new List<byte>(arrv6);
                
                byteList.Reverse();
                arrv6 = byteList.ToArray();
            }

            ulong[] addrWords = new ulong[2];

            if(arrv6.Length > 8)
            {
                addrWords[0] = BitConverter.ToUInt64(arrv6, 8);
                addrWords[1] = BitConverter.ToUInt64(arrv6, 0);
            }
            else
            {
                addrWords[0] = 0;
                addrWords[1] = BitConverter.ToUInt32(arrv6, 0);
            }

            return addrWords;
        }

        /*
        id.orig_h - decimalize
        id.orig_h - decimalize(for ipv6)
        id.orig_p 
        id.resp_h - decimalize
        id.resp_h - decimalize(for ipv6)
        id.resp_p

        proto - string(enumeration)
        service - string(enumeration)
        missed_bytes
        duration
        orig_bytes
        resp_bytes
        conn_state - string(enumeration)
        local_orig - bool(zero or one)
        local_resp - bool(zero or one)
        history - string(enumeration)

        orig_pkts
        orig_ip_bytes
        resp_pkts
        resp_ip_bytes
        tunnel_parents - no clue as to what is going to happen with this one at this point in time.
        */

        public double [][] prepareInputData()
        {
            double[][] preparedInputData = new double[this.rawInputData.Count][];

            DataNormalizer dataNormalizer = new DataNormalizer();

            for (int i = 0; i < this.rawInputData.Count; i++)
            {
                preparedInputData[i] = new double[19];

                if (IPAddress.Parse(this.rawInputData[i].Orig_H).AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    preparedInputData[i][0] = convertIPv4ToInt(this.rawInputData[i].Orig_H);
                    preparedInputData[i][1] = 0;
                }
                else
                {
                    preparedInputData[i][0] = convertIPv6ToInt(this.rawInputData[i].Orig_H)[0];
                    preparedInputData[i][1] = convertIPv6ToInt(this.rawInputData[i].Orig_H)[1];
                }

                preparedInputData[i][2] = this.rawInputData[i].Orig_P;

                if (IPAddress.Parse(this.rawInputData[i].Resp_H).AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    preparedInputData[i][3] = convertIPv4ToInt(this.rawInputData[i].Resp_H);
                    preparedInputData[i][4] = -1;
                }
                else if(IPAddress.Parse(this.rawInputData[i].Resp_H).AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                {
                    preparedInputData[i][3] = convertIPv6ToInt(this.rawInputData[i].Resp_H)[0];
                    preparedInputData[i][4] = convertIPv6ToInt(this.rawInputData[i].Resp_H)[1];
                }

                preparedInputData[i][5] = this.rawInputData[i].Resp_P;
                preparedInputData[i][6] = this.protocolMap[this.rawInputData[i].Proto];
                preparedInputData[i][7] = 0;
                preparedInputData[i][8] = this.rawInputData[i].Duration;
                preparedInputData[i][9] = this.rawInputData[i].Orig_Bytes;
                preparedInputData[i][9] = this.rawInputData[i].Resp_Bytes;
                preparedInputData[i][10] = this.connStateMap[this.rawInputData[i].Conn_State];
                preparedInputData[i][11] = Convert.ToInt16(this.rawInputData[i].Local_Orig);
                preparedInputData[i][12] = Convert.ToInt16(this.rawInputData[i].Local_Resp);
                //preparedInputData[i][13] = this.historyMap[this.rawInputData[i].History];
                preparedInputData[i][14] = this.rawInputData[i].Orig_Packets;
                preparedInputData[i][15] = this.rawInputData[i].Orig_IP_Bytes;
                preparedInputData[i][16] = this.rawInputData[i].Resp_Packets;
                preparedInputData[i][17] = this.rawInputData[i].Resp_IP_Bytes;
                preparedInputData[i][18] = this.rawInputData[i].Missed_Bytes;

                dataNormalizer.setDataPoints(preparedInputData[i]);
                preparedInputData[i] = dataNormalizer.ZScoreStandartization();
            }

            return preparedInputData;
        }
    }
}
