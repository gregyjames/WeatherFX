# WeatherFX
A .Net library for recovering weather information portraying to a specific location. Using WebRequests, Google FeedtoJson Api, The Weather Channel API, and Newtonsoft Json Convertor.

###Usage
var weather = new WeatherFX.Weather().GetWeather(60192);

###Important Notes
1) Be sure to copy the newtonsoft json dll to output or this library WILL NOT work.
