﻿using System;
using System.Device.Location;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Net.NetworkInformation;

namespace DataLayer.Util
{
   public static class Utilidades
    {


        /// Encripta una cadena
        public static string Encriptar(this string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public static string DesEncriptar(this string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

        public static string[] LocationDevice()

        {
            
                string[] loctionDevice = new string[2];
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.Default);
            watcher.Start(); //started watcher
            if (watcher.Status == GeoPositionStatus.Ready)
            {


                GeoCoordinate coord = watcher.Position.Location;

                while (watcher.Position.Location.IsUnknown)
                {
                    loctionDevice[0] = coord.Latitude.ToString(); //latitude
                    loctionDevice[1] = coord.Longitude.ToString();  //logitude
                }
            }



            return loctionDevice;
        }


        public static string GetIP(NetworkInterfaceType _type,string tipo)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    IPInterfaceProperties adapterProperties = item.GetIPProperties();
                    if(tipo=="Fisica")
                    {
                        if (item.OperationalStatus == OperationalStatus.Up)
                        {
                            output+= item.GetPhysicalAddress().ToString();
                           
                            break;
                        }
                       


                    }
                    else { 
                    
                    if (adapterProperties.GatewayAddresses.FirstOrDefault() != null)
                    {

                        foreach (UnicastIPAddressInformation ip in adapterProperties.UnicastAddresses)
                        {

                            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                            {
                                output = ip.Address.ToString();
                            }
                        }
                    }
                    }
                }
            }

            return output;
        }


    }
}
