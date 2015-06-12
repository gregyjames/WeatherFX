using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Threading;

namespace WeatherFX
{
    public class Weather
    {
        public Weather() { }

        public Weather(int zip, int temp, string desc, string location)
        {
            Zip = zip;
            Temp = temp;
            Desc = desc;
            Location = location;
        }

        // Properties. 
        public int Zip { get; set; }
        public int Temp { get; set; }
        public string Desc { get; set; }
        public string Location { get; set; }

        public Weather GetWeather(int zip)
        {
            try
            {
                WebClient wc = new WebClient();
                var data = "";

                var url = "http://ajax.googleapis.com/ajax/services/feed/load?v=1.0&num=" + 1 + "&output=json&q=" + "http://wxdata.weather.com/wxdata/weather/rss/local/" + zip + "?cm_ven=LWO&cm_cat=rss";
                
                var ReturnedWeather = new Weather();
                data = wc.DownloadString(url);

                var WeatherResponceObj = JsonConvert.DeserializeObject<WeatherResponce>(data);

                var ParsedWeatherData = WebUtility.HtmlDecode(WeatherResponceObj.responseData.feed.entries[0].content.ToString());
                ParsedWeatherData = Regex.Replace(ParsedWeatherData, @"<[^>]+>|&nbsp;", "").Trim();
                
                var Description = Regex.Match(ParsedWeatherData, @"\S+(?=,)").ToString();
                var Temperature = Convert.ToInt32(Regex.Match(ParsedWeatherData, @"[0-9][0-9]").ToString());
                
                var Location = WeatherResponceObj.responseData.feed.entries[0].title.ToString().ToString();
                var LocoArray = Location.Split(' ');
                var LocoString = "";
                for (int i = 4; i < LocoArray.Length - 1; i++)
                {
                    LocoString += LocoArray[i] + " ";
                }

                ReturnedWeather = new Weather(zip, Temperature, Description, LocoString);

                return ReturnedWeather;
            }
            catch
            {
                Console.WriteLine("Error getting weather!");
                Weather errorWeather = new Weather(0, 0, "", "");
                return errorWeather;
            }
            }

            
        }
    }
