using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

namespace Bakaláři
{
    public partial class sett : Form
    {
        int mov;
        int movX;
        int movY;
        public static string calPick;
        public static string calPickDay;
        public static string calPickMonth;
        public static string calPickYear;
        public static string calPickF;
        public static string settDU;
        public static string versionup;
        public static int settCalDate;
        public static DateTime now = DateTime.Now;
        string nowc = DateTime.Now.ToString("yyyyMMdd");
        RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        menugui menu;
        public sett(menugui parrentform)
        {
            InitializeComponent();
            menu = parrentform;
        }
        private void sett_Load(object sender, EventArgs e)
        {
            if (Bakaláři.Properties.Settings.Default.settCal2 == "Vlastní třída")
            {
                comboBox1.SelectedIndex = 0;
            }
            if (Bakaláři.Properties.Settings.Default.settCal2 == "Všechny třídy")
            {
                comboBox1.SelectedIndex = 1;
            }
            if (Bakaláři.Properties.Settings.Default.settCalDate == 1)
            {
                checkBox1.Checked = true;
                monthCalendar1.Enabled = false;
            }
            else
            {
                DateTime dtcalpick = Convert.ToDateTime(Bakaláři.Properties.Settings.Default.settCalPick);
                monthCalendar1.SetDate(dtcalpick);
                monthCalendar1.Enabled = true;
                checkBox1.Checked = false;
            }
            if(Bakaláři.Properties.Settings.Default.autostart == true)
            {
                checkBox2.Checked = true;
            }
            else
            {
                checkBox2.Checked = false;
            }
            if (Bakaláři.Properties.Settings.Default.settDu == "Všechny")
            {
                comboBox3.SelectedIndex = 0;
            }
            if (Bakaláři.Properties.Settings.Default.settDu == "Aktivní")
            {
                comboBox3.SelectedIndex = 1;
            }
            comboBox2.SelectedIndex = Bakaláři.Properties.Settings.Default.znamkyA - 1;
            if(comboBox2.SelectedIndex == 0)
            {
                label14.Text = "den";
            }
            if (comboBox2.SelectedIndex == 1 || comboBox2.SelectedIndex == 2 || comboBox2.SelectedIndex == 3)
            {
                label14.Text = "dny";
            }
            textBox1.Text = Bakaláři.Properties.Settings.Default.link1;
            textBox2.Text = Bakaláři.Properties.Settings.Default.link2;
            textBox3.Text = Bakaláři.Properties.Settings.Default.link3;
            textBox4.Text = Bakaláři.Properties.Settings.Default.hranice;
            textBox5.Text = Bakaláři.Properties.Settings.Default.facebook;
            textBox6.Text = Bakaláři.Properties.Settings.Default.jidelna;
            textBox7.Text = Bakaláři.Properties.Settings.Default.jidelnaid;
            textBox8.Text = Bakaláři.Properties.Settings.Default.jidelnapass;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (menu.textBox11.Visible == true)
            {
                menu.textBox11.Visible = false;
            }
            else
            {
                menu.textBox11.Visible = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Cal datum
            if (textBox4.Text == "")
            {
                textBox4.Text = "0";
            }
            if (checkBox1.Checked == true)
            {
                settCalDate = 1;
                Bakaláři.Properties.Settings.Default.settCalDate = 1;
                Bakaláři.Properties.Settings.Default.Save();
            }
            else
            {
                calPick = monthCalendar1.SelectionRange.Start.ToShortDateString();
                if (calPick.Substring(0, 2).Contains("/")) 
                {
                    calPickDay = "0" + calPick.Substring(0, 1); 
                    if (calPick.Substring(2, 2).Contains("/")) 
                    {
                        calPickMonth = "0" + calPick.Substring(2, 1); //D/M/YYYY
                        calPickYear = calPick.Substring(4, 4);
                    }
                    else
                    {
                        calPickMonth = calPick.Substring(2, 2); //D/MM/YYYY
                        calPickYear = calPick.Substring(5, 4);
                    }
                }
                else
                {
                    calPickDay = calPick.Substring(0, 2);
                    if (calPick.Substring(3, 2).Contains("/")) 
                    {
                        calPickMonth = "0" + calPick.Substring(3, 1); //DD/M/YYYY
                        calPickYear = calPick.Substring(5, 4);
                    }
                    else
                    {
                        calPickMonth = calPick.Substring(3, 2); //DD/MM/YYYY
                        calPickYear = calPick.Substring(6, 4);
                    }
                }
                Bakaláři.Properties.Settings.Default.settCalPick = calPick;
                Bakaláři.Properties.Settings.Default.Save();
                calPickF = calPickYear + calPickMonth + calPickDay;
                settCalDate = Convert.ToInt32(calPickF);
                int nowch = Convert.ToInt32(nowc);
                if (settCalDate == nowch)
                {
                    settCalDate = 1;
                    checkBox1.Checked = true;
                }
                Bakaláři.Properties.Settings.Default.settCalDate = settCalDate;
                Bakaláři.Properties.Settings.Default.Save();
            }
            if (checkBox2.Checked == true)
            {
                try
                {
                    registryKey.SetValue("Bakaláři", Application.ExecutablePath);
                }
                catch { }
                Bakaláři.Properties.Settings.Default.autostart = true;
            }
            else
            {
                try
                {
                    registryKey.DeleteValue("Bakaláři");
                }
                catch { }
                Bakaláři.Properties.Settings.Default.autostart = false;
            }
            //Cal třída
            if (comboBox1.SelectedIndex == 1)
            {
                Bakaláři.Properties.Settings.Default.settCal2 = "Všechny třídy";
            }
            else
            {
                Bakaláři.Properties.Settings.Default.settCal2 = "Vlastní třída";
            }
            if (comboBox3.SelectedIndex == 1)
            {
                Bakaláři.Properties.Settings.Default.settDu = "Aktivní";
            }
            else
            {
                Bakaláři.Properties.Settings.Default.settDu = "Všechny";
            }
            Bakaláři.Properties.Settings.Default.Save();
            Bakaláři.Properties.Settings.Default.znamkyA = comboBox2.SelectedIndex + 1;
            Bakaláři.Properties.Settings.Default.Save();
            Bakaláři.Properties.Settings.Default.link1 = textBox1.Text;
            Bakaláři.Properties.Settings.Default.link2 = textBox2.Text;
            Bakaláři.Properties.Settings.Default.link3 = textBox3.Text;
            Bakaláři.Properties.Settings.Default.hranice = textBox4.Text;
            Bakaláři.Properties.Settings.Default.facebook = textBox5.Text;
            Bakaláři.Properties.Settings.Default.jidelna = textBox6.Text;
            Bakaláři.Properties.Settings.Default.jidelnaid = textBox7.Text;
            Bakaláři.Properties.Settings.Default.jidelnapass = textBox8.Text;
            Bakaláři.Properties.Settings.Default.Save();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                monthCalendar1.Enabled = false;
                monthCalendar1.SetDate(now);
            }
            else
            {
                monthCalendar1.Enabled = true;
            }
        }
        private void panelx_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }
        private void panelx_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }
        private void panelx_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
        private void End()
        {
            DialogResult result = MessageBox.Show("Chcete uložit změny?", "Bakaláři – Nastavení", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                button2.PerformClick();
                this.Close();
            }
            else if (result == DialogResult.No)
            {
                this.Close();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox4.Text == "")
            {
                textBox4.Text = "0";
            }
            string combo1 = comboBox1.SelectedItem.ToString();
            if (checkBox1.Checked == true)
            {
                settCalDate = 1;
                Bakaláři.Properties.Settings.Default.settCalDate = 1;
                Bakaláři.Properties.Settings.Default.Save();
            }
            else
            {
                calPick = monthCalendar1.SelectionRange.Start.ToShortDateString();
                if (calPick.Substring(0, 2).Contains("/"))
                {
                    calPickDay = "0" + calPick.Substring(0, 1);
                    if (calPick.Substring(2, 2).Contains("/"))
                    {
                        calPickMonth = "0" + calPick.Substring(2, 1); //D/M/YYYY
                        calPickYear = calPick.Substring(4, 4);
                    }
                    else
                    {
                        calPickMonth = calPick.Substring(2, 2); //D/MM/YYYY
                        calPickYear = calPick.Substring(5, 4);
                    }
                }
                else
                {
                    calPickDay = calPick.Substring(0, 2);
                    if (calPick.Substring(3, 2).Contains("/"))
                    {
                        calPickMonth = "0" + calPick.Substring(3, 1); //DD/M/YYYY
                        calPickYear = calPick.Substring(5, 4);
                    }
                    else
                    {
                        calPickMonth = calPick.Substring(3, 2); //DD/MM/YYYY
                        calPickYear = calPick.Substring(6, 4);
                    }
                }
                Bakaláři.Properties.Settings.Default.settCalPick = calPick;
                Bakaláři.Properties.Settings.Default.Save();
                calPickF = calPickYear + calPickMonth + calPickDay;
                settCalDate = Convert.ToInt32(calPickF);
                int nowch = Convert.ToInt32(nowc);
                if (settCalDate == nowch)
                {
                    settCalDate = 1;
                    checkBox1.Checked = true;
                }
            }
            if (comboBox3.SelectedIndex == 1)
            {
                settDU = "Aktivní";
            }
            else
            {
                settDU = "Všechny";
            }
            if(Bakaláři.Properties.Settings.Default.autostart != checkBox2.Checked)
            {
                End();
            }
            else if (Bakaláři.Properties.Settings.Default.settCal2 != combo1)
            {
                End();
            }
            else if (Bakaláři.Properties.Settings.Default.settCalDate != settCalDate)
            {
                End();
            }
            else if (Bakaláři.Properties.Settings.Default.link1 != textBox1.Text)
            {
                End();
            }
            else if (Bakaláři.Properties.Settings.Default.link2 != textBox2.Text)
            {
                End();
            }
            else if (Bakaláři.Properties.Settings.Default.link3 != textBox3.Text)
            {
                End();
            }
            else if (Bakaláři.Properties.Settings.Default.hranice != textBox4.Text)
            {
                End();
            }
            else if (Bakaláři.Properties.Settings.Default.znamkyA - 1 != comboBox2.SelectedIndex)
            {
                End();
            }
            else if (Bakaláři.Properties.Settings.Default.settDu != settDU)
            {
                End();
            }
            else if (Bakaláři.Properties.Settings.Default.facebook != textBox5.Text)
            {
                End();
            }
            else if (Bakaláři.Properties.Settings.Default.jidelna != textBox6.Text)
            {
                End();
            }
            else if (Bakaláři.Properties.Settings.Default.jidelnaid != textBox7.Text)
            {
                End();
            }
            else if (Bakaláři.Properties.Settings.Default.jidelnapass != textBox8.Text)
            {
                End();
            }
            else
            {
                this.Close();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form ab = new about(this);
            try { ab.Show(); }
            catch { }
        }
        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                label14.Text = "den";
            }
            else
            {
                if (comboBox2.SelectedIndex == 1 || comboBox2.SelectedIndex == 2 || comboBox2.SelectedIndex == 3)
                {
                    label14.Text = "dny";
                }
                else
                {
                    label14.Text = "dnů";
                }
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fileVersionInfo.ProductVersion;
            try
            {
                using (WebClient client = new WebClient())
                {
                    versionup = "";
                    versionup = client.DownloadString("https://raw.githubusercontent.com/Nkaskaj/BakalariClient/master/version");
                    int vercor = versionup.Length;
                    versionup = versionup.Substring(0, vercor - 1);
                }
                if (version != versionup)
                {
                    DialogResult result = MessageBox.Show("Je k dispozici aktualizace! Chcete přejít na web?", "Aktualizace", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        System.Diagnostics.Process.Start("https://github.com/Nkaskaj/BakalariClient");
                    }
                }
                else
                {
                    MessageBox.Show("Máte nejnovější verzi!", "Aktualizace", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Něco se nepodařilo!", "Aktualizace", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int absc = Convert.ToInt32(textBox4.Text);
                if(absc >= 0 && absc <= 100)
                {

                }
                else
                {
                    textBox4.Text = "25";
                }
            }
            catch
            {
                if (textBox4.Text == "")
                {

                }
                else
                {
                    textBox4.Text = "25";
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
