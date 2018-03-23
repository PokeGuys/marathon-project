using System;
using System.Xml;

namespace MarathonSystem.Controllers
{
    class WeatherController
    {        
        public static string GetCTemp()
        {
            string CTemp;
            XmlDocument current = new XmlDocument();
            current.Load("http://api.openweathermap.org/data/2.5/weather?q=HongKong,HK&APPID=d5893e0f95d5b904852d99527213b7cc&mode=xml");
            XmlElement croot = current.DocumentElement;
            XmlNode Ctemperature = croot.SelectSingleNode("/current/temperature");
            CTemp = Ctemperature.Attributes["value"].Value.ToString();
            CTemp = KToC(double.Parse(CTemp, System.Globalization.CultureInfo.InvariantCulture));
            return CTemp;
        }
        public static string GetCHumi()
        {
            string CHumi;
            XmlDocument current = new XmlDocument();
            current.Load("http://api.openweathermap.org/data/2.5/weather?q=HongKong,HK&APPID=d5893e0f95d5b904852d99527213b7cc&mode=xml");
            XmlElement croot = current.DocumentElement;            
            XmlNode CHumidity = croot.SelectSingleNode("/current/humidity ");
            CHumi = CHumidity.Attributes["value"].Value.ToString();
            return CHumi;
        }
        public static string[] GetHumi()
        {
            string[] Humi = new string[5];
            XmlDocument forcast = new XmlDocument();
            forcast.Load("http://api.openweathermap.org/data/2.5/forecast/daily?q=HongKong,HK&APPID=d5893e0f95d5b904852d99527213b7cc&mode=xml");
            XmlElement froot = forcast.DocumentElement;
            for (int i = 0; i < 4; i++)
            {
                XmlNode time = froot.SelectNodes("/weatherdata/forecast/time")[i];
                {              
                    XmlNode Humidity = time.SelectSingleNode("humidity");
                    Humi[i] = Humidity.Attributes["value"].Value.ToString();
                }
            }
            return Humi;
        }
        public static string[] GetMaxTemp()
        {
            string[] MaxTemp = new string[5];
            XmlDocument forcast = new XmlDocument();
            forcast.Load("http://api.openweathermap.org/data/2.5/forecast/daily?q=HongKong,HK&APPID=d5893e0f95d5b904852d99527213b7cc&mode=xml");
            XmlElement froot = forcast.DocumentElement;
            for (int i = 0; i < 4; i++)
            {
                XmlNode time = froot.SelectNodes("/weatherdata/forecast/time")[i];
                {
                    XmlNode temperature = time.SelectSingleNode("temperature");
                    MaxTemp[i] = KToC(double.Parse(temperature.Attributes["max"].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture));
                }
            }
            return MaxTemp;
        }
        public static string[] GetMinTemp()
        {
            string[] MinTemp = new string[5];
            XmlDocument forcast = new XmlDocument();
            forcast.Load("http://api.openweathermap.org/data/2.5/forecast/daily?q=HongKong,HK&APPID=d5893e0f95d5b904852d99527213b7cc&mode=xml");
            XmlElement froot = forcast.DocumentElement;
            for (int i = 0; i < 4; i++)
            {
                XmlNode time = froot.SelectNodes("/weatherdata/forecast/time")[i];
                {
                    XmlNode temperature = time.SelectSingleNode("temperature");
                    MinTemp[i] = KToC(double.Parse(temperature.Attributes["min"].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture));
                }
            }
            return MinTemp;
        }
        public static string GetDesc()
        {
            string Desc;
            XmlDocument current = new XmlDocument();
            current.Load("http://rss.weather.gov.hk/rss/LocalWeatherForecast.xml");
            XmlElement croot = current.DocumentElement;
            XmlNode descNode = croot.SelectSingleNode("/rss/channel/item");
            Desc = descNode["description"].InnerText.Trim();
            return Desc.Replace("<br/>", "\n");
        }

        public static string GetWarning()
        {
            string Warning;
            XmlDocument current = new XmlDocument();
            current.Load("http://rss.weather.gov.hk/rss/WeatherWarningBulletin.xml");
            XmlElement croot = current.DocumentElement;
            XmlNode descNode = croot.SelectSingleNode("/rss/channel/item");
            Warning = descNode["description"].InnerText.Trim();
            return Warning.Replace("<br/>", "\n");
        }
        private static string KToC(double K)
        {
            return Math.Round((K - 273.15), 1).ToString();
        }
    }
}
        
    
