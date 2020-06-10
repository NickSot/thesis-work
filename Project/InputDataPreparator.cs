using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Security.Cryptography;
using System.IO;
using Newtonsoft.Json;

namespace Project
{
    class InputDataPreparator
    {
        Dictionary<string, int> protocolMap = new Dictionary<string, int>();
        Dictionary<string, int> connStateMap = new Dictionary<string, int>();

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
        }

        public InputDataPreparator changeInputData(List<PacketInformation> rawInputData) {
            this.rawInputData = rawInputData;

            return this;
        }

        public Dictionary<string, int> getProtocolMap() {
            return this.protocolMap;
        }

        public Dictionary<string, int> getConnectionStateMap() {
            return this.connStateMap;
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
        */
        public static void loadInputDataToDB(string[] dataFiles, string[] labelFiles)
        {
            if (dataFiles.Length != labelFiles.Length) {
                return;
            }

            for (int i = 0; i < dataFiles.Length; i++) {
                string fileData = new StreamReader(dataFiles[i]).ReadToEnd();

                List<PacketInformation> packetsList = JsonConvert.DeserializeObject<List<PacketInformation>>(fileData);

                //packetList.ForEach((packet) => 
                for (int j = 0; j < packetsList.Count; j++)
                {
                    var labelData = new StreamReader(labelFiles[i]).ReadToEnd();

                    List<PacketInformation> labelInfo = JsonConvert.DeserializeObject<List<PacketInformation>>(labelData);

                    packetsList[j].Label = 0;

                    for (int k = 0; k < labelInfo.Count; k++) {

                        if (packetsList[j].Orig_H == labelInfo[k].Orig_H && packetsList[j].Orig_P == labelInfo[k].Orig_P && packetsList[j].Resp_H == labelInfo[k].Resp_H && packetsList[j].Resp_P == labelInfo[k].Resp_P)
                        {
                            packetsList[j].Label = 1;
                            break;
                        }
                    }

                    DbManager.Insert("DataSet", new Dictionary<string, object>() {
                        { "Id_Orig_H", packetsList[j].Orig_H},
                        { "Id_Resp_H", packetsList[j].Resp_H},
                        { "Id_Orig_P", packetsList[j].Orig_P},
                        { "Id_Resp_P", packetsList[j].Resp_P},
                        { "Service_Protocol", packetsList[j].Service},
                        { "Missed_Bytes", packetsList[j].Missed_Bytes},
                        { "Duration", packetsList[j].Duration},
                        { "Orig_Bytes", packetsList[j].Orig_Bytes},
                        { "Resp_Bytes", packetsList[j].Resp_Bytes},
                        { "Connection_State", packetsList[j].Conn_State},
                        { "Local_Orig", packetsList[j].Local_Orig},
                        { "Local_Resp", packetsList[j].Local_Resp},
                        { "History", packetsList[j].History},
                        { "Protocol", packetsList[j].Proto},
                        { "Orig_Pkts", packetsList[j].Orig_Pkts},
                        { "Orig_Ip_Bytes", packetsList[j].Orig_IP_Bytes},
                        { "Resp_Pkts", packetsList[j].Resp_Pkts},
                        { "Resp_Ip_Bytes", packetsList[j].Resp_IP_Bytes},
                        { "Label_Value", packetsList[j].Label }
                    });
                }
            }
        }

        public double [][] prepareInputData()
        {
            double[][] preparedInputData = new double[this.rawInputData.Count][];

            DataNormalizer dataNormalizer = new DataNormalizer();

            for (int i = 0; i < this.rawInputData.Count; i++)
            {
                preparedInputData[i] = new double[20];

                if (IPAddress.Parse(this.rawInputData[i].Orig_H).AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    preparedInputData[i][0] = convertIPv4ToInt(this.rawInputData[i].Orig_H);
                    preparedInputData[i][1] = -1;
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
                var hash = computeSHA256(this.rawInputData[i].Service).Remove(16);
                preparedInputData[i][7] = (double)UInt64.Parse(hash, System.Globalization.NumberStyles.HexNumber);
                preparedInputData[i][8] = this.rawInputData[i].Duration;
                preparedInputData[i][9] = this.rawInputData[i].Orig_Bytes;
                preparedInputData[i][9] = this.rawInputData[i].Resp_Bytes;
                preparedInputData[i][10] = this.connStateMap[this.rawInputData[i].Conn_State];
                preparedInputData[i][11] = Convert.ToInt16(this.rawInputData[i].Local_Orig);
                preparedInputData[i][12] = Convert.ToInt16(this.rawInputData[i].Local_Resp);
                hash = computeSHA256(this.rawInputData[i].History).Remove(16);
                preparedInputData[i][13] = (double)UInt64.Parse(hash, System.Globalization.NumberStyles.HexNumber);
                preparedInputData[i][14] = this.rawInputData[i].Orig_Pkts;
                preparedInputData[i][15] = this.rawInputData[i].Orig_IP_Bytes;
                preparedInputData[i][16] = this.rawInputData[i].Resp_Pkts;
                preparedInputData[i][17] = this.rawInputData[i].Resp_IP_Bytes;
                preparedInputData[i][18] = this.rawInputData[i].Missed_Bytes;

                dataNormalizer.setDataPoints(preparedInputData[i]);
                preparedInputData[i] = dataNormalizer.ZScoreStandartization();
                preparedInputData[i][19] = this.rawInputData[i].Label;
            }

            return preparedInputData;
        }

        private string computeSHA256(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
