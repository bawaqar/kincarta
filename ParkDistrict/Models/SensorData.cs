using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkDistrict.Models
{
    public partial class SensorData
    {
        [JsonProperty("station_name")]
        public string StationName { get; set; }

        [JsonProperty("measurement_timestamp")]
        public DateTimeOffset MeasurementTimestamp { get; set; }

        [JsonProperty("air_temperature")]
        public string AirTemperature { get; set; }

        [JsonProperty("humidity")]
     
        public string Humidity { get; set; }

        [JsonProperty("interval_rain")]
        
        public string IntervalRain { get; set; }

        [JsonProperty("wind_direction")]

        public string WindDirection { get; set; }

        [JsonProperty("wind_speed")]
        public string WindSpeed { get; set; }

        [JsonProperty("maximum_wind_speed")]
        
        public string MaximumWindSpeed { get; set; }

        [JsonProperty("barometric_pressure")]
        public string BarometricPressure { get; set; }

        [JsonProperty("solar_radiation")]
     
        public string SolarRadiation { get; set; }

        [JsonProperty("battery_life")]
        public string BatteryLife { get; set; }

        [JsonProperty("measurement_timestamp_label")]
        public string MeasurementTimestampLabel { get; set; }

        [JsonProperty("measurement_id")]
        public string MeasurementId { get; set; }
    }
}
