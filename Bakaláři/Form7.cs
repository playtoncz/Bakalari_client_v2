using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Globalization;

namespace Bakaláři
{
    public partial class calendar2 : Form
    {
        int mov;
        int movX;
        int movY;
        int c;
        int h = 0;
        int h2 = 0;
        int h3 = 0;
        int h4 = 0;
        int h5 = 0;
        int pbh = -1;
        int pblineh = 32;
        public static string calurl = "";
        public static string now = DateTime.Now.ToString("yyyyMMdd");
        int nowint = Int32.Parse(now);
        public static string date = "";
        public static string day = "";
        public static int dayint;
        public static string dayString = "";
        public static string DayString = "";
        public static string nazev = "";
        public static string nazevtt = "";
        public static string datum = "";
        public static string cas = "";
        public static string cas1 = "";
        public static string cas2 = "";
        public static string tsString = "";
        public static string tsStringNula = "";
        public static string casposun = "";
        public static string ucitel = "";
        public static string trida = "";
        public static string tridatt = "";
        public static string uciteltt = "";
        public calendar2(Form parentForm)
        {
            InitializeComponent();
            calurl = login.bazeurl + "&pm=akce";
            panel1.MaximumSize = new Size(710, 1600);
            panel1.Focus();
            if (Bakaláři.Properties.Settings.Default.settCalDate != 1)
            {
                nowint = Bakaláři.Properties.Settings.Default.settCalDate;
            }
            try
            {
                XmlTextReader calcal = new XmlTextReader(calurl);
                {
                    while (calcal.Read())
                    {
                        if (calcal.IsStartElement())
                        {
                            switch (calcal.Name)
                            {
                                case "datum":
                                    date = calcal.ReadString();
                                    int dateintx = Int32.Parse(date);
                                    if (nowint <= dateintx)
                                    {
                                        c++;
                                    }
                                    break;
                            }
                        }
                    }
                }
                if (c < 13)
                {
                    panel1.AutoScroll = false;
                    XmlTextReader calreader = new XmlTextReader(calurl);
                    {
                        while (calreader.Read())
                        {
                            if (calreader.IsStartElement())
                            {
                                switch (calreader.Name)
                                {
                                    case "nazev":
                                        nazev = calreader.ReadString();
                                        nazevtt = nazev;
                                        if (nazev.Length > 32)
                                        {
                                            nazev = nazev.Substring(0, 32) + "...";
                                        }
                                        uciteltt = "";
                                        tsString = "";
                                        break;
                                    case "cas":
                                        cas = calreader.ReadString();
                                        if (cas.Length > 1)
                                        {
                                            if (cas.Length < 13)
                                            {
                                                if (cas.Length < 12)
                                                {
                                                    if (cas.Length < 6)
                                                    {
                                                        if (cas.Length < 5)
                                                        {
                                                            casposun = ""; //H:MM
                                                            cas1 = cas.Substring(0, 4);
                                                            cas2 = cas.Substring(0, 4);
                                                            cas1 = "0" + cas1;
                                                            cas2 = "0" + cas2;
                                                        }
                                                        else
                                                        {
                                                            casposun = ""; //HH:MM
                                                            cas1 = cas.Substring(0, 5);
                                                            cas2 = cas.Substring(0, 5);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        casposun = "   "; //H:MM - H:MM
                                                        cas1 = cas.Substring(0, 4);
                                                        cas2 = cas.Substring(7, 4);
                                                        cas1 = "0" + cas1;
                                                        cas2 = "0" + cas2;
                                                    }
                                                }
                                                else
                                                {
                                                    casposun = "  "; //H:MM - HH:MM
                                                    cas1 = cas.Substring(0, 4);
                                                    cas2 = cas.Substring(7, 5);
                                                    cas1 = "0" + cas1;
                                                }
                                            }
                                            if (cas.Length == 13)
                                            {
                                                cas1 = cas.Substring(0, 5);
                                                cas2 = cas.Substring(8, 5);
                                            }
                                            DateTime casdt1 = DateTime.ParseExact(cas1, "HH:mm", new CultureInfo("cs-CZ"));
                                            DateTime casdt2 = DateTime.ParseExact(cas2, "HH:mm", new CultureInfo("cs-CZ"));
                                            TimeSpan ts = casdt2.Subtract(casdt1);
                                            tsString = ts.ToString();
                                            tsString = tsString.Substring(0, 5);
                                            tsStringNula = tsString.Substring(0, 1);
                                            if (tsStringNula == "0")
                                            {
                                                tsString = tsString.Substring(1, 4);
                                            }
                                        }
                                        else
                                        {
                                            casposun = ""; //HH:MM - HH:MM
                                        }
                                        break;
                                    case "datum":
                                        date = calreader.ReadString();
                                        datum = date.Substring(6, 2) + "." + date.Substring(4, 2) + "." + date.Substring(0, 4);
                                        day = date.Substring(0, 4) + ", " + date.Substring(4, 2) + ", " + date.Substring(6, 2);
                                        break;
                                    case "proucitele":
                                        ucitel = calreader.ReadString();
                                        uciteltt = ucitel;
                                        if (ucitel.Length > 13)
                                        {
                                            ucitel = ucitel.Substring(0, 13) + "...";
                                        }
                                        break;
                                    case "protridy":
                                        trida = calreader.ReadString();
                                        tridatt = trida;
                                        if (trida.Length > 8)
                                        {
                                            trida = trida.Substring(0, 8) + "...";
                                        }
                                        int dateintx = Int32.Parse(date);
                                        if (nowint <= dateintx)
                                        {
                                            Label lbl = new Label();
                                            panel1.Controls.Add(lbl);
                                            lbl.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                            lbl.Location = new System.Drawing.Point(0, h);
                                            lbl.TextAlign = ContentAlignment.MiddleLeft;
                                            lbl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                            lbl.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                            lbl.Size = new System.Drawing.Size(268, 33);
                                            lbl.Text = "  " + nazev;
                                            ToolTip tt1 = new ToolTip();
                                            tt1.InitialDelay = 100;
                                            tt1.ReshowDelay = 100;
                                            tt1.SetToolTip(lbl, nazevtt);
                                            h = h + 32;
                                            /////////////////////////////
                                            Label lbl2 = new Label();
                                            panel1.Controls.Add(lbl2);
                                            lbl2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                            lbl2.Location = new System.Drawing.Point(358, h2);
                                            lbl2.TextAlign = ContentAlignment.MiddleCenter;
                                            lbl2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                            lbl2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                            lbl2.Size = new System.Drawing.Size(89, 33);
                                            lbl2.Text = datum;
                                            DateTime daydt;
                                            daydt = DateTime.Parse(day, CultureInfo.InvariantCulture);
                                            dayString = daydt.ToString("dddd", new CultureInfo("cs-CZ"));
                                            DayString = dayString.Substring(0, 1).ToUpper() + dayString.Substring(1);
                                            ToolTip tt4 = new ToolTip();
                                            tt4.InitialDelay = 100;
                                            tt4.ReshowDelay = 100;
                                            tt4.SetToolTip(lbl2, DayString);
                                            h2 = h2 + 32;
                                            /////////////////////////////                                    
                                            Label lbl3 = new Label();
                                            panel1.Controls.Add(lbl3);
                                            lbl3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                            lbl3.Location = new System.Drawing.Point(448, h3);
                                            lbl3.TextAlign = ContentAlignment.MiddleCenter;
                                            lbl3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                            lbl3.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                            lbl3.Size = new System.Drawing.Size(108, 33);
                                            lbl3.Text = casposun + cas;
                                            ToolTip tt5 = new ToolTip();
                                            tt5.InitialDelay = 100;
                                            tt5.ReshowDelay = 100;
                                            tt5.SetToolTip(lbl3, tsString);
                                            cas1 = "";
                                            cas2 = "";
                                            tsString = "";
                                            h3 = h3 + 32;
                                            /////////////////////////////
                                            Label lbl4 = new Label();
                                            panel1.Controls.Add(lbl4);
                                            lbl4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                            lbl4.Location = new System.Drawing.Point(557, h4);
                                            lbl4.Size = new System.Drawing.Size(153, 33);
                                            lbl4.Text = ucitel;
                                            lbl4.TextAlign = ContentAlignment.MiddleCenter;
                                            lbl4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                            lbl4.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                            ToolTip tt2 = new ToolTip();
                                            tt2.InitialDelay = 100;
                                            tt2.ReshowDelay = 100;
                                            tt2.SetToolTip(lbl4, uciteltt);
                                            h4 = h4 + 32;
                                            /////////////////////////////
                                            Label lbl5 = new Label();
                                            panel1.Controls.Add(lbl5);
                                            lbl5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                            lbl5.Location = new System.Drawing.Point(269, h5);
                                            lbl5.Size = new System.Drawing.Size(89, 33);
                                            lbl5.Text = trida;
                                            lbl5.TextAlign = ContentAlignment.MiddleCenter;
                                            lbl5.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                            lbl5.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                            ToolTip tt3 = new ToolTip();
                                            tt3.InitialDelay = 100;
                                            tt3.ReshowDelay = 100;
                                            tt3.SetToolTip(lbl5, tridatt);
                                            h5 = h5 + 32;
                                            ////
                                            PictureBox pb = new PictureBox();
                                            panel1.Controls.Add(pb);
                                            pb.Location = new System.Drawing.Point(0, pbh);
                                            pb.Size = new System.Drawing.Size(710, 33);
                                            pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                            lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                            lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                            lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                            lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                            lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                            pb.MouseEnter += (sender, e) =>
                                            {
                                                pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                            };
                                            pb.MouseLeave += (sender, e) =>
                                            {
                                                pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                            };
                                            lbl.MouseEnter += (sender, e) =>
                                            {
                                                pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                            };
                                            lbl.MouseLeave += (sender, e) =>
                                            {
                                                pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                            };
                                            lbl2.MouseEnter += (sender, e) =>
                                            {
                                                pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                            };
                                            lbl2.MouseLeave += (sender, e) =>
                                            {
                                                pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                            };
                                            lbl3.MouseEnter += (sender, e) =>
                                            {
                                                pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                            };
                                            lbl3.MouseLeave += (sender, e) =>
                                            {
                                                pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                            };
                                            lbl4.MouseEnter += (sender, e) =>
                                            {
                                                pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                            };
                                            lbl4.MouseLeave += (sender, e) =>
                                            {
                                                pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                            };
                                            lbl5.MouseEnter += (sender, e) =>
                                            {
                                                pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                            };
                                            lbl5.MouseLeave += (sender, e) =>
                                            {
                                                pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                            };
                                            pbh = pbh + 32;
                                            ///////////////////////
                                            PictureBox pbline = new PictureBox();
                                            panel1.Controls.Add(pbline);
                                            pbline.BackColor = System.Drawing.Color.Silver;
                                            pbline.Location = new System.Drawing.Point(0, pblineh);
                                            pbline.Size = new System.Drawing.Size(710, 1);
                                            pbline.BringToFront();
                                            pbline.TabStop = false;
                                            pbline.MouseEnter += (sender, e) =>
                                            {
                                                pbline.BackColor = System.Drawing.Color.Gainsboro;
                                            };
                                            pbline.MouseLeave += (sender, e) =>
                                            {
                                                pbline.BackColor = System.Drawing.Color.Silver;
                                            };
                                            pblineh = pblineh + 32;
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    XmlTextReader calreader = new XmlTextReader(calurl);
                    {
                        while (calreader.Read())
                        {
                            if (calreader.IsStartElement())
                            {
                                switch (calreader.Name)
                                {
                                    case "nazev":
                                        nazev = calreader.ReadString();
                                        nazevtt = nazev;
                                        if (nazev.Length > 32)
                                        {
                                            nazev = nazev.Substring(0, 32) + "...";
                                        }
                                        uciteltt = "";
                                        tsString = "";
                                        break;
                                    case "cas":
                                        cas = calreader.ReadString();
                                        if (cas.Length > 1)
                                        {
                                            if (cas.Length < 13)
                                            {
                                                if (cas.Length < 12)
                                                {
                                                    if (cas.Length < 6)
                                                    {
                                                        if (cas.Length < 5)
                                                        {
                                                            casposun = ""; //H:MM
                                                            cas1 = cas.Substring(0, 4);
                                                            cas2 = cas.Substring(0, 4);
                                                            cas1 = "0" + cas1;
                                                            cas2 = "0" + cas2;
                                                        }
                                                        else
                                                        {
                                                            casposun = ""; //HH:MM
                                                            cas1 = cas.Substring(0, 5);
                                                            cas2 = cas.Substring(0, 5);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        casposun = "   "; //H:MM - H:MM
                                                        cas1 = cas.Substring(0, 4);
                                                        cas2 = cas.Substring(7, 4);
                                                        cas1 = "0" + cas1;
                                                        cas2 = "0" + cas2;
                                                    }
                                                }
                                                else
                                                {
                                                    casposun = "  "; //H:MM - HH:MM
                                                    cas1 = cas.Substring(0, 4);
                                                    cas2 = cas.Substring(7, 5);
                                                    cas1 = "0" + cas1;
                                                }
                                            }
                                            if (cas.Length == 13)
                                            {
                                                cas1 = cas.Substring(0, 5);
                                                cas2 = cas.Substring(8, 5);
                                            }
                                            DateTime casdt1 = DateTime.ParseExact(cas1, "HH:mm", new CultureInfo("cs-CZ"));
                                            DateTime casdt2 = DateTime.ParseExact(cas2, "HH:mm", new CultureInfo("cs-CZ"));
                                            TimeSpan ts = casdt2.Subtract(casdt1);
                                            tsString = ts.ToString();
                                            tsString = tsString.Substring(0, 5);
                                            tsStringNula = tsString.Substring(0, 1);
                                            if (tsStringNula == "0")
                                            {
                                                tsString = tsString.Substring(1, 4);
                                            }
                                        }
                                        else
                                        {
                                            casposun = ""; //HH:MM - HH:MM
                                        }
                                        break;
                                    case "datum":
                                        date = calreader.ReadString();
                                        datum = date.Substring(6, 2) + "." + date.Substring(4, 2) + "." + date.Substring(0, 4);
                                        day = date.Substring(0, 4) + ", " + date.Substring(4, 2) + ", " + date.Substring(6, 2);
                                        break;
                                    case "proucitele":
                                        ucitel = calreader.ReadString();
                                        uciteltt = ucitel;
                                        if (ucitel.Length > 13)
                                        {
                                            ucitel = ucitel.Substring(0, 13) + "...";
                                        }
                                        break;
                                    case "protridy":
                                        trida = calreader.ReadString();
                                        tridatt = trida;
                                        if (trida.Length > 8)
                                        {
                                            trida = trida.Substring(0, 8) + "...";
                                        }                    
                                        int dateintx = Int32.Parse(date);
                                        if (nowint <= dateintx)
                                        {
                                            Label lbl = new Label();
                                            panel1.Controls.Add(lbl);
                                            lbl.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                            lbl.Location = new System.Drawing.Point(0, h);
                                            lbl.TextAlign = ContentAlignment.MiddleLeft;
                                            lbl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                            lbl.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                            lbl.Size = new System.Drawing.Size(268, 33);
                                            lbl.Text = "  " + nazev;
                                            ToolTip tt1 = new ToolTip();
                                            tt1.InitialDelay = 100;
                                            tt1.ReshowDelay = 100;
                                            tt1.SetToolTip(lbl, nazevtt);
                                            h = h + 32;
                                            /////////////////////////////
                                            Label lbl2 = new Label();
                                            panel1.Controls.Add(lbl2);
                                            lbl2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                            lbl2.Location = new System.Drawing.Point(358, h2);
                                            lbl2.TextAlign = ContentAlignment.MiddleCenter;
                                            lbl2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                            lbl2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                            lbl2.Size = new System.Drawing.Size(89, 33);
                                            lbl2.Text = datum;
                                            DateTime daydt;
                                            daydt = DateTime.Parse(day, CultureInfo.InvariantCulture);
                                            dayString = daydt.ToString("dddd", new CultureInfo("cs-CZ"));
                                            DayString = dayString.Substring(0, 1).ToUpper() + dayString.Substring(1);
                                            ToolTip tt4 = new ToolTip();
                                            tt4.InitialDelay = 100;
                                            tt4.ReshowDelay = 100;
                                            tt4.SetToolTip(lbl2, DayString);
                                            h2 = h2 + 32;
                                            /////////////////////////////                                    
                                            Label lbl3 = new Label();
                                            panel1.Controls.Add(lbl3);
                                            lbl3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                            lbl3.Location = new System.Drawing.Point(448, h3);
                                            lbl3.TextAlign = ContentAlignment.MiddleCenter;
                                            lbl3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                            lbl3.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                            lbl3.Size = new System.Drawing.Size(108, 33);
                                            lbl3.Text = casposun + cas;
                                            ToolTip tt5 = new ToolTip();
                                            tt5.InitialDelay = 100;
                                            tt5.ReshowDelay = 100;
                                            tt5.SetToolTip(lbl3, tsString);
                                            cas1 = "";
                                            cas2 = "";
                                            tsString = "";
                                            h3 = h3 + 32;
                                            /////////////////////////////
                                            Label lbl4 = new Label();
                                            panel1.Controls.Add(lbl4);
                                            lbl4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                            lbl4.Location = new System.Drawing.Point(557, h4);
                                            lbl4.Size = new System.Drawing.Size(135, 33);
                                            lbl4.Text = ucitel;
                                            lbl4.TextAlign = ContentAlignment.MiddleCenter;
                                            lbl4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                            lbl4.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                            ToolTip tt2 = new ToolTip();
                                            tt2.InitialDelay = 100;
                                            tt2.ReshowDelay = 100;
                                            tt2.SetToolTip(lbl4, uciteltt);
                                            h4 = h4 + 32;
                                            /////////////////////////////
                                            Label lbl5 = new Label();
                                            panel1.Controls.Add(lbl5);
                                            lbl5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                            lbl5.Location = new System.Drawing.Point(269, h5);
                                            lbl5.Size = new System.Drawing.Size(89, 33);
                                            lbl5.Text = trida;
                                            lbl5.TextAlign = ContentAlignment.MiddleCenter;
                                            lbl5.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                            lbl5.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                            ToolTip tt3 = new ToolTip();
                                            tt3.InitialDelay = 100;
                                            tt3.ReshowDelay = 100;
                                            tt3.SetToolTip(lbl5, tridatt);
                                            h5 = h5 + 32;
                                            ////
                                            PictureBox pb = new PictureBox();
                                            panel1.Controls.Add(pb);
                                            pb.Location = new System.Drawing.Point(1, pbh);
                                            pb.Size = new System.Drawing.Size(692, 33);
                                            pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                            lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                            lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                            lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                            lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                            lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                            pb.MouseEnter += (sender, e) =>
                                            {
                                                pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                            };
                                            pb.MouseLeave += (sender, e) =>
                                            {
                                                pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                            };
                                            lbl.MouseEnter += (sender, e) =>
                                            {
                                                pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                            };
                                            lbl.MouseLeave += (sender, e) =>
                                            {
                                                pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                            };
                                            lbl2.MouseEnter += (sender, e) =>
                                            {
                                                pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                            };
                                            lbl2.MouseLeave += (sender, e) =>
                                            {
                                                pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                            };
                                            lbl3.MouseEnter += (sender, e) =>
                                            {
                                                pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                            };
                                            lbl3.MouseLeave += (sender, e) =>
                                            {
                                                pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                            };
                                            lbl4.MouseEnter += (sender, e) =>
                                            {
                                                pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                            };
                                            lbl4.MouseLeave += (sender, e) =>
                                            {
                                                pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                            };
                                            lbl5.MouseEnter += (sender, e) =>
                                            {
                                                pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                                lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                            };
                                            lbl5.MouseLeave += (sender, e) =>
                                            {
                                                pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                                lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                            };
                                            pbh = pbh + 32;
                                            //////////////////
                                            PictureBox pbline = new PictureBox();
                                            panel1.Controls.Add(pbline);
                                            pbline.BackColor = System.Drawing.Color.Silver;
                                            pbline.Location = new System.Drawing.Point(0, pblineh);
                                            pbline.Size = new System.Drawing.Size(692, 1);
                                            pbline.BringToFront();
                                            pbline.TabStop = false;
                                            pbline.MouseEnter += (sender, e) =>
                                            {
                                                pbline.BackColor = System.Drawing.Color.Gainsboro;
                                            };
                                            pbline.MouseLeave += (sender, e) =>
                                            {
                                                pbline.BackColor = System.Drawing.Color.Silver;
                                            };
                                            pblineh = pblineh + 32;
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Něco se nepodařilo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void calendar_Load(object sender, EventArgs e)
        {
            panel1.Focus();
        }
        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.Focus();
        }
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox2.BackColor = System.Drawing.Color.Gainsboro;
        }
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox2.BackColor = System.Drawing.Color.Silver;
        }
        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox3.BackColor = System.Drawing.Color.Gainsboro;
        }
        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox3.BackColor = System.Drawing.Color.Silver;
        }
        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox4.BackColor = System.Drawing.Color.Gainsboro;
        }
        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox4.BackColor = System.Drawing.Color.Silver;
        }
        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox5.BackColor = System.Drawing.Color.Gainsboro;
        }
        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox5.BackColor = System.Drawing.Color.Silver;
        }
        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox6.BackColor = System.Drawing.Color.Gainsboro;
        }
        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox6.BackColor = System.Drawing.Color.Silver;
        }
    }
}
