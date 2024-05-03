using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSProject
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loginform lgfm = new loginform();
            lgfm.MdiParent = this;
            lgfm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            signupform sgfm = new signupform();
            sgfm.MdiParent = this;
            sgfm.Show();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataform dtfm = new dataform();
            dtfm.MdiParent = this;
            dtfm.Show();
        }
    }
}
