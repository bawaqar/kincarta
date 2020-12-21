using NUnit.Framework;
using ParkDistrict.API;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkDistrict.Fixture
{
    [TestFixture]
    public class BaseFixture
    {
        //In real project, I would keep that into config file
        private static readonly string _baseUrl = "https://data.cityofchicago.org/";
        private static readonly string _resource = "resource/k7hf-8y75.json";

        protected DataSensor_API DataSensor_API { get; private set; }
        public BaseFixture()
        {
            DataSensor_API = new DataSensor_API(_baseUrl + _resource);
        }
    }
}
