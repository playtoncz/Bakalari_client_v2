using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Bakaláři
{
    public partial class absence : Form
    {
        int mov;
        int movX;
        int movY;
        int off = 0;
        int off2 = 0;
        int offzp = 0;
        int offpa = 0;
        int offzpp = 0;
        int offsa = 0;
        int offsap = 0;
        int tb1int = 0;
        int tb2int = 0;
        decimal procentosa;
        decimal procentosa1;
        decimal procentosa2;
        string procentosas;
        public static string procentott = "";
        public static string nazev = "";
        public static string procentost = "";
        public static string procentost2 = "";
        public static string datumabs = "";
        public static string den = "";
        public static string denPa = "";
        public static string ttrok = "";
        public static string A = "";
        public static string AOk = "";
        public static string AMiss = "";
        public static string ALate = "";
        public static string ASoon = "";
        public static string ASchool = "";
        public static decimal oduceno = 0;
        public static decimal absbase = 0;
        public static decimal procento = 0;
        public static int procentoint = 0;
        public static int hranice = Convert.ToInt32(Bakaláři.Properties.Settings.Default.hranice);
        public static int h2 = 0;
        public static string absenceurl = login.bazeurl + "&pm=absence";

        public absence(Form parrentform)
        {
        try { 
            InitializeComponent();
            hranice = Convert.ToInt32(Bakaláři.Properties.Settings.Default.hranice);
            int h = 0;
            h2 = 0;
            int pblineh = 27;
            int pblineh2 = 27;
            offzpp = 0;
            procento = 0;
            procentosa = 0;
            procentosa1 = 0;
            procentosa2 = 0;
            procentosas = "";
            procentoint = 0;
            oduceno = 0;
            absbase = 0;
            procentott = "";
            procentost = "";
            procentost2 = "";
            nazev = "";
            tb1int = 0;
            tb2int = 0;
            panel4.Size = new System.Drawing.Size(286, 27);
            panel5.Location = new System.Drawing.Point(286, 0);
            saaPanel.Size = new System.Drawing.Size(546, 392);
            //Tooltipy na kategorie
            ToolTip tk1 = new ToolTip();
            tk1.InitialDelay = 100;
            tk1.ReshowDelay = 100;
            tk1.SetToolTip(pictureBox18, "Absence");
            ToolTip tk2 = new ToolTip();
            tk2.InitialDelay = 100;
            tk2.ReshowDelay = 100;
            tk2.SetToolTip(pictureBox20, "Omluvená absence");
            ToolTip tk3 = new ToolTip();
            tk3.InitialDelay = 100;
            tk3.ReshowDelay = 100;
            tk3.SetToolTip(pictureBox22, "Neomluvená absence");
            ToolTip tk4 = new ToolTip();
            tk4.InitialDelay = 100;
            tk4.ReshowDelay = 100;
            tk4.SetToolTip(pictureBox24, "Pozdní příchod");
            ToolTip tk5 = new ToolTip();
            tk5.InitialDelay = 100;
            tk5.ReshowDelay = 100;
            tk5.SetToolTip(pictureBox26, "Nezapočtená absence");
            ToolTip tk6 = new ToolTip();
            tk6.InitialDelay = 100;
            tk6.ReshowDelay = 100;
            tk6.SetToolTip(pictureBox28, "Brzký odchod");
            //count off
            XElement xele = XElement.Load(absenceurl);
            xele.Descendants("predmet").Select(f => new
            {
                f.Element("nazev").Value
            }).ToList().ForEach(f =>
            {
                offzp++;
            });
            if (offzp > 14) //14
            {
                off = 17;
                pictureBox16.Size = new System.Drawing.Size(588, 1);
                pictureBox17.Location = new System.Drawing.Point(401, 0);
                pictureBox19.Location = new System.Drawing.Point(428, 0);
                pictureBox21.Location = new System.Drawing.Point(455, 0);
                pictureBox23.Location = new System.Drawing.Point(482, 0);
                pictureBox25.Location = new System.Drawing.Point(509, 0);
                pictureBox27.Location = new System.Drawing.Point(536, 0);
                pictureBox29.Location = new System.Drawing.Point(563, 0);
                pictureBox8.Size = new System.Drawing.Size(224, 1);
                button4.Location = new System.Drawing.Point(493, 0);
                button1.Location = new System.Drawing.Point(528, 0);
                panelx.Size = new System.Drawing.Size(493, 39);
                panel1.Size = new System.Drawing.Size(563, 27);
                zvpPanel.Size = new System.Drawing.Size(563, 420);
                paPanel.Location = new System.Drawing.Point(304, 28);
                saPanel.Size = new System.Drawing.Size(563, 420);
                saaPanel.Size = new System.Drawing.Size(563, 392);
                pictureBox31.Size = new System.Drawing.Size(563, 1);
                saaPanel.AutoScroll = true;
                ClientSize = new System.Drawing.Size(563, 483);
                panel7.Size = new System.Drawing.Size(563, 27);
                zvPanel.AutoScroll = true;
                zvPanel.Size = new System.Drawing.Size(303, 392); //392
                pictureBox14.BringToFront();
                panel4.Size = new System.Drawing.Size(303, 27);
                panel5.Location = new System.Drawing.Point(304, 0);
                PictureBox pbline2 = new PictureBox();
                pbline2.BackColor = System.Drawing.Color.Silver;
                pbline2.Location = new System.Drawing.Point(303, 0);
                pbline2.Size = new System.Drawing.Size(1, 420);
                pbline2.MouseEnter += (sender, e) =>
                {
                    pbline2.BackColor = System.Drawing.Color.Gainsboro;
                };
                pbline2.MouseLeave += (sender, e) =>
                {
                    pbline2.BackColor = System.Drawing.Color.Silver;
                };
                zvpPanel.Controls.Add(pbline2);
                pbline2.BringToFront();
                offzpp = 1;
                offsa = 0;
                offsap = -17;
            }
            //count off2
            xele.Descendants("abs").Select(f => new
            {
                f.Element("datum").Value
            }).ToList().ForEach(f =>
            {
                offpa++;
            });
            if (offpa > 14) //14
            {
                if (offzpp == 0)
                { 
                off2 = 17;
                ClientSize = new System.Drawing.Size(563, 483);
                button4.Location = new System.Drawing.Point(493, 0);
                button1.Location = new System.Drawing.Point(528, 0);
                zvpPanel.Size = new System.Drawing.Size(563, 420);
                paPanel.AutoScroll = true;
                paPanel.Size = new System.Drawing.Size(277, 392); //392
                saPanel.Size = new System.Drawing.Size(563, 420);
                saaPanel.Size = new System.Drawing.Size(563, 392);
                saaPanel.AutoScroll = true;
                pictureBox31.Size = new System.Drawing.Size(563, 1);
                panelx.Size = new System.Drawing.Size(493, 39);
                panel1.Size = new System.Drawing.Size(563, 27);
                panel5.Size = new System.Drawing.Size(277, 27);
                panel7.Size = new System.Drawing.Size(563, 27);
                pictureBox8.Size = new System.Drawing.Size(199, 1);
                pictureBox16.Size = new System.Drawing.Size(563, 1);
                offsa = 17;
                offsap = 17;
                }
                else
                {
                    off2 = 17;
                    ClientSize = new System.Drawing.Size(580, 483);
                    button4.Location = new System.Drawing.Point(510, 0);
                    button1.Location = new System.Drawing.Point(545, 0);
                    zvpPanel.Size = new System.Drawing.Size(580, 420);
                    paPanel.AutoScroll = true;
                    paPanel.Size = new System.Drawing.Size(277, 392); //392
                    saPanel.Size = new System.Drawing.Size(580, 420);
                    saaPanel.Size = new System.Drawing.Size(580, 392);
                    saaPanel.AutoScroll = true;
                    pictureBox31.Size = new System.Drawing.Size(580, 1);
                    panelx.Size = new System.Drawing.Size(510, 39);
                    panel1.Size = new System.Drawing.Size(580, 27);
                    panel5.Size = new System.Drawing.Size(294, 27);
                    panel7.Size = new System.Drawing.Size(580, 27);
                    pictureBox8.Size = new System.Drawing.Size(216, 1);
                    pictureBox16.Size = new System.Drawing.Size(580, 1);
                    offsa = 34;
                    offsap = 17;
                }
            }
            //Zameskanost
            xele.Descendants("zameskanost").Select(k => new
            {
                nadpis = k.Element("nadpis").Value,
            }).ToList().ForEach(k =>
            {
                label4.Text = k.nadpis;
            });
                //ZPPANEL
                xele.Descendants("predmet").Select(j => new
            {
                nazev = j.Element("nazev").Value,
                oduceno = j.Element("oduceno").Value,
                absbase = j.Element("absbase").Value
            }).ToList().ForEach(j =>
            {
                //předmět
                Label lbl1 = new Label();
                zvPanel.Controls.Add(lbl1);
                lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                lbl1.ForeColor = System.Drawing.Color.Black;
                lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                lbl1.Location = new System.Drawing.Point(0, 0 + h);
                lbl1.Size = new System.Drawing.Size(229, 28);
                lbl1.TextAlign = ContentAlignment.MiddleLeft;
                lbl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                lbl1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                nazev = j.nazev;
                nazev = "  " + nazev;
                lbl1.Text = nazev;
                if (nazev.Length > 28)
                {
                    nazev = nazev.Substring(0, 28);
                    lbl1.Text = nazev + "...";
                }
                //tooltip předmět
                ToolTip tt1 = new ToolTip();
                tt1.InitialDelay = 100;
                tt1.ReshowDelay = 100;
                tt1.SetToolTip(lbl1, j.nazev);
                //pbline
                PictureBox pbline = new PictureBox();
                zvPanel.Controls.Add(pbline);
                pbline.BackColor = System.Drawing.Color.Silver;
                pbline.Location = new System.Drawing.Point(0, pblineh);
                pbline.Size = new System.Drawing.Size(302 - off, 1);
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
                //procento
                Label lbl2 = new Label();
                zvPanel.Controls.Add(lbl2);
                lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                lbl2.ForeColor = System.Drawing.Color.Black;
                lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                lbl2.Location = new System.Drawing.Point(229, 0 + h);
                lbl2.Size = new System.Drawing.Size(57, 28);
                lbl2.TextAlign = ContentAlignment.MiddleCenter;
                lbl2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                lbl2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                procentott = "Celkem: " + j.oduceno + " hodin, Absence: " + j.absbase + " hodin";
                oduceno = Convert.ToDecimal(j.oduceno);
                absbase = Convert.ToDecimal(j.absbase);
                procento = absbase / oduceno * 100;
                procentost = procento.ToString("#.##");
                if (procentost == "")
                {
                    procentost = "0";
                }
                lbl2.Text = procentost + "%";
                //hranice
                if (hranice <= procento)
                {
                    lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                    lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                }
                //tooltip předmět
                ToolTip tt2 = new ToolTip();
                tt2.InitialDelay = 100;
                tt2.ReshowDelay = 100;
                tt2.SetToolTip(lbl2, procentott);
                //gray out předmět
                lbl1.MouseEnter += (sender, e) =>
                {
                    if (lbl2.BackColor == System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192))))))
                    {
                        lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
                        lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
                    }
                    if (lbl2.BackColor == System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252))))))
                    {
                        lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                        lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    }
                };
                lbl1.MouseLeave += (sender, e) =>
                {
                    if (lbl2.BackColor == System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))))
                    {
                        lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                        lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                    }
                    if (lbl2.BackColor == System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247))))))
                    {
                        lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    }
                };
                lbl2.MouseEnter += (sender, e) =>
                {
                    if (lbl1.BackColor == System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192))))))
                    {
                        lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
                        lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
                    }
                    if (lbl1.BackColor == System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252))))))
                    {
                        lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                        lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    }
                };
                lbl2.MouseLeave += (sender, e) =>
                {
                    if (lbl1.BackColor == System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))))
                    {
                        lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                        lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                    }
                    if (lbl1.BackColor == System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247))))))
                    {
                        lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    }
                };
                //předmět SA
                Label slbl1 = new Label();
                saaPanel.Controls.Add(slbl1);
                slbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                slbl1.ForeColor = System.Drawing.Color.Black;
                slbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                slbl1.Location = new System.Drawing.Point(0, 0 + h);
                slbl1.Size = new System.Drawing.Size(229, 27);
                slbl1.TextAlign = ContentAlignment.MiddleLeft;
                slbl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                slbl1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                nazev = j.nazev;
                nazev = "  " + nazev;
                slbl1.Text = nazev;
                if (nazev.Length > 28)
                {
                    nazev = nazev.Substring(0, 28);
                    slbl1.Text = nazev + "...";
                }
                //celkem SA
                Label slbl2 = new Label();
                saaPanel.Controls.Add(slbl2);
                slbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                slbl2.ForeColor = System.Drawing.Color.Black;
                slbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                slbl2.Location = new System.Drawing.Point(229, 0 + h); 
                slbl2.Size = new System.Drawing.Size(93, 27); 
                slbl2.TextAlign = ContentAlignment.MiddleLeft;
                slbl2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                slbl2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                TextBox tb1 = new TextBox();
                saaPanel.Controls.Add(tb1);
                tb1.BackColor = System.Drawing.Color.White;
                tb1.Location = new System.Drawing.Point(264, 3 + h);
                tb1.MaxLength = 3;
                tb1.Size = new System.Drawing.Size(24, 20);
                tb1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                tb1.Text = j.oduceno;
                tb1.BringToFront();
                //zameškáno SA
                Label slbl3 = new Label();
                saaPanel.Controls.Add(slbl3);
                slbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                slbl3.ForeColor = System.Drawing.Color.Black;
                slbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                slbl3.Location = new System.Drawing.Point(323, 0 + h); 
                slbl3.Size = new System.Drawing.Size(93, 27); 
                slbl3.TextAlign = ContentAlignment.MiddleLeft;
                slbl3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                slbl3.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                TextBox tb2 = new TextBox();
                saaPanel.Controls.Add(tb2);
                tb2.BackColor = System.Drawing.Color.White;
                tb2.Location = new System.Drawing.Point(358, 3 + h);
                tb2.MaxLength = 3;
                tb2.Size = new System.Drawing.Size(24, 20);
                tb2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                tb2.Text = j.absbase;
                tb2.BringToFront();
                //procento SA
                procentosa1 = Convert.ToDecimal(tb1.Text);
                procentosa2 = Convert.ToDecimal(tb2.Text);
                if(procentosa1 == 0 || tb1.Text == "" || procentosa2 == 0 || tb2.Text == "")
                {
                    procentosas = "0";
                }
                else
                {
                    procentosa = procentosa2 * 100 / procentosa1;
                    procentosas = procentosa.ToString("#.##");
                    if (procentosas == "")
                    {
                        procentosas = "0";
                    }
                }
                Label slbl4 = new Label();
                saaPanel.Controls.Add(slbl4);
                slbl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                slbl4.ForeColor = System.Drawing.Color.Black;
                slbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                slbl4.Location = new System.Drawing.Point(417, 0 + h); 
                slbl4.Size = new System.Drawing.Size(129 + offsap, 27); 
                slbl4.TextAlign = ContentAlignment.MiddleCenter;
                slbl4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                slbl4.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                slbl4.Text = procentosas + "%";
                if (hranice <= procentosa)
                {
                    slbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                }
                else
                {
                    slbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                }
                tb2.TextChanged += (sender, e) =>
                {
                    int parsedValue;
                    if (int.TryParse(tb1.Text, out parsedValue) && int.TryParse(tb2.Text, out parsedValue))
                    {
                        if (tb1.Text == "0" || tb2.Text == "0")
                        {
                            slbl4.Text = "0%";
                            procentosa = 0;
                        }
                        else
                        {
                            if (tb1.Text != "" && tb2.Text != "")
                            {
                                procentosa1 = Convert.ToDecimal(tb1.Text);
                                procentosa2 = Convert.ToDecimal(tb2.Text);
                                if (procentosa2 > procentosa1)
                                {
                                    procentosa2 = procentosa1;
                                    tb2.Text = tb1.Text;
                                }
                                procentosa = procentosa2 * 100 / procentosa1;
                                procentosas = procentosa.ToString("#.##");
                                if (procentosas == "")
                                {
                                    procentosas = "0";
                                }
                                slbl4.Text = procentosas + "%";
                            }
                            else
                            {
                                slbl4.Text = "0%";
                                procentosa = 0;
                                slbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            }
                        }
                        if (hranice <= procentosa)
                        {
                            if (tb1.Text == "0" || tb2.Text == "0")
                            {
                                procentosa = 0;
                            }
                            if (procentosa != 0)
                            {
                                slbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                            }
                            else
                            {
                                slbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            }
                        }
                        else
                        {
                            slbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        }
                    }
                };
                tb1.TextChanged += (sender, e) =>
                {
                    int parsedValue;
                    if (int.TryParse(tb1.Text, out parsedValue) && int.TryParse(tb2.Text, out parsedValue))
                    {
                        tb1int = Convert.ToInt32(tb1.Text);
                        tb2int = Convert.ToInt32(tb2.Text);
                        if (tb1int >= tb2int)
                        {
                            if (tb1.Text == "0" || tb2.Text == "0")
                            {
                                slbl4.Text = "0%";
                                procentosa = 0;
                            }
                            else
                            {
                                if (tb1.Text != "" && tb2.Text != "")
                                {
                                    procentosa1 = Convert.ToDecimal(tb1.Text);
                                    procentosa2 = Convert.ToDecimal(tb2.Text);
                                    procentosa = procentosa2 * 100 / procentosa1;
                                    procentosas = procentosa.ToString("#.##");
                                    if (procentosas == "")
                                    {
                                        procentosas = "0";
                                    }
                                    slbl4.Text = procentosas + "%";
                                }
                                else
                                {
                                    slbl4.Text = "0%";
                                    procentosa = 0;
                                    slbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                }
                            }
                            if (hranice <= procentosa)
                            {
                                if (tb1.Text == "0" || tb2.Text == "0")
                                {
                                    procentosa = 0;
                                }
                                if (procentosa != 0)
                                {
                                    slbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                                }
                                else
                                {
                                    slbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                }
                            }
                            else
                            {
                                slbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            }
                        }
                        else
                        {
                            tb1.Text = tb2.Text;
                        }
                    }
                };
                //gray out předmět SA
                slbl1.MouseEnter += (sender, e) =>
                {
                    slbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    slbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    slbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    if(slbl4.BackColor == System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252))))))
                    {
                        slbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    }
                    else
                    {
                        slbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
                    }
                };
                slbl1.MouseLeave += (sender, e) =>
                {
                    slbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    slbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    slbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    if (slbl4.BackColor == System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247))))))
                    {
                        slbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    }
                    else
                    {
                        slbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                    }
                };
                slbl2.MouseEnter += (sender, e) =>
                {
                    slbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    slbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    slbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    if (slbl4.BackColor == System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252))))))
                    {
                        slbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    }
                    else
                    {
                        slbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
                    }
                };
                slbl2.MouseLeave += (sender, e) =>
                {
                    slbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    slbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    slbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    if (slbl4.BackColor == System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247))))))
                    {
                        slbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    }
                    else
                    {
                        slbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                    }
                };
                slbl3.MouseEnter += (sender, e) =>
                {
                    slbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    slbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    slbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    if (slbl4.BackColor == System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252))))))
                    {
                        slbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    }
                    else
                    {
                        slbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
                    }
                };
                slbl3.MouseLeave += (sender, e) =>
                {
                    slbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    slbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    slbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    if (slbl4.BackColor == System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247))))))
                    {
                        slbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    }
                    else
                    {
                        slbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                    }
                };
                slbl4.MouseEnter += (sender, e) =>
                {
                    slbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    slbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    slbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    if (slbl4.BackColor == System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252))))))
                    {
                        slbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    }
                    else
                    {
                        slbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
                    }
                };
                slbl4.MouseLeave += (sender, e) =>
                {
                    slbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    slbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    slbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    if (slbl4.BackColor == System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247))))))
                    {
                        slbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    }
                    else
                    {
                        slbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                    }
                };
                //tooltip předmět SA
                ToolTip stt1 = new ToolTip();
                stt1.InitialDelay = 100;
                stt1.ReshowDelay = 100;
                stt1.SetToolTip(slbl1, j.nazev);
                //pbline SA
                PictureBox spbline = new PictureBox();
                saaPanel.Controls.Add(spbline);
                spbline.BackColor = System.Drawing.Color.Silver;
                spbline.Location = new System.Drawing.Point(0, pblineh);
                spbline.Size = new System.Drawing.Size(546 - off + offsa, 1);
                spbline.BringToFront();
                spbline.TabStop = false;
                spbline.MouseEnter += (sender, e) =>
                {
                    spbline.BackColor = System.Drawing.Color.Gainsboro;
                };
                spbline.MouseLeave += (sender, e) =>
                {
                    spbline.BackColor = System.Drawing.Color.Silver;
                };
                pblineh = pblineh + 28;
                h = h + 28;
            });
            xele.Descendants("abs").Select(e => new
            {
                datumabs = e.Element("datum").Value,
                den = e.Element("den").Value,
                A = e.Element("A").Value,
                AOk = e.Element("AOk").Value,
                AMiss = e.Element("AMiss").Value,
                ALate = e.Element("ALate").Value,
                ASoon = e.Element("ASoon").Value,
                ASchool = e.Element("ASchool").Value
            }).ToList().ForEach(e =>
            {
                if(e.A == "0")
                {
                    A = "";
                }
                else
                {
                    A = e.A;
                };
                if (e.AOk == "0")
                {
                    AOk = "";
                }
                else
                {
                    AOk = e.AOk;
                };
                if (e.AMiss == "0")
                {
                    AMiss = "";
                }
                else
                {
                    AMiss = e.AMiss;
                };
                if (e.ALate == "0")
                {
                    ALate = "";
                }
                else
                {
                    ALate = e.ALate;
                };
                if (e.ASoon == "0")
                {
                    ASoon = "";
                }
                else
                {
                    ASoon = e.ASoon;
                };
                if (e.ASchool == "0")
                {
                    ASchool = "";
                }
                else
                {
                    ASchool = e.ASchool;
                };
                //datum
                Label lblp1 = new Label();
                paPanel.Controls.Add(lblp1);
                lblp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                lblp1.ForeColor = System.Drawing.Color.Black;
                lblp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                lblp1.Location = new System.Drawing.Point(0, 0 + h2);
                lblp1.Size = new System.Drawing.Size(97, 28);
                lblp1.TextAlign = ContentAlignment.MiddleCenter;
                lblp1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                lblp1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                datumabs = e.datumabs;
                datumabs = datumabs.Substring(0, 4) + ", " + datumabs.Substring(4, 2) + ", " + datumabs.Substring(6, 2);
                ttrok = datumabs.Substring(0, 4);
                DateTime dayPa;
                dayPa = DateTime.Parse(datumabs, CultureInfo.InvariantCulture); ;
                datumabs = dayPa.ToString("d. MMMM", CultureInfo.CreateSpecificCulture("cs-CZ"));
                lblp1.Text = datumabs;
                //den datum
                denPa = dayPa.ToString("dddd", new CultureInfo("cs-CZ"));
                denPa = denPa.Substring(0, 1).ToUpper() + denPa.Substring(1);
                //tooltip datum
                ToolTip ttp1 = new ToolTip();
                ttp1.InitialDelay = 100;
                ttp1.ReshowDelay = 100;
                ttp1.SetToolTip(lblp1, denPa + ", " + ttrok);
                //A
                Label lblp2 = new Label();
                paPanel.Controls.Add(lblp2);
                lblp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                lblp2.ForeColor = System.Drawing.Color.Black;
                lblp2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                lblp2.Location = new System.Drawing.Point(98, 0 + h2);
                lblp2.Size = new System.Drawing.Size(26, 28);
                lblp2.TextAlign = ContentAlignment.MiddleCenter;
                lblp2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                lblp2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                lblp2.Text = A;
                //AOk
                Label lblp3 = new Label();
                paPanel.Controls.Add(lblp3);
                lblp3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                lblp3.ForeColor = System.Drawing.Color.Black;
                lblp3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                lblp3.Location = new System.Drawing.Point(125, 0 + h2);
                lblp3.Size = new System.Drawing.Size(26, 28);
                lblp3.TextAlign = ContentAlignment.MiddleCenter;
                lblp3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                lblp3.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                lblp3.Text = AOk;
                //AMiss
                Label lblp4 = new Label();
                paPanel.Controls.Add(lblp4);
                lblp4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                lblp4.ForeColor = System.Drawing.Color.Black;
                lblp4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                lblp4.Location = new System.Drawing.Point(152, 0 + h2);
                lblp4.Size = new System.Drawing.Size(26, 28);
                lblp4.TextAlign = ContentAlignment.MiddleCenter;
                lblp4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                lblp4.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                lblp4.Text = AMiss;
                //ALate
                Label lblp5 = new Label();
                paPanel.Controls.Add(lblp5);
                lblp5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                lblp5.ForeColor = System.Drawing.Color.Black;
                lblp5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                lblp5.Location = new System.Drawing.Point(179, 0 + h2);
                lblp5.Size = new System.Drawing.Size(26, 28);
                lblp5.TextAlign = ContentAlignment.MiddleCenter;
                lblp5.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                lblp5.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                lblp5.Text = ALate;
                //ASchool
                Label lblp6 = new Label();
                paPanel.Controls.Add(lblp6);
                lblp6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                lblp6.ForeColor = System.Drawing.Color.Black;
                lblp6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                lblp6.Location = new System.Drawing.Point(206, 0 + h2);
                lblp6.Size = new System.Drawing.Size(26, 28);
                lblp6.TextAlign = ContentAlignment.MiddleCenter;
                lblp6.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                lblp6.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                lblp6.Text = ASchool;
                //ASoon
                Label lblp7 = new Label();
                paPanel.Controls.Add(lblp7);
                lblp7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                lblp7.ForeColor = System.Drawing.Color.Black;
                lblp7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                lblp7.Location = new System.Drawing.Point(233, 0 + h2);
                lblp7.Size = new System.Drawing.Size(26, 28);
                lblp7.TextAlign = ContentAlignment.MiddleCenter;
                lblp7.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                lblp7.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                lblp7.Text = ASoon;
                h2 = h2 + 28;
                //pbline3
                PictureBox pbline3 = new PictureBox();
                paPanel.Controls.Add(pbline3);
                pbline3.BackColor = System.Drawing.Color.Silver;
                pbline3.Location = new System.Drawing.Point(0, pblineh2);
                pbline3.Size = new System.Drawing.Size(277 - off2, 1);
                pbline3.BringToFront();
                pbline3.TabStop = false;
                pbline3.MouseEnter += (sender, l) =>
                {
                    pbline3.BackColor = System.Drawing.Color.Gainsboro;
                };
                pbline3.MouseLeave += (sender, l) =>
                {
                    pbline3.BackColor = System.Drawing.Color.Silver;
                };
                pblineh2 = pblineh2 + 28;
                //gray out na dny
                lblp1.MouseEnter += (sender, l) =>
                {
                    lblp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                };
                lblp1.MouseLeave += (sender, l) =>
                {
                    lblp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                };
                lblp2.MouseEnter += (sender, l) =>
                {
                    lblp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                };
                lblp2.MouseLeave += (sender, l) =>
                {
                    lblp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                };
                lblp3.MouseEnter += (sender, l) =>
                {
                    lblp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                };
                lblp3.MouseLeave += (sender, l) =>
                {
                    lblp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                };
                lblp4.MouseEnter += (sender, l) =>
                {
                    lblp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                };
                lblp4.MouseLeave += (sender, l) =>
                {
                    lblp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                };
                lblp5.MouseEnter += (sender, l) =>
                {
                    lblp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                };
                lblp5.MouseLeave += (sender, l) =>
                {
                    lblp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                };
                lblp6.MouseEnter += (sender, l) =>
                {
                    lblp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                };
                lblp6.MouseLeave += (sender, l) =>
                {
                    lblp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                };
                lblp7.MouseEnter += (sender, l) =>
                {
                    lblp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lblp7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                };
                lblp7.MouseLeave += (sender, l) =>
                {
                    lblp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lblp7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                };
            });
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
        private void panel2_Click(object sender, EventArgs e) //pravej
        {
            pictureBox12.BackColor = System.Drawing.Color.Silver;
            pictureBox11.BackColor = System.Drawing.Color.CornflowerBlue;
            panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            panel2.Cursor = System.Windows.Forms.Cursors.Default;
            label3.Cursor = System.Windows.Forms.Cursors.Default;
            label1.Cursor = System.Windows.Forms.Cursors.Hand;
            panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            saPanel.BringToFront();
        }
        private void panel3_Click(object sender, EventArgs e)
        {
            pictureBox12.BackColor = System.Drawing.Color.CornflowerBlue;
            pictureBox11.BackColor = System.Drawing.Color.Silver;
            panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            label1.Cursor = System.Windows.Forms.Cursors.Default;
            panel3.Cursor = System.Windows.Forms.Cursors.Default;
            panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            label3.Cursor = System.Windows.Forms.Cursors.Hand;
            zvpPanel.BringToFront();
        }
        private void label3_Click(object sender, EventArgs e) //pravej
        {
            pictureBox12.BackColor = System.Drawing.Color.Silver;
            pictureBox11.BackColor = System.Drawing.Color.CornflowerBlue;
            panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            panel2.Cursor = System.Windows.Forms.Cursors.Default;
            label3.Cursor = System.Windows.Forms.Cursors.Default;
            label1.Cursor = System.Windows.Forms.Cursors.Hand;
            panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            saPanel.BringToFront();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            pictureBox12.BackColor = System.Drawing.Color.CornflowerBlue;
            pictureBox11.BackColor = System.Drawing.Color.Silver;
            panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            label1.Cursor = System.Windows.Forms.Cursors.Default;
            panel3.Cursor = System.Windows.Forms.Cursors.Default;
            panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            label3.Cursor = System.Windows.Forms.Cursors.Hand;
            zvpPanel.BringToFront();
        }
        private void pictureBox17_MouseEnter(object sender, EventArgs e)
        {
            pictureBox17.BackColor = System.Drawing.Color.Gainsboro;
        }
        private void pictureBox17_MouseLeave(object sender, EventArgs e)
        {
            pictureBox17.BackColor = System.Drawing.Color.Silver;
        }
        private void pictureBox15_MouseEnter(object sender, EventArgs e)
        {
            pictureBox15.BackColor = System.Drawing.Color.Gainsboro;
        }
        private void pictureBox15_MouseLeave(object sender, EventArgs e)
        {
            pictureBox15.BackColor = System.Drawing.Color.Silver;
        }
        private void pictureBox14_MouseEnter(object sender, EventArgs e)
        {
            pictureBox14.BackColor = System.Drawing.Color.Gainsboro;
        }
        private void pictureBox14_MouseLeave(object sender, EventArgs e)
        {
            pictureBox14.BackColor = System.Drawing.Color.Silver;
        }
        private void pictureBox16_MouseEnter(object sender, EventArgs e)
        {
            pictureBox16.BackColor = System.Drawing.Color.Gainsboro;
        }
        private void pictureBox16_MouseLeave(object sender, EventArgs e)
        {
            pictureBox16.BackColor = System.Drawing.Color.Silver;
        }
        private void pictureBox19_MouseEnter(object sender, EventArgs e)
        {
            pictureBox19.BackColor = System.Drawing.Color.Gainsboro;
        }
        private void pictureBox19_MouseLeave(object sender, EventArgs e)
        {
            pictureBox19.BackColor = System.Drawing.Color.Silver;
        }
        private void pictureBox21_MouseEnter(object sender, EventArgs e)
        {
            pictureBox21.BackColor = System.Drawing.Color.Gainsboro;
        }
        private void pictureBox21_MouseLeave(object sender, EventArgs e)
        {
            pictureBox21.BackColor = System.Drawing.Color.Silver;
        }
        private void pictureBox23_MouseEnter(object sender, EventArgs e)
        {
            pictureBox23.BackColor = System.Drawing.Color.Gainsboro;
        }
        private void pictureBox23_MouseLeave(object sender, EventArgs e)
        {
            pictureBox23.BackColor = System.Drawing.Color.Silver;
        }
        private void pictureBox25_MouseEnter(object sender, EventArgs e)
        {
            pictureBox25.BackColor = System.Drawing.Color.Gainsboro;
        }
        private void pictureBox25_MouseLeave(object sender, EventArgs e)
        {
            pictureBox25.BackColor = System.Drawing.Color.Silver;
        }
        private void pictureBox27_MouseEnter(object sender, EventArgs e)
        {
            pictureBox27.BackColor = System.Drawing.Color.Gainsboro;
        }
        private void pictureBox27_MouseLeave(object sender, EventArgs e)
        {
            pictureBox27.BackColor = System.Drawing.Color.Silver;
        }
        private void pictureBox29_MouseEnter(object sender, EventArgs e)
        {
            pictureBox29.BackColor = System.Drawing.Color.Gainsboro;
        }
        private void pictureBox29_MouseLeave(object sender, EventArgs e)
        {
            pictureBox29.BackColor = System.Drawing.Color.Silver;
        }
    }
}
