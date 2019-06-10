using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class InitialScreen : Form
    {
        public InitialScreen()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
          //  this.Hide();
            MasterForm formAsMaster = new MasterForm();
            formAsMaster.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            SlaveForm formAsSlave = new SlaveForm();
            formAsSlave.Show();
        }

        private void InitialScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
