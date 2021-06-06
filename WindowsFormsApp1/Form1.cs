using DocumentFormat.OpenXml.Bibliography;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)

        {
            string city = textBox1.Text;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Err");
                return;
            }

            string url = "http://api.openweathermap.org/data/2.5/weather?q=" + city + "&type=like&appid=c3f93d23f4afc931f07743b1f8a9ffc6";
            System.Net.WebRequest reqGET = System.Net.WebRequest.Create(url);
            System.Net.WebResponse resp = reqGET.GetResponse();
            System.IO.Stream stream = resp.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            string s = sr.ReadToEnd();
            JObject o = JObject.Parse(s);
            JToken k = o["main"]["humidity"];
            JToken d = o["main"]["pressure"];
            JToken c = o["weather"][0]["description"];
            JToken b = o["main"]["temp"];
            JToken g = o["wind"]["speed"];
            JToken bh = o["wind"]["deg"];
            int pressure = Convert.ToInt32(d);
            int humidity = Convert.ToInt32(k);
            int windDegree = Convert.ToInt32(bh);
            int windSpeed = Convert.ToInt32(g);
            string description = c.ToString();
            string windDegreeName = "";
            if (windDegree >= 337.5 && windDegree <= 360 || windDegree <= 22.5 && windDegree >= 0)
            {
                windDegreeName = "северное";
            }
            if (windDegree >= 22.6 && windDegree <= 68.5)
            {
                windDegreeName = "северо-восточное";
            }
            if (windDegree <= 112.5 && windDegree >= 68.6)
            {
                windDegreeName = "восточное";
            }
            if (windDegree >= 292.5 && windDegree <= 338.6)
            {
                windDegreeName = "северо-западное";
            }
            if (windDegree >= 248.5 && windDegree <= 292.6)
            {
                windDegreeName = "западное";
            }
            if (windDegree >= 202.5 && windDegree <= 248.6)
            {
                windDegreeName = "юго-западное";

            }
            if (windDegree <= 158.6 && windDegree >= 112.6)
            {
                windDegreeName = "юго-восточное";
            }
            if (windDegree >= 158.6 && windDegree <= 202.6)
            {
                windDegreeName = "южное";
            }
           
            int f = Convert.ToInt32(b) - 273;
            label1.Text = ("Температура: ") + (f) + ("C").ToString();
            label2.Text = ("Скорость Ветра: ") + (windSpeed * 2.2) + ("м/с").ToString();
            label3.Text = windDegreeName;
            label4.Text = ("Влажность: ") + (humidity) + ("%").ToString();
            label5.Text = ("Давление: ") + d.ToString();
            label14.Text = c.ToString();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
