using System;
using System.Windows.Forms;

namespace Bakaláři
{
    public partial class logsett : Form
    {
        int mov;
        int movX;
        int movY;
        public logsett(Form parrentForm)
        {
            InitializeComponent();
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
            if(textBox1.Text != Bakaláři.Properties.Settings.Default.link)
            {
                DialogResult result = MessageBox.Show("Chcete uložit změny?", "Bakaláři – Nastavení", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                   
                    Bakaláři.Properties.Settings.Default.link = textBox1.Text;
                    Bakaláři.Properties.Settings.Default.Save();
                    label5.Text = Bakaláři.Properties.Settings.Default.link;
                    this.Close();
                }
                else if (result == DialogResult.No)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            Bakaláři.Properties.Settings.Default.link = textBox1.Text;
            Bakaláři.Properties.Settings.Default.Save();
            label5.Text = Bakaláři.Properties.Settings.Default.link;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "https://goa-orlova.bakalari.cz:444/login";
        }

        private void logsett_Load(object sender, EventArgs e)
        {
            label5.Text = Bakaláři.Properties.Settings.Default.link;
            textBox1.Text = Bakaláři.Properties.Settings.Default.link;
        }
        

        private void button8_Click(object sender, EventArgs e)
        {
            Form searchS = new searchSchool(this);
            try { searchS.ShowDialog(); }
            catch { }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
