using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_GuessNumber
{
    public partial class Form1 : Form
    {
        DateTime timer;
        Random rand = new Random();
        long num;
        bool isStart = false;
        public Form1()
        {
            InitializeComponent();
            
        }
        private void CreateNumber()
        {
            if(LEasy.Checked)
                num = rand.Next(100, 1000);
            else if(LAverage.Checked)
                num = rand.Next(10000, 100000);
            else if(LHard.Checked)
                num = rand.Next(1000000, 10000000);
            isStart = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(!isStart)
                CreateNumber();
            timer1.Start();
            timer = DateTime.Now;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            long tick = DateTime.Now.Ticks - timer.Ticks;
            DateTime stopWatch = new DateTime();
            stopWatch = stopWatch.AddTicks(tick);

            textTime.Text = String.Format("{0:HH : mm : ss : ff}", stopWatch);
        }
    }
}
