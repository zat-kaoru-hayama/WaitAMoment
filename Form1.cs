using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaitAMoment
{
    public partial class Form1 : Form
    {
        private string target;
        private int flag;

        public Form1(string target)
        {
            InitializeComponent();
            this.target = target;
            this.flag = 0;
            // this.label1.Text = target; // for debug.

            this.timer1.Interval = 1000; // 1 second.
            this.timer1.Enabled = true;
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var processes = System.Diagnostics.Process.GetProcessesByName(target);
            if ( flag == 0 && processes.Length >= 1 && ! processes[0].HasExited ) {
                // プロセスは確かに立ち上がった.
                flag = 1;
                // this.BackColor = Color.Red; // for debug
            } else if( flag == 1 && ( processes.Length < 1 || processes[0].HasExited ))
            {
                // 一度起動したプロセスが終了した。
                this.Close();
            }
        }
    }
}
