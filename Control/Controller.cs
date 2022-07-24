using HtmlAgilityPack;
using SinoptikWinforms.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SinoptikWinforms.Control
{
    internal class Controller
    {
        public TemperatureModel TemperatureData { get; set; } = new TemperatureModel();
        WebClient Client { get; set; } = new WebClient();

        public Controller()
        {
            string html = Encoding.UTF8.GetString(Client.DownloadData("https://sinoptik.ua/%D0%BF%D0%BE%D0%B3%D0%BE%D0%B4%D0%B0-%D0%B4%D0%BD%D0%B5%D0%BF%D1%80-303007131"));
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            //main info
            var minMaxNodes = htmlDoc.DocumentNode.SelectNodes("//p[@class='infoHistoryval']//span");
            TemperatureData.MaxTemp = double.Parse(minMaxNodes[0].InnerText.Replace("&deg;", ""), CultureInfo.InvariantCulture);
            TemperatureData.MinTemp = double.Parse(minMaxNodes[1].InnerText.Replace("&deg;", ""), CultureInfo.InvariantCulture);
            TemperatureData.TodayTemp = double.Parse(htmlDoc.DocumentNode.SelectSingleNode("//p[@class='today-temp']").InnerText.Replace("&deg;C", ""), CultureInfo.InvariantCulture);
            TemperatureData.ImgUrl = "http://" + htmlDoc.DocumentNode.SelectSingleNode("//div[@class='img']//img").Attributes[2].Value.Substring(2);

            //detailed info
            TemperatureData.Temperatures = htmlDoc.DocumentNode.SelectSingleNode("//tr[@class='temperature']").InnerText.Trim().Replace("&deg;", "°").Split(' ');
            TemperatureData.TemperatureFeel = htmlDoc.DocumentNode.SelectSingleNode("//tr[@class='temperatureSens']").InnerText.Trim().Replace("&deg;", "°").Split(' ');
            TemperatureData.Pressure = htmlDoc.DocumentNode.SelectSingleNode("//tr[@class='gray']").InnerText.Trim().Split(' ');
            TemperatureData.Humidity = htmlDoc.DocumentNode.SelectSingleNode("//table[@class='weatherDetails']//tbody//tr[not(@class)]").InnerText.Trim().Split(' ');
            TemperatureData.Wind = htmlDoc.DocumentNode.SelectNodes("//tr[@class='gray']")[1].InnerText.Trim().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            TemperatureData.PrecipitationPercent = htmlDoc.DocumentNode.SelectNodes("//table[@class='weatherDetails']//tbody//tr[not(@class)]")[1].InnerText.Trim().Split(' ');
            TemperatureData.Description = htmlDoc.DocumentNode.SelectNodes("//div[@class='description']")[0].InnerText.Trim()
                                          + "\n\n\n"
                                          + htmlDoc.DocumentNode.SelectNodes("//div[@class='description']")[1].InnerText.Trim();
            for (int i = 0; i < 8; i++)
                TemperatureData.SmallImgUrls[i] = htmlDoc.DocumentNode.SelectSingleNode("//tr[@class='img weatherIcoS']").SelectNodes("//td//div//img")[i].GetAttributeValue("src", "notfound");

        }
    }
}
