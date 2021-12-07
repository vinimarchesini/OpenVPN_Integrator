using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ovpnADM
{
    class StartOVPN
    {
        public void InitSetup (string pathFile, string args, string log, string username, string password)
        {
            ProcessStartInfo ovpnsi = ovpnStartInfo(pathFile, args, log);
            Start(ovpnsi, username, password);
        }
        public ProcessStartInfo ovpnStartInfo(string pathFile, string args, string log)
        {
            ProcessStartInfo ovpnsi = new ProcessStartInfo()
            {
                FileName = pathFile,
                Arguments = @"--config """ + args + @""" " + @"--log """ + log + @"""",
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                Verb = "runas"
            };
            return ovpnsi;
        }

        public void Start(ProcessStartInfo openvpnInfo, string username, string password)
        {
            Process openvpn = Process.Start(openvpnInfo);
            Thread.Sleep(1000);
            openvpn.StandardInput.WriteLine(username);
            Thread.Sleep(1000);
            openvpn.StandardInput.WriteLine(password);
        }
    }
}
