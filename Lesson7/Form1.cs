using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson7
{
    public partial class Form1 : Form
    {
        Udvoitel udvoitel=null;

        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?","Info",MessageBoxButtons.YesNo)==DialogResult.Yes)  this.Close();
            
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            udvoitel = new Udvoitel(28);
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            lblCurrent.Text = udvoitel?.Current.ToString();
            tbFinish.Text = udvoitel?.Finish.ToString();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (udvoitel != null)
            {
                udvoitel.Plus();
                UpdateInfo();
            }
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            udvoitel?.Multi();
            UpdateInfo();
        }
    }
}
