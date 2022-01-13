using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Bakaláři
{
    public partial class menugui : Form
    {
        login opener;
        int mov;
        int movX;
        int movY;
        int c = 0;
        int cache = 0;
        public static string i;
        public static string facebook;
        public static string jidelna;
        public static string day = "";
        public static int dayint;
        public static bool znamkyo = false;
        public static string dayString = "";
        public static string DayString = "";
        public static string nameday = "";
        public static string statni = "";
        public static string date = "";
        public static string named = "";
        public static string jmeno = "";
        public static string owntrida = "";
        public static string orgtoken = "";
        public static string strtyp = "";
        public static bool checkbox = login.checkboxx;
        public static string ndate = DateTime.Now.ToString("yMMdHHmm");
        int ndateint = 0;
        public static string den = DateTime.Now.ToString("dd");
        public static string cden = DateTime.Now.ToString("dd");
        public static string cdate = DateTime.Now.ToString("ddMM");
        public static string xdate = System.DateTime.Today.ToString("yyyyMMdd");
        private const string basesalt = "?gethx=";
        public static string logname = "";
        public static string URLloginsalt = "";
        public static string xsalted;
        public static string hsalted;
        public static string hxsalted;
        public static string token;
        public static string xtoken;
        public static string versionup;
        public static string xres = "";
        public static string typ = "";
        public static string ikod = "";
        public static string salt = "";
        public static string fulltoken = "";
        public static string test = "";

        public menugui(login parentForm)
        {
            InitializeComponent();
            opener = parentForm;
        }
        private void callOnLoad()
        {
            ServicePointManager.ServerCertificateValidationCallback = (Sender, cert, chain, sslPolicyErrors) => true;
            label9.Text = login.username;
            textBox11.Text = login.baseurl;
            facebook = Bakaláři.Properties.Settings.Default.facebook;
            jidelna = Bakaláři.Properties.Settings.Default.jidelna;
            XmlTextReader reader = new XmlTextReader(login.baseurl);
            XmlNodeType type;

            while (reader.Read())
            {
                type = reader.NodeType;

                if (type == XmlNodeType.Element)
                {
                    if (reader.Name == "jmeno")
                    {
                        reader.Read();
                        jmeno = reader.Value;
                    }
                    if (reader.Name == "strtyp")
                    {
                        reader.Read();
                        strtyp = reader.Value;
                    }
                    if (reader.Name == "trida")
                    {
                        reader.Read();
                        owntrida = reader.Value;
                        owntrida = owntrida.Substring(0, 3);
                    }
                }
            }
            label1.Text = jmeno + ", " + strtyp;
            reader.Close();
            DateTime daydt;
            daydt = DateTime.Parse(DateTime.Now.ToString("MM.dd.yyyy"), CultureInfo.InvariantCulture);
            dayString = daydt.ToString("dddd", new CultureInfo("cs-CZ"));
            DayString = dayString.Substring(0, 1).ToUpper() + dayString.Substring(1);
            ToolTip tt4 = new ToolTip();
            tt4.InitialDelay = 100;
            tt4.ReshowDelay = 100;
            tt4.SetToolTip(label8, DayString);
        }
        private void namedayFunction()
        {
            XmlReader readers = XmlReader.Create("https://pastebin.com/raw/b1XgASAZ");
            while (readers.Read())
            {
                if (readers.IsStartElement())
                {
                    switch (readers.Name)
                    {
                        case "date":
                            readers.Read();
                            date = readers.Value;
                            statni = "";
                            break;
                        case "name":
                            readers.Read();
                            nameday = readers.Value;
                            if (date == cdate)
                            {
                                label13.Text = nameday;
                            }
                            break;
                        case "statni":
                            readers.Read();
                            statni = readers.Value;
                            if (date == cdate)
                            {
                                if (statni != null)
                                {
                                    pictureBox4.Visible = true;
                                    ToolTip tt = new ToolTip();
                                    tt.InitialDelay = 100;
                                    tt.ReshowDelay = 100;
                                    tt.SetToolTip(this.pictureBox4, statni);
                                }
                            }
                            break;
                    }
                }
            }
            readers.Close();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                namedayFunction();
                callOnLoad();
            }
            catch
            {
                MessageBox.Show("Něco se nepodařilo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Opravdu chcete ukončit Bakaláře?", "Bakaláři", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                opener.Close();
                this.Close();
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
        public void button2_Click_1(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            this.Hide();
            notifyIcon1.ShowBalloonTip(3000, "Bakaláři jsou stále otevřeny", "Upozorní Vás na novou známku", ToolTipIcon.Info);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label8.Text = DateTime.Now.ToString("dd.MM.yyyy  HH:mm:ss");
        }
        private void button12_Click(object sender, EventArgs e)
        {
            try { System.Diagnostics.Process p = System.Diagnostics.Process.Start("calc.exe"); }
            catch { }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            facebook = Bakaláři.Properties.Settings.Default.facebook;
            try { System.Diagnostics.Process.Start(facebook); }
            catch { }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            jidelna = Bakaláři.Properties.Settings.Default.jidelna;
            try { System.Diagnostics.Process.Start(jidelna); }
            catch { }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (Bakaláři.Properties.Settings.Default.settCal2 == "Vlastní třída")
            {
                Form frmm = new calendar(this);
                try { frmm.Show(); }
                catch { }
            }
            else
            {
                Form frmm2 = new calendar2(this);
                try { frmm2.Show(); }
                catch { }
            }
        }
        private void button13_Click(object sender, EventArgs e)
        {
            Form settfrm = new sett(this);
            try { settfrm.Show(); }
            catch { }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Form absencefrm = new absence(this);
            try { absencefrm.Show(); }
            catch { }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form znamkyfrm = new znamky(this);
            try { znamkyfrm.Show(); }
            catch { }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Form pololetifrm = new pololeti(this);
            try { pololetifrm.Show(); }
            catch { }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Form ukolyfrm = new ukoly(this);
            try { ukolyfrm.Show(); }
            catch { }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Form rozvrhfrm = new rozvrh(this);
            try { rozvrhfrm.Show(); }
            catch { }
        }
        private void csToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
        }
        private void ukončitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            opener.Close();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                den = DateTime.Now.ToString("dd");
                if (den != cden)
                {
                    logname = Bakaláři.Properties.Settings.Default.usernamecache;
                    string urlsalt = Bakaláři.Properties.Settings.Default.link + basesalt + logname;
                    URLloginsalt = Bakaláři.Properties.Settings.Default.link + basesalt + Bakaláři.Properties.Settings.Default.usernamecache;
                    xdate = System.DateTime.Today.ToString("yyyyMMdd");
                    XmlTextReader reader = new XmlTextReader(URLloginsalt);
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
                            }
                            xsalted = xsalted + Bakaláři.Properties.Settings.Default.passwordcache;
                            hsalted = menugui.GenerateSHA512String(xsalted);
                            hxsalted = menugui.ConvertHexStringToBase64(hsalted);
                            orgtoken = "*login*" + logname + "*pwd*" + hxsalted + "*sgn*ANDR" + xdate;
                            token = menugui.GenerateSHA512String(orgtoken);
                            xtoken = menugui.ConvertHexStringToBase64(token);
                            xtoken = xtoken.Replace('/', '_');
                            xtoken = xtoken.Replace('+', '-');
                            fulltoken = xtoken.Replace('\\', '_');
                            login.bazeurl = Bakaláři.Properties.Settings.Default.link + "?hx=" + fulltoken;
                            cden = den;
                            textBox11.Text = login.bazeurl;
                        }
                    XElement xele = XElement.Load(login.bazeurl + "&pm=znamky");
                    xele.Descendants("znamky").Elements("znamka").Select(f => new
                    {
                        znamka = f.Element("znamka").Value,
                    }).ToList().ForEach(f =>
                    {
                        c++;
                    });
                    if (cache == 0)
                    {
                        cache = c;
                    }
                    if (cache != c)
                    {
                        ndate = DateTime.Now.ToString("yMMdHHmm");
                        ndateint = Convert.ToInt32(ndate);
                        ndateint = ndateint - 5;
                        xele.Descendants("znamky").Elements("znamka").Select(f => new
                        {
                            znamka = f.Element("znamka").Value,
                            udeleno = f.Element("udeleno").Value,
                            pred = f.Element("pred").Value,
                            vaha = f.Element("vaha").Value
                        }).ToList().ForEach(f =>
                        {
                            if (Convert.ToInt32(f.udeleno) == ndateint || Convert.ToInt32(f.udeleno) > ndateint)
                            {
                                notifyIcon1.ShowBalloonTip(5000, "Nová známka!", "Známka: " + f.znamka + " (" + f.vaha + ")" + " z " + f.pred, ToolTipIcon.Info);
                            }
                        });
                        cache = c;
                    }
                    c = 0;
                }
            }
            catch { }
        }
        public static string GenerateSHA512String(string inputString)
        {
            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha512.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }
        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }
        public static string ConvertHexStringToBase64(string hexString)
        {
            byte[] buffer = new byte[hexString.Length / 2];
            for (int i = 0; i < hexString.Length; i++)
            {
                buffer[i / 2] = Convert.ToByte(Convert.ToInt32(hexString.Substring(i, 2), 16));
                i += 1;
            }
            string res = Convert.ToBase64String(buffer);
            return res;
        }
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
        }

        private void zkontrolovatAktualizaceToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void button14_Click(object sender, EventArgs e)
        {
            logname = Bakaláři.Properties.Settings.Default.usernamecache;
            string urlsalt = Bakaláři.Properties.Settings.Default.link + basesalt + logname;
            URLloginsalt = Bakaláři.Properties.Settings.Default.link + basesalt + Bakaláři.Properties.Settings.Default.usernamecache;
            xdate = System.DateTime.Today.ToString("yyyyMMdd");
            XmlTextReader reader = new XmlTextReader(URLloginsalt);
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
                    }
                    xsalted = xsalted + Bakaláři.Properties.Settings.Default.passwordcache;
                    hsalted = menugui.GenerateSHA512String(xsalted);
                    hxsalted = menugui.ConvertHexStringToBase64(hsalted);
                    orgtoken = "*login*" + logname + "*pwd*" + hxsalted + "*sgn*ANDR" + xdate;
                    token = menugui.GenerateSHA512String(orgtoken);
                    xtoken = menugui.ConvertHexStringToBase64(token);
                    xtoken = xtoken.Replace('/', '_');
                    xtoken = xtoken.Replace('+', '-');
                    fulltoken = xtoken.Replace('\\', '_');
                    login.bazeurl = Bakaláři.Properties.Settings.Default.link + "?hx=" + fulltoken;
                    cden = den;
                    textBox11.Text = login.bazeurl;
                }
        }

        private void známkyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            button3.PerformClick();
            this.Hide();
        }

        private void rozvrhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            button5.PerformClick();
            this.Hide();
        }

        private void úkolyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            button7.PerformClick();
            this.Hide();
        }

        private void absenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            button6.PerformClick();
            this.Hide();
        }

        private void kalendářToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            button11.PerformClick();
            this.Hide();
        }
    }
}
