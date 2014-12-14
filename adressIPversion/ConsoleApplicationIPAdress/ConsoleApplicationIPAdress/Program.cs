/*
 * IP/IFCONFIG custom 
 * Sadek Amrouche contact : ssk190399@me.com
 * Version 1.1 Version Final.
 * SNAPSHOT 14W48B
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationIPAdress
{
    class Program
    {
        static void Main(string[] args)
        {
            IPHostEntry ipHostEntry = Dns.GetHostEntry(Dns.GetHostName());
            string externalipv4;
            string externalipv6;
            try {  externalipv4 = new WebClient().DownloadString("http://icanhazip.com"); } // if this adress return a ipv6 you can contact me.
            catch {  externalipv4 = "Connection Problem"; }
            try { externalipv6 = new WebClient().DownloadString("http://ipv6.icanhazip.com"); } // if you doesn't activate ipv6 this adress renturn anything**.
            catch { externalipv6 = "Connection Problem"; } //**return this
            string hostname = ipHostEntry.HostName;
            int num = 1;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Interfaces Numbers :");
            Console.WriteLine(ipHostEntry.AddressList.Length);
            Console.WriteLine();
            Console.WriteLine("---------------------- Device Name : " + hostname + " -----------------------");
            Console.WriteLine("---------------------------------------------------");
            foreach (IPAddress adress in ipHostEntry.AddressList)
            {
				if (adress.ToString().Length <= 15)
                {
                    Console.WriteLine(" IPV4 Interface Number " + num.ToString() + " : " + adress); // max lenght of ipv4 = 15 
                    Console.WriteLine("---------------------------------------------------");
                }
				else if (adress.ToString().Length > 15)
                {
                    Console.WriteLine(" IPV6 Interface Number " + (num).ToString() + " : " + adress);
                    Console.WriteLine("---------------------------------------------------");
                }
                num++;
            }
            Console.WriteLine("--------------------EXERNAL IPV4 : --------------------");
            Console.WriteLine();
            Console.WriteLine("------->>> " + externalipv4);
            Console.WriteLine();
            Console.WriteLine("--------------------EXERNAL IPV6 : --------------------");
            Console.WriteLine();
            Console.WriteLine("------->>> " + externalipv6);
			Console.WriteLine();
			Console.WriteLine("press enter to continue");
            Console.ReadKey();
        }
    }
}