using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace POS
{
    public partial class loadingScreen : Form
    {
        public loadingScreen()
        {

            InitializeComponent();
            this.BackColor = Color.Gray;
            this.TransparencyKey = Color.Gray;
            timer1.Start();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressbar.Value < 100)
            {
                progressbar.Value += 2;
                label1.Text = progressbar.Value.ToString() + "%";
            }
            else
            {
                timer1.Stop();
                Form1 login = new Form1();
                login.Show();
                this.Hide();
            }
        }
    }
}
