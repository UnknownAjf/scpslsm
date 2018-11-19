using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCPSLSMInstaller
{
    public partial class Installer : Form
    {
        public Installer()
        {
            InitializeComponent();
        }

        private void formSkin1_Click(object sender, EventArgs e)
        {

        }

        private void flatButton1_Click(object sender, EventArgs e)
        {
            if(!File.Exists(@"C:\SCPSLServer"))
            {
                Directory.CreateDirectory(@"C:\SCPSLServer");
                Directory.CreateDirectory(@"C:\SCPSLServer\Configs");
                Directory.CreateDirectory(@"C:\SCPSLServer\SteamCMD");
                File.Create(@"C:\SCPSLServer\Configs\main.txt");
                File.Create(@"C:\SCPSLServer\Configs\admins.txt");
                File.Copy("./steamcmd.exe", @"C:\SCPSLServer\SteamCMD\steamcmd.exe");
                File.Copy("./update.bat", @"C:\SCPSLServer\SteamCMD\update.bat");
                MessageBox.Show("If it ask you to auth steam do it! Also if steamCMD says you can exit close it then another console will open!", "INFO");
                var process = Process.Start(@"C:\SCPSLServer\SteamCMD\steamcmd.exe");
                while (!process.HasExited)
                {
                    //update UI
                }
                //done
                var proca = Process.Start(@"C:\SCPSLServer\SteamCMD\update.bat");
                while (!proca.HasExited)
                {
                    //update UI
                }
                File.Copy(".StartUp.bat", @"C:\SCPSLServer\server\StartUp.bat");
            }
            else
            {
                MessageBox.Show("Already Installed!", "ERROR");
            }
        }

        private void flatButton2_Click(object sender, EventArgs e)
        {
            Directory.Delete(@"C:\SCPSLServer");
        }
    }
}
