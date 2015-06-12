using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherFX;

namespace WeatherFXtest
{
    class Program
    {
        static void Main(string[] args)
        {
            var weather = new WeatherFX.Weather().GetWeather(60192);
            Console.WriteLine(String.Format("The weather in {0}({1}) is {2} degrees and {3}!", weather.Location, weather.Zip, weather.Temp, weather.Desc));
            
            Console.ReadLine();
        }
    }
}
