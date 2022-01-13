using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Bakaláři
{
    public partial class rozvrh : Form
    {
        int mov;
        int movX;
        int movY;
        string Pri;
        int w;
        int h;
        int i;
        int i2;
        int hod;
        int hp;
        int wp;
        string ukol;
        string cap;
        string teman;
        string datumfin;
        string CalP;
        public static string rozvrhurl = login.bazeurl + "&pm=rozvrh";
        public rozvrh(Form parrentform)
        {
            rozvrhurl = login.bazeurl + "&pm=rozvrh";
            w = 0;
            h = 0;
            i = 0;
            i2 = 0;
            cap = "";
            teman = "";
            ukol = "";
            hp = 0;
            wp = 0;
            datumfin = "";
            InitializeComponent();
            XElement xele = XElement.Load(rozvrhurl);
            xele.Descendants("rozvrh").Select(f => new
            {
                zkratkacyklu = f.Element("zkratkacyklu").Value
            }).ToList().ForEach(f =>
            {
                label4.Text = f.zkratkacyklu;
            });
            xele.Descendants("rozvrh").Elements("hodiny").Elements("hod").Select(g => new
            {
                begin = g.Element("begintime").Value,
                end = g.Element("endtime").Value,
                caption = g.Element("caption").Value
            }).ToList().ForEach(g =>
            {
                hod++;
                Label hcap = new Label();
                panel2.Controls.Add(hcap);
                hcap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                hcap.ForeColor = System.Drawing.SystemColors.MenuHighlight;
                hcap.BackColor = System.Drawing.Color.White;
                hcap.Location = new System.Drawing.Point(0 + w, 0);
                hcap.Size = new System.Drawing.Size(70, 25);
                hcap.TextAlign = ContentAlignment.MiddleCenter;
                hcap.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                hcap.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                hcap.Text = g.caption;
                Label htime = new Label();
                panel2.Controls.Add(htime);
                htime.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                htime.ForeColor = System.Drawing.Color.DarkGray;
                htime.BackColor = System.Drawing.Color.White;
                htime.Location = new System.Drawing.Point(0 + w, 25);
                htime.Size = new System.Drawing.Size(70, 23);
                htime.TextAlign = ContentAlignment.MiddleCenter;
                htime.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                htime.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                htime.Text = g.begin + " - " + g.end;
                w = w + 71;
            });
            RozvrhLoad();
        }
        public void RozvrhLoad()
        {
            try
            {
                h = 0;
                i2 = 0;
                i = 0;
                wp = 0;
                hp = 0;
                cap = "";
                teman = "";
                ukol = "";
                XElement xelex = XElement.Load(rozvrhurl);
                xelex.Descendants("rozvrh").Select(l => new
                {
                    zkratkacyklu = l.Element("zkratkacyklu").Value
                }).ToList().ForEach(l =>
                {
                    label4.Text = l.zkratkacyklu;
                });
                xelex.Descendants("den").Select(s => new
                {
                    datum = s.Element("datum").Value
                }).ToList().ForEach(s =>
                {
                    if(s.datum != "")
                    {
                        datumfin = s.datum.Substring(6, 2) + ". " + s.datum.Substring(4, 2) + ".";
                        if (datumfin.Substring(0, 1) == "0")
                        {
                            datumfin = datumfin.Substring(1, 6); //D. MM.
                            if (datumfin.Substring(3, 1) == "0")
                            {
                                datumfin = datumfin.Substring(0, 3) + datumfin.Substring(4, 2); //D. M.
                            }
                        }
                        else
                        {
                            if (datumfin.Substring(4, 1) == "0")
                            {
                                datumfin = datumfin.Substring(0, 4) + datumfin.Substring(5, 2); //DD. M.
                            }
                        }
                        datumfin = datumfin.Replace(" ", "");
                        Label datum = new Label();
                        panel1.Controls.Add(datum);
                        datum.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                        datum.ForeColor = System.Drawing.Color.DarkGray;
                        datum.BackColor = System.Drawing.Color.White;
                        datum.Location = new System.Drawing.Point(0, 41 + h);
                        datum.Size = new System.Drawing.Size(36, 23);
                        datum.TextAlign = ContentAlignment.MiddleCenter;
                        datum.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                        datum.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                        datum.Text = datumfin;
                    }
                    h = h + 64;
                });
                xelex.Descendants("rozvrh").Elements("dny").Elements("den").Elements("hodiny").Elements("hod").Select(o => new
                {
                    typ = (string)o.Element("typ") ?? String.Empty,
                    zkrpr = (string)o.Element("zkrpr") ?? String.Empty,
                    pr = (string)o.Element("pr") ?? String.Empty,
                    zkruc = (string)o.Element("zkruc") ?? String.Empty,
                    uc = (string)o.Element("uc") ?? String.Empty,
                    misto = (string)o.Element("zkrmist") ?? String.Empty,
                    ukol = (string)o.Element("ukolodevzdat") ?? String.Empty,
                    zkratka = (string)o.Element("zkratka") ?? String.Empty,
                    nazev = (string)o.Element("nazev") ?? String.Empty,
                    caption = (string)o.Element("caption") ?? String.Empty,
                    tema = (string)o.Element("tema") ?? String.Empty,
                    notice = (string)o.Element("notice") ?? String.Empty,
                    chng = (string)o.Element("chng") ?? String.Empty
                }).ToList().ForEach(o =>
                {
                    teman = "";
                    i++;
                    if(i <= hod)
                    {
                        if (o.typ != "X")
                        {
                            if (o.typ == "A")
                            {
                                Label absence = new Label();
                                panel3.Controls.Add(absence);
                                absence.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                absence.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(148)))), ((int)(((byte)(44)))));
                                absence.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(234)))), ((int)(((byte)(212)))));
                                absence.Location = new System.Drawing.Point(0 + wp, 0 + hp);
                                absence.Size = new System.Drawing.Size(70, 63);
                                absence.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                absence.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                absence.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                absence.Text = o.zkratka;
                                ToolTip tt1 = new ToolTip();
                                tt1.InitialDelay = 100;
                                tt1.ReshowDelay = 100;
                                tt1.SetToolTip(absence, o.nazev);
                                wp = wp + 71;
                                cap = o.caption;
                                absence.MouseEnter += (sender, e) =>
                                {
                                    absence.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(239)))), ((int)(((byte)(137)))));
                                };
                                absence.MouseLeave += (sender, e) =>
                                {
                                    absence.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(234)))), ((int)(((byte)(212)))));
                                };
                            }
                            else
                            {
                                if(o.tema != "")
                                {
                                    if(o.notice != "")
                                    {
                                        teman = o.tema + Environment.NewLine + o.notice;
                                    }
                                    else
                                    {
                                        teman = o.tema;
                                    }
                                }
                                else
                                {
                                    if (o.notice != "")
                                    {
                                        teman = o.notice;
                                    }
                                }
                                if (cap != o.caption)
                                {
                                    if (o.ukol != "")
                                    {
                                        PictureBox DUicon = new PictureBox();
                                        panel3.Controls.Add(DUicon);
                                        DUicon.BackgroundImage = global::Bakaláři.Properties.Resources.duFINAL;
                                        DUicon.Location = new System.Drawing.Point(2 + wp, 2 + hp);
                                        DUicon.Size = new System.Drawing.Size(16, 16);
                                        DUicon.BringToFront();
                                        ukol = o.ukol.Replace("<br />", System.Environment.NewLine);
                                        ToolTip tt5 = new ToolTip();
                                        tt5.InitialDelay = 100;
                                        tt5.ReshowDelay = 100;
                                        tt5.SetToolTip(DUicon, ukol);
                                    }
                                    Label trida = new Label();
                                    panel3.Controls.Add(trida);
                                    trida.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                    trida.ForeColor = System.Drawing.SystemColors.GrayText;
                                    trida.BackColor = System.Drawing.Color.White;
                                    trida.Location = new System.Drawing.Point(0 + wp, 0 + hp);
                                    trida.Size = new System.Drawing.Size(70, 17);
                                    trida.TextAlign = System.Drawing.ContentAlignment.TopRight;
                                    trida.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                    trida.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                    trida.Text = o.misto;
                                    ToolTip tt2 = new ToolTip();
                                    tt2.InitialDelay = 100;
                                    tt2.ReshowDelay = 100;
                                    tt2.SetToolTip(trida, "Třída");
                                    Label predmet = new Label();
                                    panel3.Controls.Add(predmet);
                                    predmet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                    predmet.ForeColor = System.Drawing.SystemColors.MenuHighlight;
                                    predmet.BackColor = System.Drawing.Color.White;
                                    predmet.Location = new System.Drawing.Point(0 + wp, 17 + hp);
                                    predmet.Size = new System.Drawing.Size(70, 23);
                                    predmet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                    predmet.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                    predmet.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                    predmet.Text = o.zkrpr;
                                    ToolTip tt3 = new ToolTip();
                                    tt3.InitialDelay = 100;
                                    tt3.ReshowDelay = 100;
                                    tt3.SetToolTip(predmet, o.pr + Environment.NewLine + teman + Environment.NewLine + o.chng);
                                    Label ucitel = new Label();
                                    panel3.Controls.Add(ucitel);
                                    ucitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                    ucitel.ForeColor = System.Drawing.SystemColors.GrayText;
                                    ucitel.BackColor = System.Drawing.Color.White;
                                    ucitel.Location = new System.Drawing.Point(0 + wp, 40 + hp);
                                    ucitel.Size = new System.Drawing.Size(70, 23);
                                    ucitel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                    ucitel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                    ucitel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                    ucitel.Text = o.zkruc;
                                    ToolTip tt4 = new ToolTip();
                                    tt4.InitialDelay = 100;
                                    tt4.ReshowDelay = 100;
                                    tt4.SetToolTip(ucitel, o.uc);
                                    wp = wp + 71;
                                    cap = o.caption;
                                    trida.MouseEnter += (sender, e) =>
                                    {
                                        trida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                        predmet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                        ucitel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                    };
                                    trida.MouseLeave += (sender, e) =>
                                    {
                                        trida.BackColor = System.Drawing.Color.White;
                                        predmet.BackColor = System.Drawing.Color.White;
                                        ucitel.BackColor = System.Drawing.Color.White;
                                    };
                                    predmet.MouseEnter += (sender, e) =>
                                    {
                                        trida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                        predmet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                        ucitel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                    };
                                    predmet.MouseLeave += (sender, e) =>
                                    {
                                        trida.BackColor = System.Drawing.Color.White;
                                        predmet.BackColor = System.Drawing.Color.White;
                                        ucitel.BackColor = System.Drawing.Color.White;
                                    };
                                    ucitel.MouseEnter += (sender, e) =>
                                    {
                                        trida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                        predmet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                        ucitel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                    };
                                    ucitel.MouseLeave += (sender, e) =>
                                    {
                                        trida.BackColor = System.Drawing.Color.White;
                                        predmet.BackColor = System.Drawing.Color.White;
                                        ucitel.BackColor = System.Drawing.Color.White;
                                    };
                                    if (o.chng != "")
                                    {
                                        trida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                                        trida.ForeColor = System.Drawing.Color.Brown;
                                        predmet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                                        predmet.ForeColor = System.Drawing.Color.Brown;
                                        ucitel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                                        ucitel.ForeColor = System.Drawing.Color.Brown;
                                        trida.MouseEnter += (sender, e) =>
                                        {
                                            trida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
                                            predmet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
                                            ucitel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
                                        };
                                        trida.MouseLeave += (sender, e) =>
                                        {
                                            trida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                                            predmet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                                            ucitel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                                        };
                                        predmet.MouseEnter += (sender, e) =>
                                        {
                                            trida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
                                            predmet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
                                            ucitel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
                                        };
                                        predmet.MouseLeave += (sender, e) =>
                                        {
                                            trida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                                            predmet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                                            ucitel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                                        };
                                        ucitel.MouseEnter += (sender, e) =>
                                        {
                                            trida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
                                            predmet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
                                            ucitel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
                                        };
                                        ucitel.MouseLeave += (sender, e) =>
                                        {
                                            trida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                                            predmet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                                            ucitel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                                        };
                                    }
                                }
                                else
                                {
                                    i--;
                                }
                            }
                        }
                        else
                        {
                            if (o.zkratka != "")
                            {
                                i2++;
                                if (i2 == 1)
                                {
                                    Label xzkr = new Label();
                                    panel3.Controls.Add(xzkr);
                                    xzkr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                    xzkr.ForeColor = System.Drawing.Color.Blue;
                                    xzkr.BackColor = System.Drawing.Color.LightBlue;
                                    xzkr.Location = new System.Drawing.Point(0 + wp, 0 + hp);
                                    xzkr.Size = new System.Drawing.Size(780, 63);
                                    xzkr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                    xzkr.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                    xzkr.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                    xzkr.Text = o.zkratka;
                                    ToolTip tt6 = new ToolTip();
                                    tt6.InitialDelay = 100;
                                    tt6.ReshowDelay = 100;
                                    tt6.SetToolTip(xzkr, o.zkratka);
                                    xzkr.MouseEnter += (sender, e) =>
                                    {
                                        xzkr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(183)))), ((int)(((byte)(255)))));
                                    };
                                    xzkr.MouseLeave += (sender, e) =>
                                    {
                                        xzkr.BackColor = System.Drawing.Color.LightBlue;
                                    };
                                }
                            }
                            if (o.chng != "")
                            {
                                Label vyjm = new Label();
                                panel3.Controls.Add(vyjm);
                                vyjm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                vyjm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(148)))), ((int)(((byte)(44)))));
                                vyjm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                                vyjm.Location = new System.Drawing.Point(0 + wp, 0 + hp);
                                vyjm.Size = new System.Drawing.Size(70, 63);
                                vyjm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                vyjm.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                vyjm.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                ToolTip tt7 = new ToolTip();
                                tt7.InitialDelay = 100;
                                tt7.ReshowDelay = 100;
                                tt7.SetToolTip(vyjm, o.chng);
                                cap = o.caption;
                                vyjm.MouseEnter += (sender, e) =>
                                {
                                    vyjm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
                                };
                                vyjm.MouseLeave += (sender, e) =>
                                {
                                    vyjm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                                };
                            }
                            wp = wp + 71;
                            cap = o.caption;
                        }
                    }
                    else
                    {
                        i = 1;
                        i2 = 0;
                        wp = 0;
                        hp = hp + 64;
                        teman = "";
                        if (o.typ != "X")
                        {
                            if (o.typ == "A")
                            {
                                Label absence = new Label();
                                panel3.Controls.Add(absence);
                                absence.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                absence.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(148)))), ((int)(((byte)(44)))));
                                absence.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(234)))), ((int)(((byte)(212)))));
                                absence.Location = new System.Drawing.Point(0 + wp, 0 + hp);
                                absence.Size = new System.Drawing.Size(70, 63);
                                absence.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                absence.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                absence.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                absence.Text = o.zkratka;
                                ToolTip tt1 = new ToolTip();
                                tt1.InitialDelay = 100;
                                tt1.ReshowDelay = 100;
                                tt1.SetToolTip(absence, o.nazev);
                                wp = wp + 71;
                                cap = o.caption;
                                absence.MouseEnter += (sender, e) =>
                                {
                                    absence.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(239)))), ((int)(((byte)(137)))));
                                };
                                absence.MouseLeave += (sender, e) =>
                                {
                                    absence.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(234)))), ((int)(((byte)(212)))));
                                };
                            }
                            else
                            {
                                if (o.tema != "")
                                {
                                    if (o.notice != "")
                                    {
                                        teman = o.tema + Environment.NewLine + o.notice;
                                    }
                                    else
                                    {
                                        teman = o.tema;
                                    }
                                }
                                else
                                {
                                    if (o.notice != "")
                                    {
                                        teman = o.notice;
                                    }
                                }
                                if (cap != o.caption)
                                {
                                    if (o.ukol != "")
                                    {
                                        PictureBox DUicon = new PictureBox();
                                        panel3.Controls.Add(DUicon);
                                        DUicon.BackgroundImage = global::Bakaláři.Properties.Resources.duFINAL;
                                        DUicon.Location = new System.Drawing.Point(2 + wp, 2 + hp);
                                        DUicon.Size = new System.Drawing.Size(16, 16);
                                        DUicon.BringToFront();
                                        ukol = o.ukol.Replace("<br />", System.Environment.NewLine);
                                        ToolTip tt5 = new ToolTip();
                                        tt5.InitialDelay = 100;
                                        tt5.ReshowDelay = 100;
                                        tt5.SetToolTip(DUicon, ukol);
                                    }
                                    Label trida = new Label();
                                    panel3.Controls.Add(trida);
                                    trida.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                    trida.ForeColor = System.Drawing.SystemColors.GrayText;
                                    trida.BackColor = System.Drawing.Color.White;
                                    trida.Location = new System.Drawing.Point(0 + wp, 0 + hp);
                                    trida.Size = new System.Drawing.Size(70, 17);
                                    trida.TextAlign = System.Drawing.ContentAlignment.TopRight;
                                    trida.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                    trida.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                    trida.Text = o.misto;
                                    ToolTip tt2 = new ToolTip();
                                    tt2.InitialDelay = 100;
                                    tt2.ReshowDelay = 100;
                                    tt2.SetToolTip(trida, "Třída");
                                    Label predmet = new Label();
                                    panel3.Controls.Add(predmet);
                                    predmet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                    predmet.ForeColor = System.Drawing.SystemColors.MenuHighlight;
                                    predmet.BackColor = System.Drawing.Color.White;
                                    predmet.Location = new System.Drawing.Point(0 + wp, 17 + hp);
                                    predmet.Size = new System.Drawing.Size(70, 23);
                                    predmet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                    predmet.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                    predmet.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                    predmet.Text = o.zkrpr;
                                    ToolTip tt3 = new ToolTip();
                                    tt3.InitialDelay = 100;
                                    tt3.ReshowDelay = 100;
                                    tt3.SetToolTip(predmet, o.pr + Environment.NewLine + teman + Environment.NewLine + o.chng);
                                    Label ucitel = new Label();
                                    panel3.Controls.Add(ucitel);
                                    ucitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                    ucitel.ForeColor = System.Drawing.SystemColors.GrayText;
                                    ucitel.BackColor = System.Drawing.Color.White;
                                    ucitel.Location = new System.Drawing.Point(0 + wp, 40 + hp);
                                    ucitel.Size = new System.Drawing.Size(70, 23);
                                    ucitel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                    ucitel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                    ucitel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                    ucitel.Text = o.zkruc;
                                    ToolTip tt4 = new ToolTip();
                                    tt4.InitialDelay = 100;
                                    tt4.ReshowDelay = 100;
                                    tt4.SetToolTip(ucitel, o.uc);
                                    wp = wp + 71;
                                    cap = o.caption;
                                    trida.MouseEnter += (sender, e) =>
                                    {
                                        trida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                        predmet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                        ucitel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                    };
                                    trida.MouseLeave += (sender, e) =>
                                    {
                                        trida.BackColor = System.Drawing.Color.White;
                                        predmet.BackColor = System.Drawing.Color.White;
                                        ucitel.BackColor = System.Drawing.Color.White;
                                    };
                                    predmet.MouseEnter += (sender, e) =>
                                    {
                                        trida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                        predmet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                        ucitel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                    };
                                    predmet.MouseLeave += (sender, e) =>
                                    {
                                        trida.BackColor = System.Drawing.Color.White;
                                        predmet.BackColor = System.Drawing.Color.White;
                                        ucitel.BackColor = System.Drawing.Color.White;
                                    };
                                    ucitel.MouseEnter += (sender, e) =>
                                    {
                                        trida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                        predmet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                        ucitel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                    };
                                    ucitel.MouseLeave += (sender, e) =>
                                    {
                                        trida.BackColor = System.Drawing.Color.White;
                                        predmet.BackColor = System.Drawing.Color.White;
                                        ucitel.BackColor = System.Drawing.Color.White;
                                    };
                                    if (o.chng != "")
                                    {
                                        trida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                                        trida.ForeColor = System.Drawing.Color.Brown;
                                        predmet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                                        predmet.ForeColor = System.Drawing.Color.Brown;
                                        ucitel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                                        ucitel.ForeColor = System.Drawing.Color.Brown;
                                        trida.MouseEnter += (sender, e) =>
                                        {
                                            trida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
                                            predmet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
                                            ucitel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
                                        };
                                        trida.MouseLeave += (sender, e) =>
                                        {
                                            trida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                                            predmet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                                            ucitel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                                        };
                                        predmet.MouseEnter += (sender, e) =>
                                        {
                                            trida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
                                            predmet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
                                            ucitel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
                                        };
                                        predmet.MouseLeave += (sender, e) =>
                                        {
                                            trida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                                            predmet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                                            ucitel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                                        };
                                        ucitel.MouseEnter += (sender, e) =>
                                        {
                                            trida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
                                            predmet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
                                            ucitel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
                                        };
                                        ucitel.MouseLeave += (sender, e) =>
                                        {
                                            trida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                                            predmet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                                            ucitel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                                        };
                                    }
                                }
                                else
                                {
                                    i--;
                                }
                            }
                        }
                        else
                        {
                            if (o.zkratka != "")
                            {
                                i2++;
                                if (i2 == 1)
                                {
                                    Label xzkr = new Label();
                                    panel3.Controls.Add(xzkr);
                                    xzkr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                    xzkr.ForeColor = System.Drawing.Color.Blue;
                                    xzkr.BackColor = System.Drawing.Color.LightBlue;
                                    xzkr.Location = new System.Drawing.Point(0 + wp, 0 + hp);
                                    xzkr.Size = new System.Drawing.Size(780, 63);
                                    xzkr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                    xzkr.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                    xzkr.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                    xzkr.Text = o.zkratka;
                                    ToolTip tt6 = new ToolTip();
                                    tt6.InitialDelay = 100;
                                    tt6.ReshowDelay = 100;
                                    tt6.SetToolTip(xzkr, o.zkratka);
                                    xzkr.MouseEnter += (sender, e) =>
                                    {
                                        xzkr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(183)))), ((int)(((byte)(255)))));
                                    };
                                    xzkr.MouseLeave += (sender, e) =>
                                    {
                                        xzkr.BackColor = System.Drawing.Color.LightBlue;
                                    };
                                }
                            }
                            if (o.chng != "")
                            {
                                Label vyjm = new Label();
                                panel3.Controls.Add(vyjm);
                                vyjm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                                vyjm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(148)))), ((int)(((byte)(44)))));
                                vyjm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                                vyjm.Location = new System.Drawing.Point(0 + wp, 0 + hp);
                                vyjm.Size = new System.Drawing.Size(70, 63);
                                vyjm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                vyjm.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                vyjm.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                                ToolTip tt7 = new ToolTip();
                                tt7.InitialDelay = 100;
                                tt7.ReshowDelay = 100;
                                tt7.SetToolTip(vyjm, o.chng);
                                cap = o.caption;
                                vyjm.MouseEnter += (sender, e) =>
                                {
                                    vyjm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
                                };
                                vyjm.MouseLeave += (sender, e) =>
                                {
                                    vyjm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                                };
                            }
                            wp = wp + 71;
                            cap = o.caption;
                        }
                    }
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
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            var dtp = sender as DateTimePicker;
            var selectedDate = dtp.Value;
            int offset;
            if (selectedDate.DayOfWeek != DayOfWeek.Monday)
            {
                if(selectedDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    offset = -6;
                }
                else
                {
                    offset = (int)DayOfWeek.Monday - (int)selectedDate.DayOfWeek;
                }
                var monday = selectedDate + TimeSpan.FromDays(offset);
                CalP = monday.ToString("yyyyMMdd");
            }
            else
            {
                CalP = dtp.Value.ToString("yyyyMMdd");
            }
            rozvrhurl = login.bazeurl + "&pm=rozvrh&pmd=" + CalP;
            panel1.Controls.Clear();
            panel3.Controls.Clear();
            RozvrhLoad();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            rozvrhurl = login.bazeurl + "&pm=rozvrh";
            panel1.Controls.Clear();
            panel3.Controls.Clear();
            RozvrhLoad();
        }

        private void button3_Click(object sender, EventArgs e) 
        {
            DateTime Now = DateTime.Today;
            Now = Now + TimeSpan.FromDays(7);
            int offset;
            if (Now.DayOfWeek != DayOfWeek.Monday)
            {
                if (Now.DayOfWeek == DayOfWeek.Sunday)
                {
                    offset = -6;
                }
                else
                {
                    offset = (int)DayOfWeek.Monday - (int)Now.DayOfWeek;
                }
                var monday = Now + TimeSpan.FromDays(offset);
                Pri = monday.ToString("yyyyMMdd");
            }
            else
            {
                Pri = Now.ToString("yyyyMMdd");
            }
            rozvrhurl = login.bazeurl + "&pm=rozvrh&pmd=" + Pri;
            panel3.Controls.Clear();
            panel1.Controls.Clear();
            RozvrhLoad();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            rozvrhurl = login.bazeurl + "&pm=rozvrh&pmd=perm";
            panel1.Controls.Clear();
            panel3.Controls.Clear();
            RozvrhLoad();
        }
    }
}
