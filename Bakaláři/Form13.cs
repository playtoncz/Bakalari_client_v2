using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Bakaláři
{
    public partial class searchSchool : Form
    {
        private int mov;
        private int movX;
        private int movY;
        string url;
        public string schoolURL;
        logsett log;

        public searchSchool(logsett parrentform)
        {
            InitializeComponent();
            log = parrentform;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void searchSchool_Load(object sender, EventArgs e)
        {
            try
            {
                XElement xele = XElement.Load("https://sluzby.bakalari.cz/api/v1/municipality");
                xele.Descendants("municipalityInfo").Select(f => new
                {
                    name = f.Element("name").Value
                }).ToList().ForEach(f =>
                {
                    comboBox1.Items.Add(f.name);
                });
            }
            catch
            {
                MessageBox.Show("Něco se nepodařilo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }

        }
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox2.Enabled = true;
                comboBox2.Items.Clear();
                url = "https://sluzby.bakalari.cz/api/v1/municipality/" + comboBox1.SelectedItem;
                XElement xeles = XElement.Load(url);
                xeles.Descendants("schoolInfo").Select(s => new
                {
                    name = s.Element("name").Value
                }).ToList().ForEach(s =>
                {
                    comboBox2.Items.Add(s.name);
                });
            }
            catch
            {
                MessageBox.Show("Něco se nepodařilo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.Text != "")
                {
                    XElement xelec = XElement.Load(url);
                    xelec.Descendants("schoolInfo").Select(g => new
                    {
                        name = g.Element("name").Value,
                        sUrl = g.Element("schoolUrl").Value
                    }).ToList().ForEach(g =>
                    {
                        if (g.name == comboBox2.Text)
                        {
                            schoolURL = g.sUrl;
                           
                            if (!schoolURL.EndsWith("/login.aspx"))
                            {
                                if (schoolURL.Contains("/login.aspx"))
                                {
                                    int index = 0;
                                    index = schoolURL.IndexOf("/login.aspx") + 11;
                                    schoolURL = schoolURL.Substring(0, index);
                                }
                                
                            }
                            Bakaláři.Properties.Settings.Default.link = schoolURL;
                            Bakaláři.Properties.Settings.Default.Save();
                            log.textBox1.Text = schoolURL;
                            log.label5.Text = schoolURL;
                            this.Close();
                        }
                    });
                }
                else
                {
                    MessageBox.Show("Zadejte školu!", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Něco se nepodařilo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }
    }
}
