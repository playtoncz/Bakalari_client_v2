using System;
using System.Globalization;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Reflection;
using System.Diagnostics;

namespace Bakaláři
{
    public partial class login : Form
    {
        int mov;
        int movX;
        int movY;
        public static string now = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
        public static string DayString = "";
        public static string username = "";
        public static string orgtoken = "";
        public static string token = "";
        public static string xtoken = "";
        public static string fulltoken = "";
        public static string hxsalted = "";
        public static string hsalted = "";
        public static string xres = "";
        public static string xtyp = "";
        public static string xikod = "";
        public static string xsalt = "";
        public static string result = "";
        public static string xsalted = "";
        string versionup = "";
        string logname;
        public static bool checkboxx;
        public static string URLloginsalt = "";
        private const string basesalt = "/api/login?";
        public static string baseurl = "";
        public static string bazeurl = "";
        public static string xdate = System.DateTime.Today.ToString("yyyyMMdd");
        public static string cdate = DateTime.Now.ToString("ddMM");
        public static string nameday = "";
        public static string statni = "";
        public static string date = "";
        public static string namedayS = "";
        public static string passwd = "";
        public login()
        {
            InitializeComponent();
            Form frmm = new logsett(this);
        }
        private void login_Load(object sender, EventArgs e)
        {
            versionup = "";
            ServicePointManager.ServerCertificateValidationCallback = (Sender, cert, chain, sslPolicyErrors) => true;
            this.loginb.BringToFront();
            textBox1.Text = Bakaláři.Properties.Settings.Default.username;
            textBox2.Text = Bakaláři.Properties.Settings.Default.password;
            if (Bakaláři.Properties.Settings.Default.check == true)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
            DateTime daydt;
            daydt = DateTime.Parse(DateTime.Now.ToString("MM.dd.yyyy"), CultureInfo.InvariantCulture);
            DayString = daydt.ToString("dddd", new CultureInfo("cs-CZ"));
            DayString = DayString.Substring(0, 1).ToUpper() + DayString.Substring(1);
            namedayFunction();
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fileVersionInfo.ProductVersion;
            try
            {
                /*
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
                        this.Close();
                    }
                }
                */
            }
            catch
            {

            }
           
        }

