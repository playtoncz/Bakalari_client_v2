using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using System.Windows.Forms;

namespace Bakaláři
{
    public partial class ukoly : Form
    {
        int mov;
        int movX;
        int movY;
        int offuk;
        int off;
        int fw;
        int h;
        int hpb;
        int c;
        int offc;
        string popisfin;
        string statustt;
        string zadanostr;
        string zadanofin;
        string nakdystr;
        string nakdyfin;
        public static string ukolyurl = login.bazeurl + "&pm=ukoly";
        public ukoly(Form parrentform)
        {
            InitializeComponent();
            offuk = 0;
            off = 0;
            offc = 0;
            fw = 0;
            h = 0;
            c = 0;
            hpb = 0;
            nakdystr = "";
            nakdyfin = "";
            statustt = "";
            try
            {
                if(Bakaláři.Properties.Settings.Default.settDu == "Všechny")
                {
                    //off ukoly
                    XElement xele = XElement.Load(ukolyurl);
                    xele.Descendants("ukol").Select(f => new
                    {
                        f.Element("predmet").Value
                    }).ToList().ForEach(f =>
                    {
                        offuk++;
                    });
                    if (offuk > 16)
                    {
                        off = 17;
                        fw = this.Width + off;
                        ClientSize = new System.Drawing.Size(fw, 500);
                        duPanel.Size = new System.Drawing.Size(fw, 437);
                        panel4.Size = new System.Drawing.Size(fw, 27);
                        pictureBox7.Size = new System.Drawing.Size(pictureBox7.Width + off, 1);
                        panelx.Size = new System.Drawing.Size(fw - 70, 35);
                        button4.Location = new System.Drawing.Point(fw - 70, 0);
                        button1.Location = new System.Drawing.Point(fw - 35, 0);
                        duPanel.AutoScroll = true;
                        c = 1;
                    }
                    else
                    {
                        duPanel.AutoScroll = false;
                    }
                    xele.Descendants("ukol").Select(g => new
                    {
                        predmet = g.Element("predmet").Value,
                        zkratka = g.Element("zkratka").Value,
                        zadano = g.Element("zadano").Value,
                        nakdy = g.Element("nakdy").Value,
                        popis = g.Element("popis").Value,
                        status = g.Element("status").Value
                    }).ToList().ForEach(g =>
                    {
                        //Popis
                        popisfin = g.popis.Replace("<br />", System.Environment.NewLine);
                        Label popislbl = new Label();
                        duPanel.Controls.Add(popislbl);
                        popislbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                        popislbl.ForeColor = System.Drawing.Color.Black;
                        popislbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        popislbl.Location = Location = new System.Drawing.Point(138, 0 + h);
                        popislbl.AutoSize = true;
                        popislbl.MinimumSize = new System.Drawing.Size(647, 27);
                        popislbl.MaximumSize = new Size(647, int.MaxValue);
                        popislbl.TextAlign = ContentAlignment.MiddleLeft;
                        popislbl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                        popislbl.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                        popislbl.Text = popisfin;
                        //Predmet
                        Label zkratkalbl = new Label();
                        duPanel.Controls.Add(zkratkalbl);
                        zkratkalbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                        zkratkalbl.ForeColor = System.Drawing.Color.Black;
                        zkratkalbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        zkratkalbl.Location = new System.Drawing.Point(72, 0 + h);
                        zkratkalbl.Size = new System.Drawing.Size(65, popislbl.Height);
                        zkratkalbl.TextAlign = ContentAlignment.MiddleCenter;
                        zkratkalbl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                        zkratkalbl.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                        zkratkalbl.Text = g.zkratka;
                        //Predmet - tooltip
                        ToolTip tt1 = new ToolTip();
                        tt1.InitialDelay = 100;
                        tt1.ReshowDelay = 100;
                        tt1.SetToolTip(zkratkalbl, g.predmet);
                        //Nakdy
                        nakdystr = g.nakdy; //RRMMDD
                        nakdyfin = nakdystr.Substring(4, 2) + ". " + nakdystr.Substring(2, 2) + "."; //DD. MM.
                        if (nakdyfin.Substring(0, 1) == "0")
                        {
                            nakdyfin = nakdyfin.Substring(1, 6); //D. MM.
                            if (nakdyfin.Substring(3, 1) == "0")
                            {
                                nakdyfin = nakdyfin.Substring(0, 3) + nakdyfin.Substring(4, 2); //D. M.
                            }
                        }
                        else
                        {
                            if (nakdyfin.Substring(4, 1) == "0")
                            {
                                nakdyfin = nakdyfin.Substring(0, 4) + nakdyfin.Substring(5, 2); //DD. M.
                            }
                        }
                        Label nakdylbl = new Label();
                        duPanel.Controls.Add(nakdylbl);
                        nakdylbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                        nakdylbl.ForeColor = System.Drawing.Color.Black;
                        nakdylbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        nakdylbl.Location = new System.Drawing.Point(19, 0 + h);
                        nakdylbl.Size = new System.Drawing.Size(52, popislbl.Height);
                        if (g.status == "aktivni")
                        {
                            nakdylbl.Location = new System.Drawing.Point(0, 0 + h);
                            nakdylbl.Size = new System.Drawing.Size(71, popislbl.Height);
                        }
                        nakdylbl.TextAlign = ContentAlignment.MiddleCenter;
                        nakdylbl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                        nakdylbl.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                        nakdylbl.Text = nakdyfin;
                        //Status
                        Label statuslbl = new Label();
                        duPanel.Controls.Add(statuslbl);
                        if (g.status != "aktivni")
                        {
                            statuslbl.Font = new System.Drawing.Font("Arial", 18.25F);
                            statuslbl.ForeColor = System.Drawing.Color.Black;
                            statuslbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            statuslbl.Location = Location = new System.Drawing.Point(0, 0 + h);
                            statuslbl.Size = new System.Drawing.Size(19, popislbl.Height);
                            statuslbl.TextAlign = ContentAlignment.MiddleLeft;
                            statuslbl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                            statuslbl.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                            if (g.status == "probehlo")
                            {
                                statuslbl.Text = "✓";
                                statustt = "proběhlo";
                            }
                            if (g.status == "neodevzdal")
                            {
                                statuslbl.Text = "✗";
                                statustt = "neodevzdal";
                            }
                            if (g.status == "pozde")
                            {
                                statuslbl.Text = "✗";
                                statustt = "pozdě";
                            }
                            //Status - tooltip
                            ToolTip tt2 = new ToolTip();
                            tt2.InitialDelay = 100;
                            tt2.ReshowDelay = 100;
                            tt2.SetToolTip(statuslbl, statustt);
                        }
                        //Zadano
                        zadanostr = g.zadano; //RRMMDD
                        zadanofin = zadanostr.Substring(4, 2) + ". " + zadanostr.Substring(2, 2) + "."; //DD. MM.
                        if (zadanofin.Substring(0, 1) == "0")
                        {
                            zadanofin = zadanofin.Substring(1, 6); //D. MM.
                            if (zadanofin.Substring(3, 1) == "0")
                            {
                                zadanofin = zadanofin.Substring(0, 3) + zadanofin.Substring(4, 2); //D. M.
                            }
                        }
                        else
                        {
                            if (zadanofin.Substring(4, 1) == "0")
                            {
                                zadanofin = zadanofin.Substring(0, 4) + zadanofin.Substring(5, 2); //DD. M.
                            }
                        }
                        Label zadanolbl = new Label();
                        duPanel.Controls.Add(zadanolbl);
                        zadanolbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                        zadanolbl.ForeColor = System.Drawing.Color.Black;
                        zadanolbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        zadanolbl.Location = new System.Drawing.Point(786, 0 + h);
                        zadanolbl.Size = new System.Drawing.Size(62, popislbl.Height);
                        zadanolbl.TextAlign = ContentAlignment.MiddleCenter;
                        zadanolbl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                        zadanolbl.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                        zadanolbl.Text = zadanofin;
                        //PBline
                        hpb = hpb + popislbl.Height;
                        PictureBox pbline = new PictureBox();
                        duPanel.Controls.Add(pbline);
                        pbline.BackColor = System.Drawing.Color.Silver;
                        pbline.Location = new System.Drawing.Point(0, hpb);
                        pbline.Size = new System.Drawing.Size(this.Width - off, 1);
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
                        h = h + popislbl.Height;
                        offc = offc + popislbl.Height;
                        //Text color
                        if (g.status == "probehlo")
                        {
                            popislbl.ForeColor = System.Drawing.Color.Gray;
                            zkratkalbl.ForeColor = System.Drawing.Color.Gray;
                            nakdylbl.ForeColor = System.Drawing.Color.Gray;
                            zadanolbl.ForeColor = System.Drawing.Color.Gray;
                            statuslbl.ForeColor = System.Drawing.Color.Gray;
                        }
                        if (g.status == "neodevzdal")
                        {
                            popislbl.ForeColor = System.Drawing.Color.Gray;
                            zkratkalbl.ForeColor = System.Drawing.Color.Gray;
                            nakdylbl.ForeColor = System.Drawing.Color.Gray;
                            zadanolbl.ForeColor = System.Drawing.Color.Gray;
                            statuslbl.ForeColor = System.Drawing.Color.Gray;
                        }
                        if (g.status == "pozde")
                        {
                            popislbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                            zkratkalbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                            nakdylbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                            zadanolbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                            statuslbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                        }
                        if (g.status == "aktivni")
                        {
                            popislbl.ForeColor = System.Drawing.Color.Black;
                            zkratkalbl.ForeColor = System.Drawing.Color.Black;
                            nakdylbl.ForeColor = System.Drawing.Color.Black;
                            zadanolbl.ForeColor = System.Drawing.Color.Black;
                            statuslbl.ForeColor = System.Drawing.Color.Black;
                        }
                        //Action
                        popislbl.MouseEnter += (sender, e) =>
                        {
                            popislbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                            zkratkalbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                            nakdylbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                            zadanolbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                            statuslbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                        };
                        popislbl.MouseLeave += (sender, e) =>
                        {
                            popislbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            zkratkalbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            nakdylbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            zadanolbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            statuslbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        };
                        zkratkalbl.MouseEnter += (sender, e) =>
                        {
                            popislbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                            zkratkalbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                            nakdylbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                            zadanolbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                            statuslbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                        };
                        zkratkalbl.MouseLeave += (sender, e) =>
                        {
                            popislbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            zkratkalbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            nakdylbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            zadanolbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            statuslbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        };
                        nakdylbl.MouseEnter += (sender, e) =>
                        {
                            popislbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                            zkratkalbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                            nakdylbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                            zadanolbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                            statuslbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                        };
                        nakdylbl.MouseLeave += (sender, e) =>
                        {
                            popislbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            zkratkalbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            nakdylbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            zadanolbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            statuslbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        };
                        zadanolbl.MouseEnter += (sender, e) =>
                        {
                            popislbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                            zkratkalbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                            nakdylbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                            zadanolbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                            statuslbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                        };
                        zadanolbl.MouseLeave += (sender, e) =>
                        {
                            popislbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            zkratkalbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            nakdylbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            zadanolbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            statuslbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        };
                        statuslbl.MouseEnter += (sender, e) =>
                        {
                            popislbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                            zkratkalbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                            nakdylbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                            zadanolbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                            statuslbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                        };
                        statuslbl.MouseLeave += (sender, e) =>
                        {
                            popislbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            zkratkalbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            nakdylbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            zadanolbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            statuslbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                        };
                    });
                }
                else
                {
                    //off ukoly
                    XElement xele = XElement.Load(ukolyurl);
                    xele.Descendants("ukol").Select(f => new
                    {
                        status = f.Element("status").Value
                    }).ToList().ForEach(f =>
                    {
                        if(f.status == "aktivni")
                        {
                            offuk++;
                        }
                    });
                    if (offuk > 16)
                    {
                        off = 17;
                        fw = this.Width + off;
                        ClientSize = new System.Drawing.Size(fw, 500);
                        duPanel.Size = new System.Drawing.Size(fw, 437);
                        panel4.Size = new System.Drawing.Size(fw, 27);
                        pictureBox7.Size = new System.Drawing.Size(pictureBox7.Width + off, 1);
                        panelx.Size = new System.Drawing.Size(fw - 70, 35);
                        button4.Location = new System.Drawing.Point(fw - 70, 0);
                        button1.Location = new System.Drawing.Point(fw - 35, 0);
                        duPanel.AutoScroll = true;
                        c = 1;
                    }
                    else
                    {
                        duPanel.AutoScroll = false;
                    }
                    xele.Descendants("ukol").Select(g => new
                    {
                        predmet = g.Element("predmet").Value,
                        zkratka = g.Element("zkratka").Value,
                        zadano = g.Element("zadano").Value,
                        nakdy = g.Element("nakdy").Value,
                        popis = g.Element("popis").Value,
                        status = g.Element("status").Value
                    }).ToList().ForEach(g =>
                    {
                        if(g.status == "aktivni")
                        {
                            //Popis
                            popisfin = g.popis.Replace("<br />", System.Environment.NewLine);
                            Label popislbl = new Label();
                            duPanel.Controls.Add(popislbl);
                            popislbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                            popislbl.ForeColor = System.Drawing.Color.Black;
                            popislbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            popislbl.Location = Location = new System.Drawing.Point(138, 0 + h);
                            popislbl.AutoSize = true;
                            popislbl.MinimumSize = new System.Drawing.Size(647, 27);
                            popislbl.MaximumSize = new Size(647, int.MaxValue);
                            popislbl.TextAlign = ContentAlignment.MiddleLeft;
                            popislbl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                            popislbl.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                            popislbl.Text = popisfin;
                            //Predmet
                            Label zkratkalbl = new Label();
                            duPanel.Controls.Add(zkratkalbl);
                            zkratkalbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                            zkratkalbl.ForeColor = System.Drawing.Color.Black;
                            zkratkalbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            zkratkalbl.Location = new System.Drawing.Point(72, 0 + h);
                            zkratkalbl.Size = new System.Drawing.Size(65, popislbl.Height);
                            zkratkalbl.TextAlign = ContentAlignment.MiddleCenter;
                            zkratkalbl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                            zkratkalbl.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                            zkratkalbl.Text = g.zkratka;
                            //Predmet - tooltip
                            ToolTip tt1 = new ToolTip();
                            tt1.InitialDelay = 100;
                            tt1.ReshowDelay = 100;
                            tt1.SetToolTip(zkratkalbl, g.predmet);
                            //Nakdy
                            nakdystr = g.nakdy; //RRMMDD
                            nakdyfin = nakdystr.Substring(4, 2) + ". " + nakdystr.Substring(2, 2) + "."; //DD. MM.
                            if (nakdyfin.Substring(0, 1) == "0")
                            {
                                nakdyfin = nakdyfin.Substring(1, 6); //D. MM.
                                if (nakdyfin.Substring(3, 1) == "0")
                                {
                                    nakdyfin = nakdyfin.Substring(0, 3) + nakdyfin.Substring(4, 2); //D. M.
                                }
                            }
                            else
                            {
                                if (nakdyfin.Substring(4, 1) == "0")
                                {
                                    nakdyfin = nakdyfin.Substring(0, 4) + nakdyfin.Substring(5, 2); //DD. M.
                                }
                            }
                            Label nakdylbl = new Label();
                            duPanel.Controls.Add(nakdylbl);
                            nakdylbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                            nakdylbl.ForeColor = System.Drawing.Color.Black;
                            nakdylbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            nakdylbl.Location = new System.Drawing.Point(0, 0 + h);
                            nakdylbl.Size = new System.Drawing.Size(71, popislbl.Height);
                            nakdylbl.TextAlign = ContentAlignment.MiddleCenter;
                            nakdylbl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                            nakdylbl.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                            nakdylbl.Text = nakdyfin;
                            //Zadano
                            zadanostr = g.zadano; //RRMMDD
                            zadanofin = zadanostr.Substring(4, 2) + ". " + zadanostr.Substring(2, 2) + "."; //DD. MM.
                            if (zadanofin.Substring(0, 1) == "0")
                            {
                                zadanofin = zadanofin.Substring(1, 6); //D. MM.
                                if (zadanofin.Substring(3, 1) == "0")
                                {
                                    zadanofin = zadanofin.Substring(0, 3) + zadanofin.Substring(4, 2); //D. M.
                                }
                            }
                            else
                            {
                                if (zadanofin.Substring(4, 1) == "0")
                                {
                                    zadanofin = zadanofin.Substring(0, 4) + zadanofin.Substring(5, 2); //DD. M.
                                }
                            }
                            Label zadanolbl = new Label();
                            duPanel.Controls.Add(zadanolbl);
                            zadanolbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                            zadanolbl.ForeColor = System.Drawing.Color.Black;
                            zadanolbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            zadanolbl.Location = new System.Drawing.Point(786, 0 + h);
                            zadanolbl.Size = new System.Drawing.Size(62, popislbl.Height);
                            zadanolbl.TextAlign = ContentAlignment.MiddleCenter;
                            zadanolbl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                            zadanolbl.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                            zadanolbl.Text = zadanofin;
                            //PBline
                            hpb = hpb + popislbl.Height;
                            PictureBox pbline = new PictureBox();
                            duPanel.Controls.Add(pbline);
                            pbline.BackColor = System.Drawing.Color.Silver;
                            pbline.Location = new System.Drawing.Point(0, hpb);
                            pbline.Size = new System.Drawing.Size(this.Width - off, 1);
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
                            h = h + popislbl.Height;
                            offc = offc + popislbl.Height;
                            //Action
                            popislbl.MouseEnter += (sender, e) =>
                            {
                                popislbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                zkratkalbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                nakdylbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                zadanolbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                            };
                            popislbl.MouseLeave += (sender, e) =>
                            {
                                popislbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                zkratkalbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                nakdylbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                zadanolbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            };
                            zkratkalbl.MouseEnter += (sender, e) =>
                            {
                                popislbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                zkratkalbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                nakdylbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                zadanolbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                            };
                            zkratkalbl.MouseLeave += (sender, e) =>
                            {
                                popislbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                zkratkalbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                nakdylbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                zadanolbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            };
                            nakdylbl.MouseEnter += (sender, e) =>
                            {
                                popislbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                zkratkalbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                nakdylbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                zadanolbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                            };
                            nakdylbl.MouseLeave += (sender, e) =>
                            {
                                popislbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                zkratkalbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                nakdylbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                zadanolbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            };
                            zadanolbl.MouseEnter += (sender, e) =>
                            {
                                popislbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                zkratkalbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                nakdylbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                                zadanolbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(203)))), ((int)(((byte)(247)))));
                            };
                            zadanolbl.MouseLeave += (sender, e) =>
                            {
                                popislbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                zkratkalbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                nakdylbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                                zadanolbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
                            };
                        }
                    });
                }
                if (offc >= duPanel.Height && c == 0)
                {
                    off = 17;
                    fw = this.Width + off;
                    ClientSize = new System.Drawing.Size(fw, 500);
                    duPanel.Size = new System.Drawing.Size(fw, 437);
                    panel4.Size = new System.Drawing.Size(fw, 27);
                    pictureBox7.Size = new System.Drawing.Size(pictureBox7.Width + off, 1);
                    panelx.Size = new System.Drawing.Size(fw - 70, 35);
                    button4.Location = new System.Drawing.Point(fw - 70, 0);
                    button1.Location = new System.Drawing.Point(fw - 35, 0);
                    duPanel.AutoScroll = true;
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
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = System.Drawing.Color.Gainsboro;
        }
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = System.Drawing.Color.Silver;
        }
        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.BackColor = System.Drawing.Color.Gainsboro;
        }
        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = System.Drawing.Color.Silver;
        }
        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = System.Drawing.Color.Silver;
        }
        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.BackColor = System.Drawing.Color.Gainsboro;
        }
    }
}
