using SinoptikWinforms.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinoptikWinforms
{
    public partial class Form1 : Form
    {
        Controller controller = new Controller();
        public Form1()
        {
            InitializeComponent();
            this.TodayTempLabel.Text = $"Сегодня:{controller.TemperatureData.TodayTemp}\x00B0";
            this.MaxTempLabel.Text = $"Макс:{controller.TemperatureData.MaxTemp}\x00B0";
            this.MinTempLabel.Text = $"Мин:{controller.TemperatureData.MinTemp}\x00B0";
            this.WeatherPictureBox.ImageLocation = controller.TemperatureData.ImgUrl;
            this.DescriptionLabel.Text = controller.TemperatureData.Description;

            for (int i = 0; i < 8; i++)
            {
                (this.SmallWeatherIcosPanel.Controls[i] as PictureBox).ImageLocation = "https:" + controller.TemperatureData.SmallImgUrls[i];
                (this.TemperaturePanel.Controls[i] as Label).Text = controller.TemperatureData.Temperatures[i];
                (this.TempSensPanel.Controls[i] as Label).Text = controller.TemperatureData.TemperatureFeel[i];
                (this.PressurePanel.Controls[i] as Label).Text = controller.TemperatureData.Pressure[i];
                (this.HumidityPanel.Controls[i] as Label).Text = controller.TemperatureData.Humidity[i];
                (this.WindPanel.Controls[i] as Label).Text = controller.TemperatureData.Wind[i];
                (this.PrecipitationPanel.Controls[i] as Label).Text = controller.TemperatureData.PrecipitationPercent[i];
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void weatherIcon5_Click(object sender, EventArgs e)
        {

        }

        private void TemperaturePanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
