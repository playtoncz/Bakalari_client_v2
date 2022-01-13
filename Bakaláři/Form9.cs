using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Bakaláři
{
    public partial class pololeti : Form
    {
        int mov;
        int movX;
        int movY;
        int h;
        int hs;
        int hc;
        int hz;
        int wz;
        int sloupecc;
        int sloupecc2;
        string rokc;
        string rokc2;
        string polo;
        string prumer;
        string zame;
        string neom;
        string vodat;
        string vodatd;
        string vodatm;
        int rokint;
        int rokp;
        int offzp;
        int off;
        int hvo;
        int fw;
        int fh;
        int offvo;
        int offv;
        int ws;
        int pbw;
        int pb2w;
        int pblc;
        int fwf;
        int pblineh;
        string nazev;
        public static string pololetiurl = login.bazeurl + "&pm=pololetni";
        public pololeti(Form parrentform)
        {
            try
            {
                InitializeComponent();
                h = 40;
                hs = 0;
                hc = 0;
                hvo = 0;
                hz = 0;
                wz = 0;
                sloupecc = 0;
                sloupecc2 = 0;
                offzp = 0;
                off = 0;
                offvo = 0;
                offv = 0;
                fw = 0;
                fh = 0;
                ws = 0;
                fwf = 0;
                rokc = "";
                rokc2 = "";
                polo = "";
                prumer = "";
                zame = "";
                neom = "";
                rokint = 0;
                rokp = 0;
                pbw = 0;
                pb2w = 0;
                pblc = 0;
                pblineh = 67;
                pkPanel.Scroll += (sender, e) =>
                {
                    panel4.Location = new Point(0, 0);
                    panel4.BringToFront();
                    pictureBox16.Location = new System.Drawing.Point(0, 40);
                };
                pkPanel.MouseWheel += (sender, e) =>
                {
                    panel4.Location = new Point(0, 0);
                    panel4.BringToFront();
                    pictureBox16.Location = new System.Drawing.Point(0, 40);
                };
                //off ročníky
                ClientSize = new System.Drawing.Size(660, 636);
                fw = this.Width;
                panel4.Size = new System.Drawing.Size(fw, 40);
                pictureBox8.Size = new System.Drawing.Size(296, 1);
                pictureBox16.Size = new System.Drawing.Size(660, 1);
                pictureBox13.Size = new System.Drawing.Size(431, 1);
                pkPanel.Size = new System.Drawing.Size(fw, 575);
                voPanel.Size = new System.Drawing.Size(fw, 575);
                panel1.Size = new System.Drawing.Size(fw, 27);
                panelx.Size = new System.Drawing.Size(fw - 70, 35);
                button4.Location = new System.Drawing.Point(fw - 70, 0);
                button1.Location = new System.Drawing.Point(fw - 35, 0);
                ws = 1;
                //off předměty
                XElement xele = XElement.Load(pololetiurl);
                xele.Descendants("predmet").Select(f => new
                {
                    f.Element("nazev").Value
                }).ToList().ForEach(f =>
                {
                    offzp++;
                });
                if (offzp > 20)
                {
                    off = 17;
                    fw = this.Width;
                    fwf = fw + off;
                    pbw = pictureBox8.Width + off;
                    pb2w = pictureBox13.Width + off;
                    pictureBox13.Size = new System.Drawing.Size(pb2w, 1);
                    ClientSize = new System.Drawing.Size(fwf, 636);
                    pkPanel.Size = new System.Drawing.Size(fwf, 575);
                    voPanel.Size = new System.Drawing.Size(fwf, 575);
                    pictureBox8.Size = new System.Drawing.Size(pbw, 1);
                    panel1.Size = new System.Drawing.Size(fwf, 27);
                    panelx.Size = new System.Drawing.Size(fwf - 70, 35);
                    button4.Location = new System.Drawing.Point(fwf - 70, 0);
                    button1.Location = new System.Drawing.Point(fwf - 35, 0);
                    pkPanel.AutoScroll = true;
                    fw = this.Width;
                };
                //panel VO
                fw = this.Width;
                fh = this.Height;
                PictureBox vopb = new PictureBox();
                voPanel.Controls.Add(vopb);
                vopb.Location = new System.Drawing.Point(0, 0);
                vopb.Size = new System.Drawing.Size(fw, 40);
                vopb.BackColor = System.Drawing.Color.CornflowerBlue;
                //Panel s VOs
                Panel vPanel = new Panel();
                voPanel.Controls.Add(vPanel);
                vPanel.Size = new System.Drawing.Size(fw, fh - 41);
                vPanel.Location = new System.Drawing.Point(0, 41);
                vPanel.BackColor = System.Drawing.Color.White;
                vPanel.BringToFront();
                //pbline VO
                PictureBox vopbl = new PictureBox();
                voPanel.Controls.Add(vopbl);
                vopbl.Location = new System.Drawing.Point(0, 40);
                vopbl.Size = new System.Drawing.Size(fw, 1);
                vopbl.BackColor = System.Drawing.Color.Silver;
                vopbl.MouseEnter += (sender, e) =>
                {
                    vopbl.BackColor = System.Drawing.Color.Gainsboro;
                };
                vopbl.MouseLeave += (sender, e) =>
                {
                    vopbl.BackColor = System.Drawing.Color.Silver;
                };
                PictureBox vopbl1 = new PictureBox();
                voPanel.Controls.Add(vopbl1);
                vopbl1.Location = new System.Drawing.Point(131, 0);
                vopbl1.Size = new System.Drawing.Size(1, fh);
                vopbl1.BackColor = System.Drawing.Color.Silver;
                vopbl1.MouseEnter += (sender, e) =>
                {
                    vopbl1.BackColor = System.Drawing.Color.Gainsboro;
                };
                vopbl1.MouseLeave += (sender, e) =>
                {
                    vopbl1.BackColor = System.Drawing.Color.Silver;
                };
                vopbl1.BringToFront();
                //panel VO - Labely
                Label volbl1 = new Label();
                voPanel.Controls.Add(volbl1);
                volbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                volbl1.ForeColor = System.Drawing.Color.Black;
                volbl1.BackColor = System.Drawing.Color.CornflowerBlue;
                volbl1.Location = new System.Drawing.Point(0, 0);
                volbl1.AutoSize = false;
                volbl1.Size = new System.Drawing.Size(131, 40);
                volbl1.TextAlign = ContentAlignment.MiddleCenter;
                volbl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                volbl1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                volbl1.BringToFront();
                volbl1.Text = "Datum";
                Label volbl2 = new Label();
                voPanel.Controls.Add(volbl2);
                volbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                volbl2.ForeColor = System.Drawing.Color.Black;
                volbl2.BackColor = System.Drawing.Color.CornflowerBlue;
                volbl2.Location = new System.Drawing.Point(132, 0);
                volbl2.AutoSize = false;
                volbl2.Size = new System.Drawing.Size(fw - 132, 40);
                volbl2.TextAlign = ContentAlignment.MiddleCenter;
                volbl2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                volbl2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                volbl2.BringToFront();
                volbl2.Text = "Opatření";
                //vo off
                xele.Descendants("vychovne").Select(l => new
                {
                    nazev = l.Element("rok").Value
                }).ToList().ForEach(l =>
                {
                    offvo++;
                });
                if (offvo > 14)
                {
                    offv = 17;
                    vPanel.AutoScroll = true;
                }
                    //Predmet
                    xele.Descendants("predmet").Select(j => new
                {
                    nazev = j.Element("nazev").Value
                }).ToList().ForEach(j =>
                {
                    Label lbl1 = new Label();
                    pkPanel.Controls.Add(lbl1);
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
                    pkPanel.Controls.Add(pbline);
                    pbline.BackColor = System.Drawing.Color.Silver;
                    pbline.Location = new System.Drawing.Point(0, pblineh);
                    pbline.Size = new System.Drawing.Size(fw - off, 1);
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
                    pblineh = pblineh + 28;
                    lbl1.MouseEnter += (sender, e) =>
                    {
                        lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    };
                    lbl1.MouseLeave += (sender, e) =>
                    {
                        lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    };
                    h = h + 28;
                });
                //ročníky
                xele.Descendants("polo").Select(g => new
                {
                    rslovy = g.Element("rocnikslovy").Value,
                    rok = g.Element("rok").Value
                }).ToList().ForEach(g =>
                {
                    if (rokc2 != g.rok)
                    {
                        rokc2 = g.rok;
                        Label lbl2 = new Label();
                        panel4.Controls.Add(lbl2);
                        lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                        lbl2.ForeColor = System.Drawing.Color.Black;
                        lbl2.BackColor = System.Drawing.Color.CornflowerBlue;
                        lbl2.Location = new System.Drawing.Point(229 + hs, 0);
                        lbl2.Size = new System.Drawing.Size(53, 20);
                        lbl2.TextAlign = ContentAlignment.MiddleCenter;
                        lbl2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                        lbl2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                        lbl2.Text = g.rslovy;
                        hs = hs + 54;
                        //tooltip na rocnik 
                        rokint = Convert.ToInt32(g.rok);
                        rokint++;
                        ToolTip tt2 = new ToolTip();
                        tt2.InitialDelay = 100;
                        tt2.ReshowDelay = 100;
                        tt2.SetToolTip(lbl2, g.rok + "/" + rokint.ToString());
                        //pbline2 a 3 !!!!!!!!!
                        if (ws == 1)
                        {
                            if (pblc <= 6)
                            {
                                PictureBox pbline2 = new PictureBox();
                                this.Controls.Add(pbline2);
                                pbline2.BackColor = System.Drawing.Color.Silver;
                                pbline2.Location = new System.Drawing.Point(228 + hs, 63);
                                pbline2.Size = new System.Drawing.Size(1, 573);
                                pbline2.BringToFront();
                                pblc++;
                                PictureBox pbline3 = new PictureBox();
                                this.Controls.Add(pbline3);
                                pbline3.BackColor = System.Drawing.Color.Silver;
                                pbline3.Location = new System.Drawing.Point(201 + hs, 84);
                                pbline3.Size = new System.Drawing.Size(1, 552);
                                pbline3.BringToFront();
                                pbline2.MouseEnter += (sender, e) =>
                                {
                                    pbline2.BackColor = System.Drawing.Color.Gainsboro;
                                };
                                pbline2.MouseLeave += (sender, e) =>
                                {
                                    pbline2.BackColor = System.Drawing.Color.Silver;
                                };
                                pbline3.MouseEnter += (sender, e) =>
                                {
                                    pbline3.BackColor = System.Drawing.Color.Gainsboro;
                                };
                                pbline3.MouseLeave += (sender, e) =>
                                {
                                    pbline3.BackColor = System.Drawing.Color.Silver;
                                };
                            }
                        }
                        else
                        {
                            if (pblc <= 2)
                            {
                                PictureBox pbline2 = new PictureBox();
                                this.Controls.Add(pbline2);
                                pbline2.BackColor = System.Drawing.Color.Silver;
                                pbline2.Location = new System.Drawing.Point(228 + hs, 63);
                                pbline2.Size = new System.Drawing.Size(1, 573);
                                pbline2.BringToFront();
                                pblc++;
                                PictureBox pbline3 = new PictureBox();
                                this.Controls.Add(pbline3);
                                pbline3.BackColor = System.Drawing.Color.Silver;
                                pbline3.Location = new System.Drawing.Point(201 + hs, 84);
                                pbline3.Size = new System.Drawing.Size(1, 552);
                                pbline3.BringToFront();
                                pbline2.MouseEnter += (sender, e) =>
                                {
                                    pbline2.BackColor = System.Drawing.Color.Gainsboro;
                                };
                                pbline2.MouseLeave += (sender, e) =>
                                {
                                    pbline2.BackColor = System.Drawing.Color.Silver;
                                };
                                pbline3.MouseEnter += (sender, e) =>
                                {
                                    pbline3.BackColor = System.Drawing.Color.Gainsboro;
                                };
                                pbline3.MouseLeave += (sender, e) =>
                                {
                                    pbline3.BackColor = System.Drawing.Color.Silver;
                                };
                            }
                        }

                    }
                });
                //pololeti 1. a 2.
                xele.Descendants("souhrn").Select(g => new
                {
                    pol = g.Element("pololeti").Value,
                    prumer = g.Element("prumer").Value,
                    zam = g.Element("zameskane").Value,
                    neo = g.Element("neomluvene").Value
                }).ToList().ForEach(g =>
                {
                    //pololeti !!! + průměr + zameškané + POKUD JSOU neomluvené
                    polo = g.pol + " pololetí";
                    prumer = "průměr: " + g.prumer;
                    zame = "zameškané: " + g.zam;
                    neom = "neomluvené: " + g.neo;
                    Label lbl3 = new Label();
                    panel4.Controls.Add(lbl3);
                    lbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                    lbl3.ForeColor = System.Drawing.Color.Black;
                    lbl3.BackColor = System.Drawing.Color.CornflowerBlue;
                    lbl3.Location = new System.Drawing.Point(229 + hc, 21);
                    lbl3.Size = new System.Drawing.Size(26, 19);
                    lbl3.TextAlign = ContentAlignment.MiddleCenter;
                    lbl3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                    lbl3.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                    lbl3.Text = g.pol;
                    hc = hc + 27;
                    //tooltip na pololeti
                    ToolTip tt3 = new ToolTip();
                    tt3.InitialDelay = 100;
                    tt3.ReshowDelay = 100;
                    tt3.SetToolTip(lbl3, polo + Environment.NewLine + prumer + Environment.NewLine + zame + Environment.NewLine + neom);
                });
                //znamky
                xele.Descendants("znamky").Elements("znamka").Select(z => new
                {
                    znamka = z.Element("value").Value,
                    sloupec = z.Element("sloupec").Value
                }).ToList().ForEach(z =>
                {
                    sloupecc = Convert.ToInt32(z.sloupec);
                    if (sloupecc > sloupecc2)
                    {
                        sloupecc2 = sloupecc;
                    }
                    else
                    {
                        sloupecc2 = sloupecc;
                        hz = hz + 28;
                        wz = 0;
                    }
                    Label lbl5 = new Label();
                    pkPanel.Controls.Add(lbl5);
                    lbl5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                    lbl5.ForeColor = System.Drawing.Color.Black;
                    lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    lbl5.Location = new System.Drawing.Point(229 + wz, 40 + hz);
                    lbl5.Size = new System.Drawing.Size(26, 27);
                    lbl5.TextAlign = ContentAlignment.MiddleCenter;
                    lbl5.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                    lbl5.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                    lbl5.BringToFront();
                    lbl5.Text = z.znamka;
                    wz = wz + 27;
                    lbl5.MouseEnter += (sender, e) =>
                    {
                        lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    };
                    lbl5.MouseLeave += (sender, e) =>
                    {
                        lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    };
                });
                xele.Descendants("vychovne").Select(k => new
                {
                    vorok = k.Element("rok").Value,
                    vopol = k.Element("pololeti").Value,
                    vonaz = k.Element("nazev").Value,
                    vodat = k.Element("datum").Value,
                    votext = k.Element("text").Value
                }).ToList().ForEach(k =>
                {
                    vodatd = k.vodat.Substring(6, 2);
                    if(vodatd.Substring(0, 1) == "0")
                    {
                        vodatd = vodatd.Substring(1, 1);
                    }
                    vodatm = k.vodat.Substring(4, 2);
                    if (vodatm.Substring(0, 1) == "0")
                    {
                        vodatm = vodatm.Substring(1, 1);
                    }
                    vodat = vodatd + ". " + vodatm + ". " + k.vodat.Substring(0,4);
                    Label volbl3 = new Label();
                    vPanel.Controls.Add(volbl3);
                    volbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                    volbl3.ForeColor = System.Drawing.Color.Black;
                    volbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    volbl3.Location = new System.Drawing.Point(0, 0 + hvo);
                    volbl3.Size = new System.Drawing.Size(131, 36);
                    volbl3.TextAlign = ContentAlignment.MiddleLeft;
                    volbl3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                    volbl3.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                    volbl3.Text = k.vorok + " " + k.vopol + ". pololetí" + Environment.NewLine + vodat;
                    Label volbl4 = new Label();
                    vPanel.Controls.Add(volbl4);
                    volbl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                    volbl4.ForeColor = System.Drawing.Color.Black;
                    volbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    volbl4.Location = new System.Drawing.Point(132, 0 + hvo);
                    volbl4.Size = new System.Drawing.Size(fw - 132 - offv, 36);
                    volbl4.TextAlign = ContentAlignment.MiddleLeft;
                    volbl4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                    volbl4.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                    volbl4.Text = k.vonaz + Environment.NewLine + k.votext;
                    ToolTip tt4 = new ToolTip();
                    tt4.InitialDelay = 100;
                    tt4.ReshowDelay = 100;
                    tt4.SetToolTip(volbl4, k.votext);
                    hvo = hvo + 37;
                    PictureBox vopbl2 = new PictureBox();
                    vPanel.Controls.Add(vopbl2);
                    vopbl2.Location = new System.Drawing.Point(0, hvo - 1);
                    vopbl2.Size = new System.Drawing.Size(fw - offv, 1);
                    vopbl2.BackColor = System.Drawing.Color.Silver;
                    vopbl2.MouseEnter += (sender, e) =>
                    {
                        vopbl2.BackColor = System.Drawing.Color.Gainsboro;
                    };
                    vopbl2.MouseLeave += (sender, e) =>
                    {
                        vopbl2.BackColor = System.Drawing.Color.Silver;
                    };
                    volbl3.MouseEnter += (sender, e) =>
                    {
                        volbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                        volbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    };
                    volbl3.MouseLeave += (sender, e) =>
                    {
                        volbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        volbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                    };
                    volbl4.MouseEnter += (sender, e) =>
                    {
                        volbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                        volbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                    };
                    volbl4.MouseLeave += (sender, e) =>
                    {
                        volbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        volbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
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
            voPanel.BringToFront();
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
            voPanel.SendToBack();
            pictureBox14.BringToFront();
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
            voPanel.BringToFront();
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
            voPanel.SendToBack();
            pictureBox14.BringToFront();
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
    }
}
