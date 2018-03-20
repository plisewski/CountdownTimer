using System;
using System.Drawing;
using System.Windows.Forms;

namespace CountdownTimer
{
    public partial class Form1 : Form
    {
        double godziny, minuty, sekundy, timeCounting, timeTotal;
        DateTime dateTime;
        TimeSpan ts;

        public Form1()
        {
            InitializeComponent();
            progressBar1.Value = 100;
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {            
            sekundy--;

            ts = new TimeSpan((int)godziny, (int)minuty, (int)sekundy);
            dateTime = dateTime.Date + ts;

            label4.Text = dateTime.Hour + " : " + dateTime.Minute + " : " + dateTime.Second;

            timeCounting--;

            if (timeCounting == 0)
            {
                timer1.Stop();
            }

            progressBar1.Value = (int) (timeCounting / timeTotal * 100);

            label6.Text = string.Format((timeCounting / timeTotal).ToString(("0.00") + " %"));

            if (progressBar1.Value < 50)
            {
                label4.ForeColor = Color.Yellow;
                label6.ForeColor = Color.Yellow;
            }
                

            if (progressBar1.Value < 20)
            {
                label4.ForeColor = Color.Red;
                label6.ForeColor = Color.Red;
            }
                

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label4.Text = trackBar1.Value + " : " + trackBar2.Value + " : " + trackBar3.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 100;

            godziny = trackBar1.Value;
            minuty = trackBar2.Value;
            sekundy = trackBar3.Value;

            ts = new TimeSpan((int)godziny, (int)minuty, (int)sekundy);
            dateTime = dateTime.Date + ts;

            timeTotal = godziny * 60 * 60 + minuty * 60 + sekundy;
            timeCounting = timeTotal;

            label4.ForeColor = Color.Black;
            timer1.Start();
        }
    }
}
