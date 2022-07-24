using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinoptikWinforms.Model
{
    internal class TemperatureModel
    {
        public double TodayTemp { get; set; }
        public double MaxTemp { get; set; }
        public double MinTemp { get; set; }
        public string ImgUrl { get; set; }
        public string[] SmallImgUrls { get; set; } = new string[8];
        public string[] Temperatures { get; set; } = new string[8];
        public string[] TemperatureFeel { get; set; } = new string[8];
        public string[] Pressure { get; set; } = new string[8];
        public string[] Humidity { get; set; } = new string[8];
        public string[] Wind { get; set; } = new string[8];
        public string[] PrecipitationPercent { get; set; } = new string[8];
        public string Description { get; set; }
    }
}
