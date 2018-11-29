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

        public void NewGame()
        {
            udvoitel = new Udvoitel(28);
            udvoitel.RaiseWinLose += WinLoseEvent;
            UpdateInfo();
        }

        public Form1()
        {
            InitializeComponent();
            NewGame();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?","Leave this game",MessageBoxButtons.YesNo)==DialogResult.Yes)  this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            udvoitel?.Reset();
            UpdateInfo();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            udvoitel?.GetLastMoveFromHistory();
            UpdateInfo();
        }

        private void WinLoseEvent(object sender, WinLoseEventArgs e)
        {

            UpdateInfo();

            MessageBox.Show($"{e.Message}");

            udvoitel?.Reset();
            UpdateInfo();
        }
    }

    public class WinLoseEventArgs : EventArgs
    {
        private string msg;
        private bool result;

        public WinLoseEventArgs(string textMessage, bool gameResult)
        {
            msg = textMessage;
            result = gameResult;
        }

        public string Message
        {
            get { return this.msg; }
        }

        public bool GameResult
        {
            get { return this.result; }
        }
    }
}