        private void close1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }
        private void loginb_MouseLeave(object sender, EventArgs e)
        {
            this.loginb.BackgroundImage = Bakaláři.Properties.Resources.logincolor;
            this.pictureBox3.BackgroundImage = Bakaláři.Properties.Resources.loginzare;
            this.loginb.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(202)))), ((int)(((byte)(92)))));
        }
        private void loginb_MouseEnter(object sender, EventArgs e)
        {

            this.loginb.BackgroundImage = Bakaláři.Properties.Resources.logincolorx;
            this.pictureBox3.BackgroundImage = Bakaláři.Properties.Resources.loginzarex2;
            this.loginb.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(160)))), ((int)(((byte)(81)))));
        }
        public void loginb_Click(object sender, EventArgs e)
        {
            sendBackTab();
            Form frm = new menugui(this);
            logname = textBox1.Text;
            passwd = textBox2.Text;
            
            string urlsalt = Bakaláři.Properties.Settings.Default.link + basesalt + "client_id=ANDR&grant_type=password&username=" + logname + "&password=" + passwd;
            URLloginsalt = urlsalt;
            try
            {
                XmlTextReader reader = new XmlTextReader(urlsalt);
                /*Tady jsme skončili*/ 
                System.Diagnostics.Debug.WriteLine(reader.ReadInnerXml());

                System.Diagnostics.Debug.WriteLine(urlsalt);
                
                if (String.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Zadejte údaje.", "Chyba přihlašení", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    while (reader.Read())
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "res")
                        {
                            string xres = reader.ReadElementString();
                            if (xres == "02")
                            {
                                MessageBox.Show("Zadané uživatelské jméno je nesprávné.", "Chyba přihlašení", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                Bakaláři.Properties.Settings.Default.usernamecache = logname;
                                Bakaláři.Properties.Settings.Default.passwordcache = textBox2.Text;
                                Bakaláři.Properties.Settings.Default.Save();
                                if (reader.NodeType == XmlNodeType.Element && reader.Name == "typ")
                                {
                                    string xtyp = reader.ReadElementString();
                                    xsalted = xtyp;
                                }
                                if (reader.NodeType == XmlNodeType.Element && reader.Name == "ikod")
                                {
                                    string xikod = reader.ReadElementString();
                                    xsalted = xikod + xsalted;
                                }
                                if (reader.NodeType == XmlNodeType.Element && reader.Name == "salt")
                                {
                                    string xsalt = reader.ReadElementString();
                                    xsalted = xsalt + xsalted;
                                }

                                xsalted = xsalted + textBox2.Text;

                               

                                orgtoken = "*login*" + logname + "*pwd*" + hxsalted + "*sgn*ANDR" + xdate;
                                

                                string xxtoken = xtoken.Replace('/', '_');
                                string xxxtoken = xxtoken.Replace('+', '-');
                                string fulltoken = xxxtoken.Replace('\\', '_');

                                baseurl = Bakaláři.Properties.Settings.Default.link + "?hx=" + fulltoken + "&pm=login";
                                bazeurl = Bakaláři.Properties.Settings.Default.link + "?hx=" + fulltoken;

                                username = textBox1.Text;
                                reader.Close();
                                XmlTextReader reader2 = new XmlTextReader(baseurl);
                                while (reader2.Read())
                                {
                                    if (reader2.IsStartElement())
                                    {
                                        switch (reader2.Name)
                                        {
                                            case "result":
                                                reader2.Read();
                                                result = reader2.Value;
                                                break;
                                        }
                                    }
                                }
                                if (result == "-1")
                                {
                                    MessageBox.Show("Zadané heslo je nesprávné.", "Chyba přihlašení", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                if (result == "01")
                                {
                                    if (checkBox1.Checked)
                                    {
                                        Bakaláři.Properties.Settings.Default.username = textBox1.Text;
                                        Bakaláři.Properties.Settings.Default.password = textBox2.Text;
                                        Bakaláři.Properties.Settings.Default.check = true;
                                        Bakaláři.Properties.Settings.Default.Save();
                                        checkboxx = true;
                                    }
                                    else
                                    {
                                        textBox1.Text = "";
                                        textBox2.Text = "";
                                        Bakaláři.Properties.Settings.Default.username = "";
                                        Bakaláři.Properties.Settings.Default.password = "";
                                        Bakaláři.Properties.Settings.Default.check = false;
                                        Bakaláři.Properties.Settings.Default.Save();
                                        checkboxx = false;
                                    }
                                    frm.Show();
                                    this.Hide();
                                }
                            }
                        }
                }
            }
            catch (Exception lol)
            {

                DialogResult result = MessageBox.Show("Něco se pokazilo: " + lol.Message + " ",  "AJAJ :(" , MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    Form frmm = new logsett(this);
                    frmm.ShowDialog();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            sendBackTab();
            Form frmm = new logsett(this);
            frmm.ShowDialog();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            sendBackTab();
            this.WindowState = FormWindowState.Minimized;
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
        private void sendBackTab()
        {
            System.Windows.Forms.SendKeys.SendWait("+{TAB}");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            now = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            labelTime.Text = DayString + ", " + now;
        }
        private void namedayFunction()
        {
            try
            {
                XmlReader reader = XmlReader.Create("https://pastebin.com/raw/b1XgASAZ");
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case "date":
                                reader.Read();
                                date = reader.Value;
                                statni = "";
                                break;
                            case "name":
                                reader.Read();
                                nameday = reader.Value;
                                namedayS = reader.Value;
                                if (date == cdate)
                                {
                                    if (nameday.Length > 15)
                                    {
                                        ToolTip tt1 = new ToolTip();
                                        tt1.InitialDelay = 100;
                                        tt1.ReshowDelay = 100;
                                        nameday = nameday.Substring(0, 15) + "...";
                                        tt1.SetToolTip(this.labelNameday, namedayS);
                                    }
                                    labelNameday.Text = nameday;
                                }
                                break;
                        }
                    }
                }
                reader.Close();
            }
            catch
            {
                MessageBox.Show("Nejste připojeni k internetu!", "Chyba internetu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}

