using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SCPSL_Server_Maker
{
    public partial class SCPSLServerMaker : Form
    {
        public void EndTask(string taskname)
        {
            string processName = taskname;
            string fixstring = taskname.Replace(".exe", "");

            if (taskname.Contains(".exe"))
            {
                foreach (Process process in Process.GetProcessesByName(fixstring))
                {
                    process.Kill();
                }
            }
            else if (!taskname.Contains(".exe"))
            {
                foreach (Process process in Process.GetProcessesByName(processName))
                {
                    process.Kill();
                }
            }
        }


        public SCPSLServerMaker()
        {
            InitializeComponent();
            flatTextBox2.Text = File.ReadAllText(@"C:\SCPSLServer\Configs\main.txt");
            foreach(string line in File.ReadAllLines(@"C:\SCPSLServer\Configs\admins.txt"))
            {
                listBox1.Items.Add(line);
            }
        }

        private void formSkin1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void flatRadioButton1_CheckedChanged(object sender)
        {

        }

        private void flatButton1_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\SCPSLServer\SteamCMD\updatea.bat");
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void flatTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void flatButton2_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\SCPSLServer\SteamCMD\update.bat");
        }

        private void AdminConfigBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ServerConfigBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void flatButton7_Click(object sender, EventArgs e)
        {
            ServerConfigBox.Text = File.ReadAllText(@flatTextBox2.Text+ "/config_gameplay.txt");
        }

        private void flatButton9_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:\SCPSLServer\Configs\main.txt", flatTextBox2.Text);
        }

        private void flatButton4_Click(object sender, EventArgs e)
        {
            AdminConfigBox.Text = File.ReadAllText(@flatTextBox2.Text + "/config_remoteadmin.txt");
        }

        private void flatButton5_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:\SCPSLServer\Configs\admins.txt", AdminConfigBox.Text);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void flatButton12_Click(object sender, EventArgs e)
        {
            
        }

        private void flatButton6_Click(object sender, EventArgs e)
        {
            string[] configlines = {
                "server_name: "+ServerNameBox.Text,
                "serverinfo_pastebin_id: "+PastebinBox.Text,
                "server_ip: "+IPBox.Text,
                "max_players: "+MaxPlayers.Text,
                "port_queue:",
                            " - "+PortBox,
                "minimum_MTF_time_to_spawn: "+MTFSTMIN.Text,
                "maximum_MTF_time_to_spawn: "+MTFSTMAX.Text,
                "ci_respawn_percent: "+CIRespawn.Text,
                "ci_on_start_percent: "+CISpawn.Text,
                "team_respawn_queue: 40143140314414041340",
                "server_forced_class: "+ForceTeam.Text,
                "map_seed: "+GameSeed.Text,
                "intercom_cooldown: "+IntercomCooldown.Text,
                "intercom_max_speech_time: "+IntercomTime.Text,
                "auto_round_restart_time: 10",
                "friendly_fire: "+FriendlyFire.Text,
                "warhead_tminus_start_duration: 90",
                "human_grenade_multiplier: 0.7",
                "scp_grenade_multiplier: 1",
                "lock_gates_on_countdown: true",
                "allow_playing_as_tutorial: true",
                "pd_exit_count: 2",
                "pd_random_exit_rids: []",
                "pd_random_exit_rids_after_decontamination: []",
                "pd_refresh_exit: false",
                "commander_can_cuff_mtf: true",
                "mtf_can_cuff_researchers: true",
                "ci_can_cuff_class_d: true",
                "grenade_chain_limit: 10",
                "grenade_chain_length_limit: 4",
                "online_mode: true",
                "ip_banning: true",
                "enable_whitelist: false",
                "hide_from_public_list: false",
                "forward_ports: true",
                "enable_query: false",
                "query_port_shift: 0",
                "query_use_IPv6: true",
                "administrator_query_password: none",
                "noclip_protection_output: false",
                "speedhack_protection_output: false",
                "contact_email: "+EmailBox.Text
            };
            File.WriteAllLines(@flatTextBox2.Text + "/config_gameplay.txt", configlines);
        }

        private void flatButton1_Click_1(object sender, EventArgs e)
        {
            foreach (string line in listBox1.Items)
            {
                StreamWriter lol = new StreamWriter(@"C:\SCPSLServer\Configs\admins.txt");
                lol.WriteLine(line);
            }
        }

        private void flatTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void flatLabel16_Click(object sender, EventArgs e)
        {

        }

        private void flatLabel15_Click(object sender, EventArgs e)
        {

        }

        private void flatTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void CISpawn_TextChanged(object sender, EventArgs e)
        {

        }

        private void CIRespawn_TextChanged(object sender, EventArgs e)
        {

        }

        private void MTFSTMIN_TextChanged(object sender, EventArgs e)
        {

        }

        private void MTFSTMAX_TextChanged(object sender, EventArgs e)
        {

        }

        private void flatTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void flatButton10_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(SteamIDBox.Text);
        }

        private void flatButton8_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\SCPSLServer\server\LocalAdmin.exe");
        }

        private void flatButton3_Click(object sender, EventArgs e)
        {
            EndTask("LocalAdmin.exe");
            EndTask("SCPSL.exe");
        }
    }
}
