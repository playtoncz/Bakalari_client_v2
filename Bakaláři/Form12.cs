using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace Bakaláři
{
    public partial class about : Form
    {
        int mov;
        int movX;
        int movY;
        public about(sett parrentform)
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
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try { System.Diagnostics.Process.Start("https://pastebin.com/b1XgASAZ"); }
            catch { }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try { System.Diagnostics.Process.Start("https://github.com/Nkaskaj/BakalariClient"); }
            catch { }
        }
        private void about_Load(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fileVersionInfo.ProductVersion;
            label7.Text = version;
        }
    }
}
