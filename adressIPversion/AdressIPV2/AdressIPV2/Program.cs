using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

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
            try   { externalipv4 = new WebClient().DownloadString(Links.IPV4canhzip); }
            catch { externalipv4 = error; }
            try   { externalipv6 = new WebClient().DownloadString(Links.IPV6canhaip); }
            catch { externalipv6 = error; }
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
            OM.SavingDialog(DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + "-" + DateTime.Now.ToShortDateString() + ".txt");
            OM.AnyKeyContinue();            
        }
    }
}
#endregion