using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Globalization;

namespace Bakaláři
{
    public partial class znamky : Form //Simulátor
    {
        int mov;
        int movX;
        int movY;
        double prumerf = 0;
        public static int h = 0;
        public static int i = 0;
        public static int zp = 0;
        public static int hz = 0;
        public static int h2 = 0;
        public static int fp1 = 0;
        public static int fp2 = 0;
        public static int pbh = 0;
        public static int pblineh = 60;
        public static int pblineh2 = 40;
        public static int off = 0;
        public static int offp = 0;
        public static int off2 = 0;
        public static int off2sz = 0;
        public static int offz = 0;
        public static int count = 0;
        public static int dnyodud = 0;
        public static int dnyodudl = 0;
        public static int dnyodudsz = 0;
        public static int dnyodudlsz = 0;
        public static decimal prumerint;
        public static decimal prumerint2;
        public static int znvhint;
        public static double znaszint;
        public static string znamkyurl = login.bazeurl + "&pm=znamky";
        public static string predmet = "";
        public static string predmettt = "";
        public static string prumer = "";
        public static string zkratka = "";
        public static string pred = "";
        public static string znamka = "";
        public static string znamkasz = "";
        public static string znasz = "";
        public static string vahsz = "";
        public static string vaha = "";
        public static string vahasz = "";
        public static string caption = "";
        public static string datum = "";
        public static string datumdt = "";
        public static string cas = "";
        public static string dencas = "";
        public static string den = "";
        public static string datumsz = "";
        public static string datumdtsz = "";
        public static string cassz = "";
        public static string dencassz = "";
        public static string densz = "";
        public static string pozn = "";
        public static string ozn = "";
        public static DateTime now = DateTime.Now;
        menugui menu;
        public znamky(menugui parrentForm)
        {
        try {
            InitializeComponent();
            menu = parrentForm;
            panelPredmety.SendToBack();
            h = 0;
            i = 0;
            fp1 = 0;
            fp2 = 0;
            hz = 0;
            pblineh = 60;
            pblineh2 = 68;
            zp = 0;
            off = 0;
            offp = 0;
            off2 = 0;
            off2sz = 0;
            offz = 0;
            count = 0;
            prumerf = 0;
            dnyodud = 0;
            dnyodudl = 0;
            dnyodudsz = 0;
            dnyodudlsz = 0;
            List<int> znamkyar = new List<int>();
            List<int> vahyar = new List<int>();
            List<int> znvhar = new List<int>();
            List<int> pcvhar = new List<int>();
            List<double> znamkyarsz = new List<double>();
            List<double> vahyarsz = new List<double>();
            List<double> znvharsz = new List<double>();
            List<double> pcvharsz = new List<double>();
            List<PictureBox> PBs = new List<PictureBox>();
            List<PictureBox> PBs2 = new List<PictureBox>();
            List<Label> LBLs = new List<Label>();
            List<Label> LBLs2 = new List<Label>();
            XElement xele = XElement.Load(znamkyurl);
            xele.Descendants("predmet").Select(f => new
            {
                predmet = f.Element("nazev").Value
            }).ToList().ForEach(f =>
            {
                offp++;
            });
            if (offp > 7)
            {
                off = 17;
            }
                xele.Descendants("predmet").Select(p => new
            {
                predmet = p.Element("nazev").Value,
                predmettt = p.Element("nazev").Value,
                prumer = p.Element("prumer").Value,
                zkratka = p.Element("zkratka").Value
            }).ToList().ForEach(p =>
            {
                List<TextBox> TBs = new List<TextBox>();
                List<TextBox> TBs2 = new List<TextBox>();
                if (offp > 7)
                {
                    panelPredmety.AutoScroll = true;
                }
                //Panel
                Panel pnl = new Panel();
                panelPredmety.Controls.Add(pnl);
                pnl.Size = new System.Drawing.Size(301 - off, 60);
                pnl.Location = new System.Drawing.Point(0, 0 + h);
                fp1++;
                fp2++;
                //Predmet
                Label lbl1 = new Label();
                LBLs.Add(lbl1);
                pnl.Controls.Add(lbl1);
                lbl1.AutoSize = true;
                lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                lbl1.ForeColor = System.Drawing.SystemColors.HotTrack;
                lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                lbl1.Location = new System.Drawing.Point(0, 10);
                lbl1.Cursor = System.Windows.Forms.Cursors.Hand;
                lbl1.AutoSize = true;
                lbl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                lbl1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                lbl1.Text = p.predmet;
                predmet = p.predmet;
                if (predmet.Length > 33)
                {
                    predmet = predmet.Substring(0, 33);
                    lbl1.Text = predmet + "...";
                }
                ToolTip tt1 = new ToolTip();
                tt1.InitialDelay = 100;
                tt1.ReshowDelay = 100;
                tt1.SetToolTip(lbl1, p.predmettt);

                //Prumer a počet
                Label lbl2 = new Label();
                LBLs.Add(lbl2);
                pnl.Controls.Add(lbl2);
                lbl2.AutoSize = true;
                lbl2.Location = new System.Drawing.Point(0, 40);
                lbl2.Cursor = System.Windows.Forms.Cursors.Hand;
                lbl2.ForeColor = System.Drawing.SystemColors.GrayText;
                lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                lbl2.AutoSize = true;
                lbl2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                lbl2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);


                //PictureBox over predmet
                PictureBox pb = new PictureBox();
                PBs.Add(pb);
                pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                pnl.Controls.Add(pb);
                pb.Location = new System.Drawing.Point(0, 0);
                pb.Size = new System.Drawing.Size(301 - off, 60);
                pb.Cursor = System.Windows.Forms.Cursors.Hand;
                pb.SendToBack();

                //pbAlert
                PictureBox pbA = new PictureBox();
                PBs.Add(pbA);
                pbA.BackgroundImage = global::Bakaláři.Properties.Resources.iconmonstr_info_thin20x20;
                pbA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                pnl.Controls.Add(pbA);
                pbA.Location = new System.Drawing.Point(279 - off, 20);
                pbA.Size = new System.Drawing.Size(20, 20);
                pbA.Visible = false;
                pbA.Cursor = System.Windows.Forms.Cursors.Hand;
                pbA.BringToFront();
                ToolTip tt8 = new ToolTip();
                tt8.InitialDelay = 100;
                tt8.ReshowDelay = 100;
                tt8.SetToolTip(pbA, "Nová známka");
                pb.MouseEnter += (sender, e) =>
                {
                    if(pb.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247))))))
                    {
                        pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(217)))), ((int)(((byte)(249)))));
                        pbA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(217)))), ((int)(((byte)(249)))));
                        lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(217)))), ((int)(((byte)(249)))));
                        lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(217)))), ((int)(((byte)(249)))));
                    }
                };
                pb.MouseLeave += (sender, e) =>
                {
                    if (pb.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247))))))
                    {
                        pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        pbA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    }
                };
                pbA.MouseEnter += (sender, e) =>
                {
                    if (pbA.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247))))))
                    {
                        pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(217)))), ((int)(((byte)(249)))));
                        pbA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(217)))), ((int)(((byte)(249)))));
                        lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(217)))), ((int)(((byte)(249)))));
                        lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(217)))), ((int)(((byte)(249)))));
                    }
                };
                pbA.MouseLeave += (sender, e) =>
                {
                    if (pbA.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247))))))
                    {
                        pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        pbA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    }
                };
                lbl1.MouseEnter += (sender, e) =>
                {
                    if (lbl1.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247))))))
                    {
                        pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(217)))), ((int)(((byte)(249)))));
                        pbA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(217)))), ((int)(((byte)(249)))));
                        lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(217)))), ((int)(((byte)(249)))));
                        lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(217)))), ((int)(((byte)(249)))));
                    }
                };
                lbl1.MouseLeave += (sender, e) =>
                {
                    if (lbl1.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247))))))
                    {
                        pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        pbA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    }
                };
                lbl2.MouseEnter += (sender, e) =>
                {
                    if (lbl2.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247))))))
                    {
                        pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(217)))), ((int)(((byte)(249)))));
                        pbA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(217)))), ((int)(((byte)(249)))));
                        lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(217)))), ((int)(((byte)(249)))));
                        lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(217)))), ((int)(((byte)(249)))));
                    }

                };
                lbl2.MouseLeave += (sender, e) =>
                {
                    if (lbl2.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247))))))
                    {
                        pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        pbA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    }
                };

                //pbline
                PictureBox pbline = new PictureBox();
                panelPredmety.Controls.Add(pbline);
                pbline.BackColor = System.Drawing.Color.Silver;
                pbline.Location = new System.Drawing.Point(0, pblineh);
                pbline.Size = new System.Drawing.Size(301 - off, 1);
                pbline.BringToFront();
                pbline.TabStop = false;
                pbline.MouseEnter += (sender, e) =>
                {
                    pbline.BackColor = System.Drawing.Color.Gainsboro;
                };
                pbline.MouseLeave += (sender, e) =>
                pbline.BackColor = System.Drawing.Color.Silver;

                //panelzn
                Panel panelzn = new Panel();
                panelznamky.Controls.Add(panelzn);
                panelzn.Location = new System.Drawing.Point(0, 0);
                panelzn.Size = new System.Drawing.Size(546, 409);
                xele.Descendants("znamky").Elements("znamka").Select(g => new
                {
                    pred = g.Element("pred").Value
                }).ToList().ForEach(g =>
                {
                    if (g.pred == p.zkratka)
                    {
                        offz++;
                    }
                });
                if (offz >= 10)
                {
                    off2 = 17;
                    panelzn.AutoScroll = true;
                }
                Panel pnlp = new Panel();
                panelzn.Controls.Add(pnlp);
                pnlp.Size = new System.Drawing.Size(546 - off2, 27);
                pnlp.Location = new System.Drawing.Point(0, 0);
                pnlp.BackColor = System.Drawing.Color.CornflowerBlue;
                Label lblpp = new Label();
                pnlp.Controls.Add(lblpp);
                lblpp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                lblpp.ForeColor = System.Drawing.Color.White;
                lblpp.AutoSize = false;
                lblpp.Size = new System.Drawing.Size(546 - off2, 27);
                lblpp.Text = p.predmet;
                lblpp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                lblpp.Location = new System.Drawing.Point(0, 0);
                PictureBox pbline3 = new PictureBox();
                panelzn.Controls.Add(pbline3);
                pbline3.BackColor = System.Drawing.Color.Silver;
                pbline3.Location = new System.Drawing.Point(0, 27);
                pbline3.Size = new System.Drawing.Size(546 - off2, 1);
                pbline3.BringToFront();
                pbline3.MouseEnter += (sender, e) =>
                {
                    pbline3.BackColor = System.Drawing.Color.Gainsboro;
                };
                pbline3.MouseLeave += (sender, e) =>
                {
                    pbline3.BackColor = System.Drawing.Color.Silver;
                };
                panelzn.Scroll += (sender, e) =>
                {
                    pnlp.Location = new Point(0, 0);
                    pnlp.BringToFront();
                    pbline3.Location = new System.Drawing.Point(0, 27);
                };
                panelzn.MouseWheel += (sender, e) =>
                {
                    pnlp.Location = new Point(0, 0);
                    pnlp.BringToFront();
                    pbline3.Location = new System.Drawing.Point(0, 27);
                };
                if(fp1 == 1)
                {
                    pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    pbA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                }
                //Predmety Simulator
                //Panel
                if (panelPredmety.AutoScroll == true)
                {
                    panelPredmetysz.AutoScroll = true;
                }
                Panel pnlsz = new Panel();
                panelPredmetysz.Controls.Add(pnlsz);
                pnlsz.Size = new System.Drawing.Size(301 - off, 60);
                pnlsz.Location = new System.Drawing.Point(0, 0 + h);
                h = h + 61;
                if (pnl.AutoScroll == true)
                {
                    pnlsz.AutoScroll = true;
                }
                //Predmet
                Label lbl1sz = new Label();
                LBLs2.Add(lbl1sz);
                pnlsz.Controls.Add(lbl1sz);
                lbl1sz.AutoSize = true;
                lbl1sz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                lbl1sz.ForeColor = System.Drawing.SystemColors.HotTrack;
                lbl1sz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                lbl1sz.Location = new System.Drawing.Point(0, 10);
                lbl1sz.Cursor = System.Windows.Forms.Cursors.Hand;
                lbl1sz.AutoSize = true;
                lbl1sz.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                lbl1sz.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                lbl1sz.Text = p.predmet;
                predmet = p.predmet;
                if (off2 == 17)
                {
                    if (predmet.Length > 30)
                    {
                        predmet = predmet.Substring(0, 30);
                        lbl1sz.Text = predmet + "...";
                    }
                }
                if (predmet.Length > 33)
                {
                    predmet = predmet.Substring(0, 33);
                    lbl1sz.Text = predmet + "...";
                }
                ToolTip tt1sz = new ToolTip();
                tt1sz.InitialDelay = 100;
                tt1sz.ReshowDelay = 100;
                tt1sz.SetToolTip(lbl1, p.predmettt);

                //Prumer a počet
                Label lbl2sz = new Label();
                LBLs2.Add(lbl2sz);
                pnlsz.Controls.Add(lbl2sz);
                lbl2sz.AutoSize = true;
                lbl2sz.Location = new System.Drawing.Point(0, 40);
                lbl2sz.Cursor = System.Windows.Forms.Cursors.Hand;
                lbl2sz.ForeColor = System.Drawing.SystemColors.GrayText;
                lbl2sz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                lbl2sz.AutoSize = true;
                lbl2sz.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                lbl2sz.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);

                //PictureBox over predmet
                PictureBox pbsz = new PictureBox();
                PBs2.Add(pbsz);
                pbsz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                pnlsz.Controls.Add(pbsz);
                pbsz.Location = new System.Drawing.Point(0, 0);
                pbsz.Size = new System.Drawing.Size(301 - off, 60);
                pbsz.Cursor = System.Windows.Forms.Cursors.Hand;
                pbsz.SendToBack();

                pbsz.MouseEnter += (sender, e) =>
                {
                    if (pbsz.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247))))))
                    {
                        pbsz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(217)))), ((int)(((byte)(249)))));
                        lbl1sz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(217)))), ((int)(((byte)(249)))));
                        lbl2sz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(217)))), ((int)(((byte)(249)))));
                    }
                };
                pbsz.MouseLeave += (sender, e) =>
                {
                    if (pbsz.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247))))))
                    {
                        pbsz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        lbl1sz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        lbl2sz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    }
                };
                lbl1sz.MouseEnter += (sender, e) =>
                {
                    if (lbl1sz.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247))))))
                    {
                        pbsz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(217)))), ((int)(((byte)(249)))));
                        lbl1sz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(217)))), ((int)(((byte)(249)))));
                        lbl2sz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(217)))), ((int)(((byte)(249)))));
                    }
                };
                lbl1sz.MouseLeave += (sender, e) =>
                {
                    if (lbl1sz.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247))))))
                    {
                        pbsz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        lbl1sz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        lbl2sz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    }
                };
                lbl2sz.MouseEnter += (sender, e) =>
                {
                    if (lbl2sz.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247))))))
                    {
                        pbsz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(217)))), ((int)(((byte)(249)))));
                        lbl1sz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(217)))), ((int)(((byte)(249)))));
                        lbl2sz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(217)))), ((int)(((byte)(249)))));
                    }

                };
                lbl2sz.MouseLeave += (sender, e) =>
                {
                    if (lbl2sz.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247))))))
                    {
                        pbsz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        lbl1sz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        lbl2sz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    }
                };

                //pbline
                PictureBox pblinesz = new PictureBox();
                panelPredmetysz.Controls.Add(pblinesz);
                pblinesz.BackColor = System.Drawing.Color.Silver;
                pblinesz.Location = new System.Drawing.Point(0, pblineh);
                pblinesz.Size = new System.Drawing.Size(301 - off, 1);
                pblinesz.BringToFront();
                pblinesz.TabStop = false;
                pblinesz.MouseEnter += (sender, e) =>
                {
                    pblinesz.BackColor = System.Drawing.Color.Gainsboro;
                };
                pblinesz.MouseLeave += (sender, e) =>
                {
                    pblinesz.BackColor = System.Drawing.Color.Silver;
                };
                pblineh = pblineh + 61;

                //panelzn
                Panel panelznsz = new Panel();
                panelZnamkysz.Controls.Add(panelznsz);
                panelznsz.Location = new System.Drawing.Point(0, 0);
                panelznsz.Size = new System.Drawing.Size(546, 409);
                if (offz >= 5)
                {
                    off2sz = 17;
                    panelznsz.AutoScroll = true;
                }
                else
                {
                    off2sz = 0;
                }
                Panel pnlpsz = new Panel();
                panelznsz.Controls.Add(pnlpsz);
                pnlpsz.Size = new System.Drawing.Size(546 - off2sz, 27);
                pnlpsz.Location = new System.Drawing.Point(0, 0);
                pnlpsz.BackColor = System.Drawing.Color.CornflowerBlue;
                Label lblppsz = new Label();
                pnlpsz.Controls.Add(lblppsz);
                lblppsz.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                lblppsz.ForeColor = System.Drawing.Color.White;
                lblppsz.AutoSize = false;
                lblppsz.Size = new System.Drawing.Size(546 - off2sz, 27);
                lblppsz.Text = p.predmet;
                lblppsz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                lblppsz.Location = new System.Drawing.Point(0, 0);
                PictureBox pbline3sz = new PictureBox();
                panelznsz.Controls.Add(pbline3sz);
                pbline3sz.BackColor = System.Drawing.Color.Silver;
                pbline3sz.Location = new System.Drawing.Point(0, 27);
                pbline3sz.Size = new System.Drawing.Size(546 - off2sz, 1);
                pbline3sz.BringToFront();
                pbline3sz.MouseEnter += (sender, e) =>
                {
                    pbline3sz.BackColor = System.Drawing.Color.Gainsboro;
                };
                pbline3sz.MouseLeave += (sender, e) =>
                {
                    pbline3sz.BackColor = System.Drawing.Color.Silver;
                };
                panelznsz.Scroll += (sender, e) =>
                {
                    pnlpsz.Location = new Point(0, 0);
                    pnlpsz.BringToFront();
                    pbline3sz.Location = new System.Drawing.Point(0, 27);
                };
                panelznsz.MouseWheel += (sender, e) =>
                {
                    pnlpsz.Location = new Point(0, 0);
                    pnlpsz.BringToFront();
                    pbline3sz.Location = new System.Drawing.Point(0, 27);
                };
                if (fp2 == 1)
                {
                    pbsz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lbl1sz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lbl2sz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                }
                //znamky load
                xele.Descendants("znamky").Elements("znamka").Select(z => new
                {
                    znamka = z.Element("znamka").Value,
                    vaha = z.Element("vaha").Value,
                    datum = z.Element("datum").Value,
                    cas = z.Element("udeleno").Value,
                    pozn = z.Element("poznamka").Value,
                    caption = z.Element("caption").Value,
                    ozn = z.Element("ozn").Value,
                    pred = z.Element("pred").Value
                }).ToList().ForEach(z =>
                    {
                        if (z.pred == p.zkratka)
                        {
                            //Panel pro znamku
                            Panel pnlz = new Panel();
                            panelzn.Controls.Add(pnlz);
                            pnlz.Size = new System.Drawing.Size(546 - off2, 40);
                            pnlz.Location = new System.Drawing.Point(0, 28 + hz);
                            pnlz.BackColor = System.Drawing.Color.White;
                            Label lblzn = new Label();
                            pnlz.Controls.Add(lblzn);
                            lblzn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                            lblzn.ForeColor = System.Drawing.SystemColors.ControlText;
                            lblzn.Location = new System.Drawing.Point(3, 0);
                            lblzn.Size = new System.Drawing.Size(40, 40);
                            lblzn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            lblzn.Text = z.znamka;
                            znamka = z.znamka;
                            if (z.znamka == "N")
                            {
                                ToolTip tt5 = new ToolTip();
                                tt5.InitialDelay = 100;
                                tt5.ReshowDelay = 100;
                                tt5.SetToolTip(lblzn, "Neklasifikován");
                            }
                            if (z.znamka == "A")
                            {
                                ToolTip tt6 = new ToolTip();
                                tt6.InitialDelay = 100;
                                tt6.ReshowDelay = 100;
                                tt6.SetToolTip(lblzn, "Absence");
                            }
                            if (z.znamka == "D")
                            {
                                ToolTip tt6 = new ToolTip();
                                tt6.InitialDelay = 100;
                                tt6.ReshowDelay = 100;
                                tt6.SetToolTip(lblzn, "Dopsat");
                            }
                            if (z.znamka == "O")
                            {
                                ToolTip tt6 = new ToolTip();
                                tt6.InitialDelay = 100;
                                tt6.ReshowDelay = 100;
                                tt6.SetToolTip(lblzn, "Omluven");
                            }
                            if (z.znamka == "U")
                            {
                                ToolTip tt6 = new ToolTip();
                                tt6.InitialDelay = 100;
                                tt6.ReshowDelay = 100;
                                tt6.SetToolTip(lblzn, "Uvolněn");
                            }
                            if (z.znamka == "X")
                            {
                                ToolTip tt7 = new ToolTip();
                                tt7.InitialDelay = 100;
                                tt7.ReshowDelay = 100;
                                tt7.SetToolTip(lblzn, "Absence");
                            }
                            if (z.znamka == "?")
                            {
                                ToolTip tt9 = new ToolTip();
                                tt9.InitialDelay = 100;
                                tt9.ReshowDelay = 100;
                                tt9.SetToolTip(lblzn, "Plánovaná klasifikace");
                            }
                            if (znamka == "N")
                            {
                                znamka = "0";
                            }
                            if (znamka == "X")
                            {
                                znamka = "0";
                            }
                            if (znamka == "D")
                            {
                                znamka = "0";
                            }
                            if (znamka == "O")
                            {
                                znamka = "0";
                            }
                            if (znamka == "U")
                            {
                                znamka = "0";
                            }
                            if (znamka == "A")
                            {
                                znamka = "0";
                            }
                            if (znamka == "?")
                            {
                                znamka = "0";
                            }
                            if (znamka.Length == 2)
                            {
                                if(znamka.Substring(1,1) == "-")
                                {
                                    znamka = znamka.Substring(0, 1) + "5";
                                }
                                else
                                {
                                    int znint;
                                    znint = Convert.ToInt32(znamka.Substring(0, 1));
                                    znint = znint - 1;
                                    znamka = znint.ToString() + "5";
                                }
                            }
                            if (znamka.Length == 1)
                            {
                                znamka = znamka.Substring(0, 1) + "0";
                            }
                            int znamkaint;
                            znamkaint = Convert.ToInt32(znamka);
                            Label lblzn2 = new Label();
                            pnlz.Controls.Add(lblzn2);
                            lblzn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                            lblzn2.Location = new System.Drawing.Point(35, 1);
                            lblzn2.AutoSize = true;
                            lblzn2.BringToFront();
                            lblzn2.Text = z.caption;
                            Label lblzn3 = new Label();
                            pnlz.Controls.Add(lblzn3);
                            lblzn3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                            lblzn3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
                            lblzn3.Location = new System.Drawing.Point(35, 20);
                            lblzn3.AutoSize = true;
                            lblzn3.BringToFront();
                            lblzn3.Text = z.pozn;
                            pozn = z.pozn;
                            if (off2 == 17)
                            {
                                if (pozn.Length > 56)
                                {
                                    pozn = pozn.Substring(0, 56);
                                    lblzn3.Text = pozn + "...";
                                }
                            }
                            if (pozn.Length > 60)
                            {
                                pozn = pozn.Substring(0, 60);
                                lblzn3.Text = pozn + "...";
                                ToolTip tt2 = new ToolTip();
                                tt2.InitialDelay = 100;
                                tt2.ReshowDelay = 100;
                                tt2.SetToolTip(lblzn3, z.pozn);
                            }
                            Label lblzn4 = new Label();
                            pnlz.Controls.Add(lblzn4);
                            lblzn4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                            lblzn4.Location = new System.Drawing.Point(468 - off2, 2);
                            lblzn4.AutoSize = true;
                            datum = z.datum;
                            datum = datum.Substring(4, 2) + "." + datum.Substring(2, 2) + ".20" + datum.Substring(0, 2);
                            lblzn4.Text = datum;
                            cas = z.cas.Substring(6, 2) + ":" + z.cas.Substring(8, 2);
                            datumdt = datum.Substring(6, 4) + ", " + datum.Substring(3, 2) + ", " + datum.Substring(0, 2);
                            DateTime daydt;
                            daydt = DateTime.Parse(datumdt, CultureInfo.InvariantCulture);
                            TimeSpan ts = now - daydt;
                            dnyodud = Convert.ToInt32(ts.TotalDays);
                            if (i < 1)
                            {
                                i++;
                                dnyodudl = dnyodud;
                            }
                            den = daydt.ToString("dddd", new CultureInfo("cs-CZ"));
                            den = den.Substring(0, 1).ToUpper() + den.Substring(1);
                            dencas = den + ", " + cas;
                            ToolTip tt4 = new ToolTip();
                            tt4.InitialDelay = 100;
                            tt4.ReshowDelay = 100;
                            tt4.SetToolTip(lblzn4, dencas);
                            Label lblzn5 = new Label();
                            pnlz.Controls.Add(lblzn5);
                            lblzn5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                            lblzn5.Location = new System.Drawing.Point(481 - off2, 20);
                            lblzn5.AutoSize = true;
                            vaha = z.vaha;
                            lblzn5.Text = "Váha: " + z.vaha;
                            int vahaint;
                            vahaint = Convert.ToInt32(vaha);
                            vahaint = vahaint * 10;
                            if (znamka == "00")
                            {
                                vahaint = 0;
                            }
                            znvhar.Add(znamkaint * vahaint);
                            pcvhar.Add(vahaint);
                            vahaint = 0;
                            vaha = "0";
                            znamkaint = 0;
                            znamka = "0";
                            ToolTip tt3 = new ToolTip();
                            tt3.InitialDelay = 100;
                            tt3.ReshowDelay = 100;
                            tt3.SetToolTip(lblzn5, z.ozn);
                            pnlz.MouseEnter += (sender, e) =>
                            {
                                pnlz.BackColor = System.Drawing.SystemColors.ControlLight;
                                lblzn.BackColor = System.Drawing.SystemColors.ControlLight;
                                lblzn2.BackColor = System.Drawing.SystemColors.ControlLight;
                                lblzn3.BackColor = System.Drawing.SystemColors.ControlLight;
                                lblzn4.BackColor = System.Drawing.SystemColors.ControlLight;
                                lblzn5.BackColor = System.Drawing.SystemColors.ControlLight;
                            };
                            pnlz.MouseLeave += (sender, e) =>
                            {
                                pnlz.BackColor = System.Drawing.Color.White;
                                lblzn.BackColor = System.Drawing.Color.White;
                                lblzn2.BackColor = System.Drawing.Color.White;
                                lblzn3.BackColor = System.Drawing.Color.White;
                                lblzn4.BackColor = System.Drawing.Color.White;
                                lblzn5.BackColor = System.Drawing.Color.White;
                            };
                            lblzn.MouseEnter += (sender, e) =>
                            {
                                pnlz.BackColor = System.Drawing.SystemColors.ControlLight;
                                lblzn.BackColor = System.Drawing.SystemColors.ControlLight;
                                lblzn2.BackColor = System.Drawing.SystemColors.ControlLight;
                                lblzn3.BackColor = System.Drawing.SystemColors.ControlLight;
                                lblzn4.BackColor = System.Drawing.SystemColors.ControlLight;
                                lblzn5.BackColor = System.Drawing.SystemColors.ControlLight;
                            };
                            lblzn.MouseLeave += (sender, e) =>
                            {
                                pnlz.BackColor = System.Drawing.Color.White;
                                lblzn.BackColor = System.Drawing.Color.White;
                                lblzn2.BackColor = System.Drawing.Color.White;
                                lblzn3.BackColor = System.Drawing.Color.White;
                                lblzn4.BackColor = System.Drawing.Color.White;
                                lblzn5.BackColor = System.Drawing.Color.White;
                            };
                            lblzn2.MouseEnter += (sender, e) =>
                            {
                                pnlz.BackColor = System.Drawing.SystemColors.ControlLight;
                                lblzn.BackColor = System.Drawing.SystemColors.ControlLight;
                                lblzn2.BackColor = System.Drawing.SystemColors.ControlLight;
                                lblzn3.BackColor = System.Drawing.SystemColors.ControlLight;
                                lblzn4.BackColor = System.Drawing.SystemColors.ControlLight;
                                lblzn5.BackColor = System.Drawing.SystemColors.ControlLight;
                            };
                            lblzn2.MouseLeave += (sender, e) =>
                            {
                                pnlz.BackColor = System.Drawing.Color.White;
                                lblzn.BackColor = System.Drawing.Color.White;
                                lblzn2.BackColor = System.Drawing.Color.White;
                                lblzn3.BackColor = System.Drawing.Color.White;
                                lblzn4.BackColor = System.Drawing.Color.White;
                                lblzn5.BackColor = System.Drawing.Color.White;
                            };
                            lblzn3.MouseEnter += (sender, e) =>
                            {
                                pnlz.BackColor = System.Drawing.SystemColors.ControlLight;
                                lblzn.BackColor = System.Drawing.SystemColors.ControlLight;
                                lblzn2.BackColor = System.Drawing.SystemColors.ControlLight;
                                lblzn3.BackColor = System.Drawing.SystemColors.ControlLight;
                                lblzn4.BackColor = System.Drawing.SystemColors.ControlLight;
                                lblzn5.BackColor = System.Drawing.SystemColors.ControlLight;
                            };
                            lblzn3.MouseLeave += (sender, e) =>
                            {
                                pnlz.BackColor = System.Drawing.Color.White;
                                lblzn.BackColor = System.Drawing.Color.White;
                                lblzn2.BackColor = System.Drawing.Color.White;
                                lblzn3.BackColor = System.Drawing.Color.White;
                                lblzn4.BackColor = System.Drawing.Color.White;
                                lblzn5.BackColor = System.Drawing.Color.White;
                            };
                            lblzn4.MouseEnter += (sender, e) =>
                            {
                                pnlz.BackColor = System.Drawing.SystemColors.ControlLight;
                                lblzn.BackColor = System.Drawing.SystemColors.ControlLight;
                                lblzn2.BackColor = System.Drawing.SystemColors.ControlLight;
                                lblzn3.BackColor = System.Drawing.SystemColors.ControlLight;
                                lblzn4.BackColor = System.Drawing.SystemColors.ControlLight;
                                lblzn5.BackColor = System.Drawing.SystemColors.ControlLight;
                            };
                            lblzn4.MouseLeave += (sender, e) =>
                            {
                                pnlz.BackColor = System.Drawing.Color.White;
                                lblzn.BackColor = System.Drawing.Color.White;
                                lblzn2.BackColor = System.Drawing.Color.White;
                                lblzn3.BackColor = System.Drawing.Color.White;
                                lblzn4.BackColor = System.Drawing.Color.White;
                                lblzn5.BackColor = System.Drawing.Color.White;
                            };
                            lblzn5.MouseEnter += (sender, e) =>
                            {
                                pnlz.BackColor = System.Drawing.SystemColors.ControlLight;
                                lblzn.BackColor = System.Drawing.SystemColors.ControlLight;
                                lblzn2.BackColor = System.Drawing.SystemColors.ControlLight;
                                lblzn3.BackColor = System.Drawing.SystemColors.ControlLight;
                                lblzn4.BackColor = System.Drawing.SystemColors.ControlLight;
                                lblzn5.BackColor = System.Drawing.SystemColors.ControlLight;
                            };
                            lblzn5.MouseLeave += (sender, e) =>
                            {
                                pnlz.BackColor = System.Drawing.Color.White;
                                lblzn.BackColor = System.Drawing.Color.White;
                                lblzn2.BackColor = System.Drawing.Color.White;
                                lblzn3.BackColor = System.Drawing.Color.White;
                                lblzn4.BackColor = System.Drawing.Color.White;
                                lblzn5.BackColor = System.Drawing.Color.White;
                            };
                            //pbline2
                            PictureBox pbline2 = new PictureBox();
                            panelzn.Controls.Add(pbline2);
                            pbline2.BackColor = System.Drawing.Color.Silver;
                            pbline2.Location = new System.Drawing.Point(0, pblineh2);
                            pbline2.Size = new System.Drawing.Size(546 - off2, 1);
                            pbline2.BringToFront();
                            pbline2.TabStop = false;
                            pbline2.MouseEnter += (sender, e) =>
                            {
                                pbline2.BackColor = System.Drawing.Color.Gainsboro;
                            };
                            pbline2.MouseLeave += (sender, e) =>
                            {
                                pbline2.BackColor = System.Drawing.Color.Silver;
                            };

                            //Znamky Simulator
                            if (z.pred == p.zkratka)
                            {
                                zp++;
                                //Panel pro znamku
                                Panel pnlzsz = new Panel();
                                panelznsz.Controls.Add(pnlzsz);
                                pnlzsz.Size = new System.Drawing.Size(546 - off2sz, 40);
                                pnlzsz.Location = new System.Drawing.Point(0, 28 + hz);
                                pnlzsz.BackColor = System.Drawing.Color.White;
                                hz = hz + 41;
                                znamkasz = z.znamka;
                                if (znamkasz == "N")
                                {
                                    znamkasz = "0";
                                }
                                if (znamkasz == "D")
                                {
                                    znamkasz = "0";
                                }
                                if (znamkasz == "U")
                                {
                                    znamkasz = "0";
                                }
                                if (znamkasz == "O")
                                {
                                    znamkasz = "0";
                                }
                                if (znamkasz == "X")
                                {
                                    znamkasz = "0";
                                }
                                if (znamkasz == "A")
                                {
                                    znamkasz = "0";
                                }
                                if (znamkasz == "?")
                                {
                                    znamkasz = "0";
                                }
                                Label lblznsz = new Label();
                                pnlzsz.Controls.Add(lblznsz);
                                lblznsz.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                lblznsz.ForeColor = System.Drawing.SystemColors.ControlText;
                                lblznsz.Location = new System.Drawing.Point(3, 0);
                                lblznsz.Size = new System.Drawing.Size(40, 40);
                                lblznsz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                TextBox tb1 = new TextBox();
                                pnlzsz.Controls.Add(tb1);
                                TBs.Add(tb1);
                                tb1.BackColor = System.Drawing.Color.White;
                                tb1.Location = new System.Drawing.Point(1, 3);
                                tb1.MaxLength = 2;
                                tb1.Size = new System.Drawing.Size(34, 35);
                                tb1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                                tb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                tb1.Text = z.znamka;
                                tb1.BringToFront();
                                Label lblzn2sz = new Label();
                                pnlzsz.Controls.Add(lblzn2sz);
                                lblzn2sz.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                lblzn2sz.Location = new System.Drawing.Point(35, 1);
                                lblzn2sz.AutoSize = true;
                                lblzn2sz.BringToFront();
                                lblzn2sz.Text = z.caption;
                                Label lblzn3sz = new Label();
                                pnlzsz.Controls.Add(lblzn3sz);
                                lblzn3sz.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                lblzn3sz.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
                                lblzn3sz.Location = new System.Drawing.Point(35, 20);
                                lblzn3sz.AutoSize = true;
                                lblzn3sz.BringToFront();
                                lblzn3sz.Text = z.pozn;
                                pozn = z.pozn;
                                if (off2sz == 17)
                                {
                                    if (pozn.Length > 56)
                                    {
                                        pozn = pozn.Substring(0, 56);
                                        lblzn3sz.Text = pozn + "...";
                                    }
                                }
                                if (pozn.Length > 60)
                                {
                                    pozn = pozn.Substring(0, 60);
                                    lblzn3sz.Text = pozn + "...";
                                    ToolTip tt2sz = new ToolTip();
                                    tt2sz.InitialDelay = 100;
                                    tt2sz.ReshowDelay = 100;
                                    tt2sz.SetToolTip(lblzn3sz, z.pozn);
                                }
                                Label lblzn4sz = new Label();
                                pnlzsz.Controls.Add(lblzn4sz);
                                lblzn4sz.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                lblzn4sz.Location = new System.Drawing.Point(468 - off2sz, 2);
                                lblzn4sz.AutoSize = true;
                                datum = z.datum;
                                datum = datum.Substring(4, 2) + "." + datum.Substring(2, 2) + ".20" + datum.Substring(0, 2);
                                lblzn4sz.Text = datum;
                                cassz = z.cas.Substring(6, 2) + ":" + z.cas.Substring(8, 2);
                                datumdtsz = datum.Substring(6, 4) + ", " + datum.Substring(3, 2) + ", " + datum.Substring(0, 2);
                                DateTime daydtsz;
                                daydtsz = DateTime.Parse(datumdtsz, CultureInfo.InvariantCulture);
                                TimeSpan tssz = now - daydtsz;
                                dnyodudsz = Convert.ToInt32(tssz.TotalDays);
                                if (i < 1)
                                {
                                    i++;
                                    dnyodudlsz = dnyodudsz;
                                }
                                densz = daydtsz.ToString("dddd", new CultureInfo("cs-CZ"));
                                densz = densz.Substring(0, 1).ToUpper() + densz.Substring(1);
                                dencassz = densz + ", " + cassz;
                                ToolTip tt4sz = new ToolTip();
                                tt4sz.InitialDelay = 100;
                                tt4sz.ReshowDelay = 100;
                                tt4sz.SetToolTip(lblzn4sz, dencassz);
                                Label lblzn5sz = new Label();
                                pnlzsz.Controls.Add(lblzn5sz);
                                lblzn5sz.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                lblzn5sz.Location = new System.Drawing.Point(481 - off2sz, 20);
                                lblzn5sz.AutoSize = true;
                                vahasz = z.vaha;
                                lblzn5sz.Text = "Váha:";
                                TextBox tb2 = new TextBox();
                                pnlzsz.Controls.Add(tb2);
                                TBs2.Add(tb2);
                                tb2.BackColor = System.Drawing.Color.White;
                                tb2.Location = new System.Drawing.Point(521 - off2sz, 19);
                                tb2.MaxLength = 2;
                                tb2.Size = new System.Drawing.Size(22, 20);
                                tb2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                                tb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                tb2.Text = z.vaha;
                                tb2.BringToFront();
                                if (tb1.Text == "0" || tb1.Text == "N" || tb1.Text == "A" || tb1.Text == "?" || tb1.Text == "X" || tb1.Text == "D" || tb1.Text == "O" || tb1.Text == "U")
                                {
                                    tb2.Text = "0";
                                }
                                pnlzsz.MouseEnter += (sender, e) =>
                                {
                                    pnlzsz.BackColor = System.Drawing.SystemColors.ControlLight;
                                    lblznsz.BackColor = System.Drawing.SystemColors.ControlLight;
                                    lblzn2sz.BackColor = System.Drawing.SystemColors.ControlLight;
                                    lblzn3sz.BackColor = System.Drawing.SystemColors.ControlLight;
                                    lblzn4sz.BackColor = System.Drawing.SystemColors.ControlLight;
                                    lblzn5sz.BackColor = System.Drawing.SystemColors.ControlLight;
                                };
                                pnlzsz.MouseLeave += (sender, e) =>
                                {
                                    pnlzsz.BackColor = System.Drawing.Color.White;
                                    lblznsz.BackColor = System.Drawing.Color.White;
                                    lblzn2sz.BackColor = System.Drawing.Color.White;
                                    lblzn3sz.BackColor = System.Drawing.Color.White;
                                    lblzn4sz.BackColor = System.Drawing.Color.White;
                                    lblzn5sz.BackColor = System.Drawing.Color.White;
                                };
                                lblznsz.MouseEnter += (sender, e) =>
                                {
                                    pnlzsz.BackColor = System.Drawing.SystemColors.ControlLight;
                                    lblznsz.BackColor = System.Drawing.SystemColors.ControlLight;
                                    lblzn2sz.BackColor = System.Drawing.SystemColors.ControlLight;
                                    lblzn3sz.BackColor = System.Drawing.SystemColors.ControlLight;
                                    lblzn4sz.BackColor = System.Drawing.SystemColors.ControlLight;
                                    lblzn5sz.BackColor = System.Drawing.SystemColors.ControlLight;
                                };
                                lblznsz.MouseLeave += (sender, e) =>
                                {
                                    pnlzsz.BackColor = System.Drawing.Color.White;
                                    lblznsz.BackColor = System.Drawing.Color.White;
                                    lblzn2sz.BackColor = System.Drawing.Color.White;
                                    lblzn3sz.BackColor = System.Drawing.Color.White;
                                    lblzn4sz.BackColor = System.Drawing.Color.White;
                                    lblzn5sz.BackColor = System.Drawing.Color.White;
                                };
                                lblzn2sz.MouseEnter += (sender, e) =>
                                {
                                    pnlzsz.BackColor = System.Drawing.SystemColors.ControlLight;
                                    lblznsz.BackColor = System.Drawing.SystemColors.ControlLight;
                                    lblzn2sz.BackColor = System.Drawing.SystemColors.ControlLight;
                                    lblzn3sz.BackColor = System.Drawing.SystemColors.ControlLight;
                                    lblzn4sz.BackColor = System.Drawing.SystemColors.ControlLight;
                                    lblzn5sz.BackColor = System.Drawing.SystemColors.ControlLight;
                                };
                                lblzn2sz.MouseLeave += (sender, e) =>
                                {
                                    pnlzsz.BackColor = System.Drawing.Color.White;
                                    lblznsz.BackColor = System.Drawing.Color.White;
                                    lblzn2sz.BackColor = System.Drawing.Color.White;
                                    lblzn3sz.BackColor = System.Drawing.Color.White;
                                    lblzn4sz.BackColor = System.Drawing.Color.White;
                                    lblzn5sz.BackColor = System.Drawing.Color.White;
                                };
                                lblzn3sz.MouseEnter += (sender, e) =>
                                {
                                    pnlzsz.BackColor = System.Drawing.SystemColors.ControlLight;
                                    lblznsz.BackColor = System.Drawing.SystemColors.ControlLight;
                                    lblzn2sz.BackColor = System.Drawing.SystemColors.ControlLight;
                                    lblzn3sz.BackColor = System.Drawing.SystemColors.ControlLight;
                                    lblzn4sz.BackColor = System.Drawing.SystemColors.ControlLight;
                                    lblzn5sz.BackColor = System.Drawing.SystemColors.ControlLight;
                                };
                                lblzn3sz.MouseLeave += (sender, e) =>
                                {
                                    pnlzsz.BackColor = System.Drawing.Color.White;
                                    lblznsz.BackColor = System.Drawing.Color.White;
                                    lblzn2sz.BackColor = System.Drawing.Color.White;
                                    lblzn3sz.BackColor = System.Drawing.Color.White;
                                    lblzn4sz.BackColor = System.Drawing.Color.White;
                                    lblzn5sz.BackColor = System.Drawing.Color.White;
                                };
                                lblzn4sz.MouseEnter += (sender, e) =>
                                {
                                    pnlzsz.BackColor = System.Drawing.SystemColors.ControlLight;
                                    lblznsz.BackColor = System.Drawing.SystemColors.ControlLight;
                                    lblzn2sz.BackColor = System.Drawing.SystemColors.ControlLight;
                                    lblzn3sz.BackColor = System.Drawing.SystemColors.ControlLight;
                                    lblzn4sz.BackColor = System.Drawing.SystemColors.ControlLight;
                                    lblzn5sz.BackColor = System.Drawing.SystemColors.ControlLight;
                                };
                                lblzn5sz.MouseLeave += (sender, e) =>
                                {
                                    pnlzsz.BackColor = System.Drawing.Color.White;
                                    lblznsz.BackColor = System.Drawing.Color.White;
                                    lblzn2sz.BackColor = System.Drawing.Color.White;
                                    lblzn3sz.BackColor = System.Drawing.Color.White;
                                    lblzn4sz.BackColor = System.Drawing.Color.White;
                                    lblzn5sz.BackColor = System.Drawing.Color.White;
                                };
                                lblzn5sz.MouseEnter += (sender, e) =>
                                {
                                    pnlzsz.BackColor = System.Drawing.SystemColors.ControlLight;
                                    lblznsz.BackColor = System.Drawing.SystemColors.ControlLight;
                                    lblzn2sz.BackColor = System.Drawing.SystemColors.ControlLight;
                                    lblzn3sz.BackColor = System.Drawing.SystemColors.ControlLight;
                                    lblzn4sz.BackColor = System.Drawing.SystemColors.ControlLight;
                                    lblzn5sz.BackColor = System.Drawing.SystemColors.ControlLight;
                                };
                                lblzn5sz.MouseLeave += (sender, e) =>
                                {
                                    pnlzsz.BackColor = System.Drawing.Color.White;
                                    lblznsz.BackColor = System.Drawing.Color.White;
                                    lblzn2sz.BackColor = System.Drawing.Color.White;
                                    lblzn3sz.BackColor = System.Drawing.Color.White;
                                    lblzn4sz.BackColor = System.Drawing.Color.White;
                                    lblzn5sz.BackColor = System.Drawing.Color.White;
                                };
                                //pbline2
                                PictureBox pbline2sz = new PictureBox();
                                panelznsz.Controls.Add(pbline2sz);
                                pbline2sz.BackColor = System.Drawing.Color.Silver;
                                pbline2sz.Location = new System.Drawing.Point(0, pblineh2);
                                pbline2sz.Size = new System.Drawing.Size(546 - off2sz, 1);
                                pbline2sz.BringToFront();
                                pbline2sz.TabStop = false;
                                pbline2sz.MouseEnter += (sender, e) =>
                                {
                                    pbline2sz.BackColor = System.Drawing.Color.Gainsboro;
                                };
                                pbline2sz.MouseLeave += (sender, e) =>
                                {
                                    pbline2sz.BackColor = System.Drawing.Color.Silver;
                                };
                                pblineh2 = pblineh2 + 41;
                                
                                if (offz == zp)
                                {
                                    for (int i = 0; i < 5; i++)
                                    {
                                        Panel pnlzsza = new Panel();
                                        panelznsz.Controls.Add(pnlzsza);
                                        pnlzsza.Size = new System.Drawing.Size(546 - off2sz, 40);
                                        pnlzsza.Location = new System.Drawing.Point(0, 28 + hz);
                                        pnlzsza.BackColor = System.Drawing.Color.White;
                                        hz = hz + 41;
                                        TextBox tb1a = new TextBox();
                                        pnlzsza.Controls.Add(tb1a);
                                        TBs.Add(tb1a);
                                        tb1a.BackColor = System.Drawing.Color.White;
                                        tb1a.Location = new System.Drawing.Point(1, 3);
                                        tb1a.MaxLength = 2;
                                        tb1a.Size = new System.Drawing.Size(34, 35);
                                        tb1a.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                                        tb1a.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                        tb1a.BringToFront();
                                        Label lblzn5sza = new Label();
                                        pnlzsza.Controls.Add(lblzn5sza);
                                        lblzn5sza.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                        lblzn5sza.Location = new System.Drawing.Point(481 - off2sz, 20);
                                        lblzn5sza.AutoSize = true;
                                        lblzn5sza.Text = "Váha:";
                                        TextBox tb2a = new TextBox();
                                        pnlzsza.Controls.Add(tb2a);
                                        TBs2.Add(tb2a);
                                        tb2a.BackColor = System.Drawing.Color.White;
                                        tb2a.Location = new System.Drawing.Point(521 - off2sz, 19);
                                        tb2a.MaxLength = 2;
                                        tb2a.Size = new System.Drawing.Size(22, 20);
                                        tb2a.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                                        tb2a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                        tb2a.BringToFront();
                                        //tb2a.Text = "1";
                                        //pbline2
                                        PictureBox pbline2sza = new PictureBox();
                                        panelznsz.Controls.Add(pbline2sza);
                                        pbline2sza.BackColor = System.Drawing.Color.Silver;
                                        pbline2sza.Location = new System.Drawing.Point(0, pblineh2);
                                        pbline2sza.Size = new System.Drawing.Size(546 - off2sz, 1);
                                        pbline2sza.BringToFront();
                                        pbline2sza.TabStop = false;
                                        pbline2sza.MouseEnter += (sender, e) =>
                                        {
                                            pbline2sza.BackColor = System.Drawing.Color.Gainsboro;
                                        };
                                        pbline2sza.MouseLeave += (sender, e) =>
                                        {
                                            pbline2sza.BackColor = System.Drawing.Color.Silver;
                                        };
                                        pblineh2 = pblineh2 + 41;
                                        pnlzsza.MouseEnter += (sender, e) =>
                                        {
                                            pnlzsza.BackColor = System.Drawing.SystemColors.ControlLight;
                                            lblzn5sza.BackColor = System.Drawing.SystemColors.ControlLight;
                                        };
                                        pnlzsza.MouseLeave += (sender, e) =>
                                        {
                                            pnlzsza.BackColor = System.Drawing.Color.White;
                                            lblzn5sza.BackColor = System.Drawing.Color.White;
                                        };
                                        lblzn5sza.MouseEnter += (sender, e) =>
                                        {
                                            pnlzsza.BackColor = System.Drawing.SystemColors.ControlLight;
                                            lblzn5sza.BackColor = System.Drawing.SystemColors.ControlLight;
                                        };
                                        lblzn5sza.MouseLeave += (sender, e) =>
                                        {
                                            pnlzsza.BackColor = System.Drawing.Color.White;
                                            lblzn5sza.BackColor = System.Drawing.Color.White;
                                        };
                                        tb1a.TextChanged += (sender, e) =>
                                        {
                                            if (tb1a.Text != "" && tb2a.Text != "")
                                            {
                                                if (tb1a.Text == "1-" || tb1a.Text == "1" || tb1a.Text == "1+" || tb1a.Text == "2-" || tb1a.Text == "2" || tb1a.Text == "-2" || tb1a.Text == "2+" || tb1a.Text == "3-" || tb1a.Text == "3" || tb1a.Text == "3+" || tb1a.Text == "4-" || tb1a.Text == "4" || tb1a.Text == "4+" || tb1a.Text == "5-" || tb1a.Text == "5" || tb1a.Text == "5+" || tb1a.Text == "N" || tb1a.Text == "A" || tb1a.Text == "?" || tb1a.Text == "X" || tb1a.Text == "0" || tb1a.Text == "D" || tb1a.Text == "O" || tb1a.Text == "U")
                                                {
                                                    if (tb2a.Text == "1" || tb2a.Text == "2" || tb2a.Text == "3" || tb2a.Text == "4" || tb2a.Text == "5" || tb2a.Text == "6" || tb2a.Text == "7" || tb2a.Text == "8" || tb2a.Text == "9" || tb2a.Text == "10" || tb2a.Text == "0")
                                                    {
                                                        if (tb1a.Text == "0" || tb1a.Text == "N" || tb1a.Text == "A" || tb1a.Text == "?" || tb1a.Text == "X" || tb1a.Text == "D" || tb1a.Text == "O" || tb1a.Text == "U")
                                                        {
                                                            tb2a.Text = "0";
                                                        }
                                                        foreach (TextBox tb in TBs2)
                                                        {
                                                            if (tb.Text != "")
                                                            {
                                                                vahsz = tb.Text;
                                                                pcvharsz.Add(Convert.ToDouble(vahsz));
                                                                count++;
                                                            }
                                                        }
                                                        foreach (TextBox tb in TBs)
                                                        {
                                                            if (tb.Text != "")
                                                            {
                                                                if (tb.Text == "N" || tb.Text == "A" || tb.Text == "?" || tb.Text == "X" || tb.Text == "D" || tb.Text == "O" || tb.Text == "U")
                                                                {
                                                                    znasz = "0";
                                                                }
                                                                else
                                                                {
                                                                    znasz = tb.Text;
                                                                }

                                                                if (tb.Text.Length == 2)
                                                                {
                                                                    if (tb.Text.Substring(1, 1) == "-")
                                                                    {
                                                                        znasz = tb.Text.Substring(0, 1);
                                                                        znaszint = Convert.ToDouble(znasz) + 0.5;
                                                                        znasz = znaszint.ToString();
                                                                    }
                                                                    if (tb.Text.Substring(1, 1) == "+")
                                                                    {
                                                                        znasz = tb.Text.Substring(0, 1);
                                                                        znaszint = Convert.ToDouble(znasz) - 0.5;
                                                                        znasz = znaszint.ToString();
                                                                    }
                                                                }
                                                                znvharsz.Add(Convert.ToDouble(znasz));
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        tb2a.Text = "1";
                                                    }
                                                    for (int c = 0; c < count; c++)
                                                    {
                                                        znamkyarsz.Add(pcvharsz[c] * znvharsz[c]);
                                                    }
                                                    prumerf = znamkyarsz.Sum() / pcvharsz.Sum();
                                                    lbl2sz.Text = "Průměr: " + prumerf.ToString("#.##") + " │ Počet známek: " + count.ToString();
                                                }
                                                else
                                                {
                                                    tb1a.Text = "1";
                                                }
                                            }
                                            count = 0;
                                            znamkyarsz.Clear();
                                            pcvharsz.Clear();
                                            znvharsz.Clear();
                                        };
                                        tb2a.TextChanged += (sender, e) =>
                                        {
                                            if (tb1a.Text != "" && tb2a.Text != "")
                                            {
                                                if (tb2a.Text == "1" || tb2a.Text == "2" || tb2a.Text == "3" || tb2a.Text == "4" || tb2a.Text == "5" || tb2a.Text == "6" || tb2a.Text == "7" || tb2a.Text == "8" || tb2a.Text == "9" || tb2a.Text == "10" || tb2a.Text == "0")
                                                {
                                                    if (tb1a.Text == "1-" || tb1a.Text == "1" || tb1a.Text == "1+" || tb1a.Text == "2-" || tb1a.Text == "2" || tb1a.Text == "-2" || tb1a.Text == "2+" || tb1a.Text == "3-" || tb1a.Text == "3" || tb1a.Text == "3+" || tb1a.Text == "4-" || tb1a.Text == "4" || tb1a.Text == "4+" || tb1a.Text == "5-" || tb1a.Text == "5" || tb1a.Text == "5+" || tb1a.Text == "N" || tb1a.Text == "A" || tb1a.Text == "?" || tb1a.Text == "X" || tb1a.Text == "0" || tb1a.Text == "D" || tb1a.Text == "O" || tb1a.Text == "U")
                                                    {
                                                        if (tb1a.Text == "0" || tb1a.Text == "N" || tb1a.Text == "A" || tb1a.Text == "?" || tb1a.Text == "X" || tb1a.Text == "D" || tb1a.Text == "O" || tb1a.Text == "U")
                                                        {
                                                            tb2a.Text = "0";
                                                        }
                                                        foreach (TextBox tb in TBs2)
                                                        {
                                                            if (tb.Text != "")
                                                            {
                                                                vahsz = tb.Text;
                                                                pcvharsz.Add(Convert.ToDouble(vahsz));
                                                                count++;
                                                            }

                                                        }
                                                        foreach (TextBox tb in TBs)
                                                        {
                                                            if (tb.Text != "")
                                                            {
                                                                if (tb.Text == "N" || tb.Text == "A" || tb.Text == "?" || tb.Text == "X" || tb.Text == "D" || tb.Text == "O" || tb.Text == "U")
                                                                {
                                                                    znasz = "0";
                                                                }
                                                                else
                                                                {
                                                                    znasz = tb.Text;
                                                                }

                                                                if (tb.Text.Length == 2)
                                                                {
                                                                    if (tb.Text.Substring(1, 1) == "-")
                                                                    {
                                                                        znasz = tb.Text.Substring(0, 1);
                                                                        znaszint = Convert.ToDouble(znasz) + 0.5;
                                                                        znasz = znaszint.ToString();
                                                                    }
                                                                    if (tb.Text.Substring(1, 1) == "+")
                                                                    {
                                                                        znasz = tb.Text.Substring(0, 1);
                                                                        znaszint = Convert.ToDouble(znasz) - 0.5;
                                                                        znasz = znaszint.ToString();
                                                                    }
                                                                }
                                                                znvharsz.Add(Convert.ToDouble(znasz));
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        tb1a.Text = "1";
                                                    }
                                                    for (int c = 0; c < count; c++)
                                                    {
                                                        znamkyarsz.Add(pcvharsz[c] * znvharsz[c]);
                                                    }
                                                    prumerf = znamkyarsz.Sum() / pcvharsz.Sum();
                                                    lbl2sz.Text = "Průměr: " + prumerf.ToString("#.##") + " │ Počet známek: " + count.ToString();
                                                }
                                                else
                                                {
                                                    tb2a.Text = "1";
                                                }
                                            }
                                            count = 0;
                                            znamkyarsz.Clear();
                                            pcvharsz.Clear();
                                            znvharsz.Clear();
                                        };
                                    }
                                }
                                //Simulace známek
                                tb1.TextChanged += (sender, e) =>
                                {
                                    if (tb1.Text != "" && tb2.Text != "")
                                    {
                                        if (tb1.Text == "1-" || tb1.Text == "1" || tb1.Text == "1+" || tb1.Text == "2-" || tb1.Text == "2" || tb1.Text == "-2" || tb1.Text == "2+" || tb1.Text == "3-" || tb1.Text == "3" || tb1.Text == "3+" || tb1.Text == "4-" || tb1.Text == "4" || tb1.Text == "4+" || tb1.Text == "5-" || tb1.Text == "5" || tb1.Text == "5+" || tb1.Text == "N" || tb1.Text == "A" || tb1.Text == "?" || tb1.Text == "X" || tb1.Text == "0" || tb1.Text == "D" || tb1.Text == "O" || tb1.Text == "U")
                                        {
                                            if (tb2.Text == "1" || tb2.Text == "2" || tb2.Text == "3" || tb2.Text == "4" || tb2.Text == "5" || tb2.Text == "6" || tb2.Text == "7" || tb2.Text == "8" || tb2.Text == "9" || tb2.Text == "10" || tb2.Text == "0")
                                            {
                                                if (tb1.Text == "0" || tb1.Text == "N" || tb1.Text == "A" || tb1.Text == "?" || tb1.Text == "X" || tb1.Text == "D" || tb1.Text == "O" || tb1.Text == "U")
                                                {
                                                    tb2.Text = "0";
                                                }
                                                foreach (TextBox tb in TBs2)
                                                {
                                                    if (tb.Text != "")
                                                    {
                                                        vahsz = tb.Text;
                                                        pcvharsz.Add(Convert.ToDouble(vahsz));
                                                        count++;
                                                    }
                                                }
                                                foreach (TextBox tb in TBs)
                                                {
                                                    if (tb.Text != "")
                                                    {
                                                        if (tb.Text == "N" || tb.Text == "A" || tb.Text == "?" || tb.Text == "X" || tb.Text == "D" || tb.Text == "O" || tb.Text == "U")
                                                        {
                                                            znasz = "0";
                                                        }
                                                        else
                                                        {
                                                            znasz = tb.Text;
                                                        }

                                                        if (tb.Text.Length == 2)
                                                        {
                                                            if (tb.Text.Substring(1, 1) == "-")
                                                            {
                                                                znasz = tb.Text.Substring(0, 1);
                                                                znaszint = Convert.ToDouble(znasz) + 0.5;
                                                                znasz = znaszint.ToString();
                                                            }
                                                            if (tb.Text.Substring(1, 1) == "+")
                                                            {
                                                                znasz = tb.Text.Substring(0, 1);
                                                                znaszint = Convert.ToDouble(znasz) - 0.5;
                                                                znasz = znaszint.ToString();
                                                            }
                                                        }
                                                        znvharsz.Add(Convert.ToDouble(znasz));
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                tb2.Text = "1";
                                            }   
                                            for (int i = 0; i < count; i++)
                                            {
                                                znamkyarsz.Add(pcvharsz[i] * znvharsz[i]);
                                            }
                                            prumerf = znamkyarsz.Sum() / pcvharsz.Sum();
                                            lbl2sz.Text = "Průměr: " + prumerf.ToString("#.##") + " │ Počet známek: " + count.ToString();
                                        }
                                        else
                                        {
                                            tb1.Text = "1";
                                        }
                                    }
                                    count = 0;
                                    znamkyarsz.Clear();
                                    pcvharsz.Clear();
                                    znvharsz.Clear();
                                };
                                tb2.TextChanged += (sender, e) =>
                                {
                                    if (tb1.Text != "" && tb2.Text != "")
                                    {
                                        if (tb2.Text == "1" || tb2.Text == "2" || tb2.Text == "3" || tb2.Text == "4" || tb2.Text == "5" || tb2.Text == "6" || tb2.Text == "7" || tb2.Text == "8" || tb2.Text == "9" || tb2.Text == "10" || tb2.Text == "0")
                                        {
                                            if (tb1.Text == "1-" || tb1.Text == "1" || tb1.Text == "1+" || tb1.Text == "2-" || tb1.Text == "2" || tb1.Text == "-2" || tb1.Text == "2+" || tb1.Text == "3-" || tb1.Text == "3" || tb1.Text == "3+" || tb1.Text == "4-" || tb1.Text == "4" || tb1.Text == "4+" || tb1.Text == "5-" || tb1.Text == "5" || tb1.Text == "5+" || tb1.Text == "N" || tb1.Text == "A" || tb1.Text == "?" || tb1.Text == "X" || tb1.Text == "0" || tb1.Text == "D" || tb1.Text == "O" || tb1.Text == "U")
                                            {
                                                if (tb1.Text == "0" || tb1.Text == "N" || tb1.Text == "A" || tb1.Text == "?" || tb1.Text == "X" || tb1.Text == "D" || tb1.Text == "O" || tb1.Text == "U")
                                                {
                                                    tb2.Text = "0";
                                                }
                                                foreach (TextBox tb in TBs2)
                                                {
                                                    if (tb.Text != "")
                                                    {
                                                        vahsz = tb.Text;
                                                        pcvharsz.Add(Convert.ToDouble(vahsz));
                                                        count++;
                                                    }
                                                }
                                                foreach (TextBox tb in TBs)
                                                {
                                                    if (tb.Text != "")
                                                    {
                                                        if (tb.Text == "N" || tb.Text == "A" || tb.Text == "?" || tb.Text == "X" || tb.Text == "D" || tb.Text == "O" || tb.Text == "U")
                                                        {
                                                            znasz = "0";
                                                        }
                                                        else
                                                        {
                                                            znasz = tb.Text;
                                                        }

                                                        if (tb.Text.Length == 2)
                                                        {
                                                            if (tb.Text.Substring(1, 1) == "-")
                                                            {
                                                                znasz = tb.Text.Substring(0, 1);
                                                                znaszint = Convert.ToDouble(znasz) + 0.5;
                                                                znasz = znaszint.ToString();
                                                            }
                                                            if (tb.Text.Substring(1, 1) == "+")
                                                            {
                                                                znasz = tb.Text.Substring(0, 1);
                                                                znaszint = Convert.ToDouble(znasz) - 0.5;
                                                                znasz = znaszint.ToString();
                                                            }
                                                        }
                                                        znvharsz.Add(Convert.ToDouble(znasz));
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                tb1.Text = "1";
                                            }
                                            for (int i = 0; i < count; i++)
                                            {
                                                znamkyarsz.Add(pcvharsz[i] * znvharsz[i]);
                                            }
                                            prumerf = znamkyarsz.Sum() / pcvharsz.Sum();
                                            lbl2sz.Text = "Průměr: " + prumerf.ToString("#.##") + " │ Počet známek: " + count.ToString();
                                        }
                                        else
                                        {
                                            tb2.Text = "1";
                                        }
                                    }
                                    count = 0;
                                    znamkyarsz.Clear();
                                    pcvharsz.Clear();
                                    znvharsz.Clear();
                                };
                                
                            }
                        }
                });
                pb.MouseClick += (sender, e) =>
                {
                    foreach (PictureBox pbar in PBs)
                    {
                        pbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    }
                    foreach (Label lblar in LBLs)
                    {
                        lblar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    }
                    pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    pbA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    panelzn.BringToFront();
                };
                pbA.MouseClick += (sender, e) =>
                {
                    foreach (PictureBox pbar in PBs)
                    {
                        pbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    }
                    foreach (Label lblar in LBLs)
                    {
                        lblar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    }
                    pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    pbA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    panelzn.BringToFront();
                };
                lbl1.MouseClick += (sender, e) =>
                {
                    foreach (PictureBox pbar in PBs)
                    {
                        pbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    }
                    foreach (Label lblar in LBLs)
                    {
                        lblar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    }
                    pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    pbA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    panelzn.BringToFront();
                };
                lbl2.MouseClick += (sender, e) =>
                {
                    foreach (PictureBox pbar in PBs)
                    {
                        pbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    }
                    foreach (Label lblar in LBLs)
                    {
                        lblar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    }
                    pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    pbA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    panelzn.BringToFront();
                };
                pbsz.MouseClick += (sender, e) =>
                {
                    foreach (PictureBox pbar in PBs2)
                    {
                        pbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    }
                    foreach (Label lblar in LBLs2)
                    {
                        lblar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    }
                    pbsz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lbl1sz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lbl2sz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    panelznsz.BringToFront();
                };
                lbl1sz.MouseClick += (sender, e) =>
                {
                    foreach (PictureBox pbar in PBs2)
                    {
                        pbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    }
                    foreach (Label lblar in LBLs2)
                    {
                        lblar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    }
                    pbsz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lbl1sz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lbl2sz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    panelznsz.BringToFront();
                };
                lbl2sz.MouseClick += (sender, e) =>
                {
                    foreach (PictureBox pbar in PBs2)
                    {
                        pbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    }
                    foreach (Label lblar in LBLs2)
                    {
                        lblar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    }
                    pbsz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lbl1sz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    lbl2sz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    panelznsz.BringToFront();
                };
                if (dnyodudl <= Bakaláři.Properties.Settings.Default.znamkyA)
                {
                    pbA.Visible = true;
                }
                hz = 0;
                i = 0;
                off2 = 0;
                off2sz = 0;
                offz = 0;
                pblineh2 = 68;
                dnyodudl = 0;
                dnyodud = 0;
                dnyodudlsz = 0;
                dnyodudsz = 0;
                prumer = p.prumer;
                if (prumer == "")
                {
                    for (int z = 0; z < zp; z++)
                    {
                        prumerint2 = znvhar.Sum();
                        prumerint2 = prumerint2 / 100;
                        prumerint = pcvhar.Sum();
                        prumerint = prumerint / 10;
                        if(prumerint != 0)
                        {
                            prumerint = prumerint2 / prumerint;
                        }
                    }
                    prumer = prumerint.ToString("0.00");
                    if (prumer.EndsWith("00"))
                    {
                        prumer = prumerint.ToString();
                    }
                    if (prumer.EndsWith("0"))
                    {
                        prumer = prumerint.ToString("0.0");
                    }
                }
                lbl2.Text = "Průměr: " + prumer + " │ Počet známek: " + zp.ToString();
                lbl2sz.Text = "Průměr: " + prumer + " │ Počet známek: " + zp.ToString();
                zp = 0;
                prumerint = 0;
                vahyar.Clear();
                znamkyar.Clear();
                pcvhar.Clear();
                znvhar.Clear();
                vahyarsz.Clear();
                znamkyarsz.Clear();
                pcvharsz.Clear();
                znvharsz.Clear();
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
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = System.Drawing.Color.Gainsboro;
        }
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = System.Drawing.Color.Silver;
        }
        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            pictureBox7.BackColor = System.Drawing.Color.Gainsboro;
        }
        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.BackColor = System.Drawing.Color.Silver;
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
            Szpanel.BringToFront();
            pictureBox2.BringToFront();
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
            Znpanel.BringToFront();
            pictureBox2.BringToFront();
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
            Szpanel.BringToFront();
            pictureBox2.BringToFront();
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
            Znpanel.BringToFront();
            pictureBox2.BringToFront();
        }
    }
}
