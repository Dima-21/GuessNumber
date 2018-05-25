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
        InfoNum info;
        bool isStart = false;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            info.Coincidpos = info.Coincid = 0;
            if (!isStart)
            {
                timer1.Start();
                timer = DateTime.Now;
                isStart = true;
            }
            CheckNum();
            if (Convert.ToString(info.Num).Length == info.Coincidpos)
                Finish();
            Show();
            textNum.Text = String.Empty;
        }
       

        private void timer1_Tick(object sender, EventArgs e)
        {
            long tick = DateTime.Now.Ticks - timer.Ticks;
            DateTime stopWatch = new DateTime();
            stopWatch = stopWatch.AddTicks(tick);

            textTime.Text = String.Format("{0:HH : mm : ss : ff}", stopWatch);
        }

        private void textNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == 8)
                return;
            else if (e.KeyChar == 13)
                button1_Click(sender, e);
            else
                e.Handled = true;
        }


        private void LEasy_CheckedChanged(object sender, EventArgs e)
        {
            if (LEasy.Checked)
                info.Num = rand.Next(100, 1000);
            NewGame();
        }

        private void LAverage_CheckedChanged(object sender, EventArgs e)
        {
            if (LAverage.Checked)
                info.Num = rand.Next(10000, 100000);
            NewGame();
        }

        private void LHard_CheckedChanged(object sender, EventArgs e)
        {
            if (LHard.Checked)
                info.Num = rand.Next(1000000, 10000000);
            NewGame();
        }

        private void Show()
        {
            if (textNum.Text != "")
            {
                textHistory.Text = textHistory.Text.Insert(0, $"{textNum.Text}   {info.Coincid} {info.Coincidpos} {Environment.NewLine}");
                textBox1.Text = textNum.Text;
                textBox2.Text = $"{info.Coincid}";
                textBox3.Text = $"{info.Coincidpos}";
            }
            label6.Text = $"{info.Attempt}";
        }

        private void CheckNum()
        {
            if (textNum.Text != "")
            {
                string numtmp = Convert.ToString(info.Num);
                for (int i = 0; i < numtmp.Length; i++)
                {
                    if (textNum.Text.IndexOf(numtmp[i]) >= 0)
                        info.Coincid++;
                    if (i < textNum.Text.Length && textNum.Text[i] == numtmp[i])
                        info.Coincidpos++;
                }
                info.Attempt++;
            }
        }
        private void NewGame()
        {
            info.Attempt = 0;
            textHistory.Text = textBox1.Text = textBox2.Text = textBox3.Text = String.Empty;
            timer1.Stop();
            textTime.Text = "00 : 00 : 00 : 00";
            isStart = false;
            Show();
        }

        private void Finish()
        {
            textNum.Text = String.Empty;
            timer1.Stop();
            MessageBox.Show($"Поздравляю, вы победили за: {textTime.Text}. Вы использовали {info.Attempt-1} подсказок");
            NewGame();
        }

    
    }
}
