/*--------------------------------------------------------------------------------
 * Sadek Amrouche (Computer Science Student)
 * Version : Beta 0.90
 * Snapshot : 13W11B
 * Collaborate with : Christian Blanvillain (Teacher) Joel Von Der Weid (Student)
 * CFTP Computer Science (Geneva)
 *-------------------------------------------------------------------------------
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Diagnostics;


namespace AdressIPV2
{
    class Program
    {
        static void Main(string[] args)
        {
#region variables
            OutputManager OM = new OutputManager();
            IPHostEntry ipHostEntry = Dns.GetHostEntry(Dns.GetHostName());
            int numipv4 = 1;
            int numipv6 = 1;
            string externalipv4;
            string externalipv6;
            string error = "Connection Problem !";
            try
            {
                externalipv4 = new WebClient().DownloadString(Links.IPV4canhzip);
                Debug.Print("IPV4 OK");
            }
            catch  (Exception e)
            {
                 externalipv4 = error;
                 Debug.Print("IPV4 " + e.ToString());
                 OM.FileWrite("IPV4 Exeption : " + e.ToString());
                 OM.FileWriteLine();
            }
            try
            {
                externalipv6 = new WebClient().DownloadString(Links.IPV6canhaip);
                Debug.Print("IPV6 OK");
            }
            catch (Exception e)
            {
                externalipv6 = error;
                Debug.Print("IPV6 " + e.ToString());
                OM.FileWrite("IPV6 Exeption : " + e.ToString());
                OM.FileWriteLine();
            }
            string hostname = ipHostEntry.HostName;
#endregion
#region Code
            OM.ForegroundColor(ConsoleColor.Green);
            OM.Write("Interfaces Number : ");
            OM.Write(ipHostEntry.AddressList.Length.ToString());
            OM.WriteLine();
            OM.WriteLine();
            OM.Center(" Device Name : " + hostname + " -- " + DateTime.Now.ToString());
            OM.WriteLine();
            foreach (IPAddress adress in ipHostEntry.AddressList)
            {
                if (adress.ToString().Length <= 15) // Max IPV4 lenght is 255.255.255.255 = 15
                    OM.WriteLine("IPV4 Interface Number " + (numipv4++.ToString()) + " : " + adress);
                else
                    OM.WriteLine("IPV6 Interface Number " + (numipv6++.ToString()) + " : " + adress);
                OM.WriteLine();
            }
            OM.Center(" EXTERNAL IPV4 : ");
            OM.WriteLine();
            OM.WriteLine("------->>> " + externalipv4);
            OM.WriteLine();
            OM.Center(" EXTERNAL IPV6 : ");
            OM.WriteLine();
            OM.WriteLine("------->>> " + externalipv6);
            OM.AnyKeyContinue();
            OM.WriteLine();
            try { OM.SavingDialog(DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + "-" + DateTime.Now.ToShortDateString() + ".txt"); }
            catch (Exception e) { Debug.Print(e.ToString()); }
            OM.AnyKeyContinue();
        }
    }
}
#endregion
