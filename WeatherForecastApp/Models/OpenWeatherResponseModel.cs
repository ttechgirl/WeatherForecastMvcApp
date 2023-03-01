﻿namespace WeatherForecastApp.Models
{
   
    public class OpenWeatherResponseModel
    {
        public int id { get; set; }
        public string? name { get; set; }   //non nullable property 
        public string? Base { get; set; }     //non nullable property 
        public long timezone { get; set; }
        public double visibility { get; set; }
        public long cod { get; set; }
        public long dt { get; set; }
        public Coordinates? coord { get; set; }
        public Weather[]? weather { get; set; }
        public Main? main { get; set; }
        public Wind? wind { get; set; }
        public Clouds? clouds { get; set; }
        public Sys? sys { get; set; }


        //classes declared as object above
        public class Coordinates
        {
            public double Longitute { get; set; }
            public double Latitude { get; set; }
        }

        public class Weather
        {
            public int id { get; set; }
            public string? main { get; set; }
            public string? description { get; set; }
            public string? icon { get; set; }

        }

        public class Main
        {
            public double temp { get; set; }
            public double feels_like { get; set; }
            public double temp_min { get; set; }
            public double pressure { get; set; }
            public double humidity { get; set; }
            public double sea_level { get; set; }
            public double grind_level { get; set; }

        }

        public class Wind
        {
            public double speed { get; set; }
            public double deg { get; set; }
            public double gust { get; set; }
        }

        public class Clouds
        {
            public double all { get; set; }
        }

        public class Sys
        {
            public string? country { get; set; }
            public long sunrise { get; set; }
            public long sunset { get; set; }

        }


    }
    

}

