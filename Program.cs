/*
 * IP/IFCONFIG custom 
 * Sadek Amrouche contact : ssk190399@me.com
 * Version 1.1 Final Version.
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
            try {  externalipv4 = new WebClient().DownloadString("http://icanhazip.com"); }
            catch {  externalipv4 = "Connection Problem"; }
            try { externalipv6 = new WebClient().DownloadString("http://ipv6.icanhazip.com"); }
            catch { externalipv6 = "Connection Problem"; }
            string hostname = ipHostEntry.HostName;
            int num = 1;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Nombre d'interfaces : ");
            Console.WriteLine(ipHostEntry.AddressList.Length);
            Console.WriteLine();
            Console.WriteLine("---------------------- Nom de l'appareil : " + hostname + " -----------------------");
            Console.WriteLine("---------------------------------------------------");
            foreach (IPAddress adress in ipHostEntry.AddressList)
            {
                if (num <= 3)
                {
                    Console.WriteLine(" Interface numero " + num.ToString() + " : " + adress);
                    Console.WriteLine("---------------------------------------------------");
                }
                else
                {
                    Console.WriteLine(" Interface numero " + (num-3).ToString() + " : " + adress);
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
            Console.ReadKey();
        }
    }
}
