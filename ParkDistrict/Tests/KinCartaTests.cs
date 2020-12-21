using NUnit.Framework;
using ParkDistrict.Fixture;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ParkDistrict.Tests
{
    public class KinCartaTests : BaseFixture
    {
        [TestCase("Oak Street Weather Station", Description = "API lists all the measurements", TestName = "1-API returns only requested station info", Category = "Positive")]
        // this is a data driven.. we can add as many as we want to . for example add one more Foster Weather Station w/o much writing any code
        [TestCase("Foster Weather Station", Description = "API lists all the measurements", TestName = "2-API returns only requested station info", Category = "Positive")]
        public async Task GetMeasurements(string stationName)
        {
            var stations = await DataSensor_API.GetSensorData($"?$where=station_name=\"{stationName}\"");

            //Verify only corresponded statations display
            foreach (var station in stations)
            {
                System.Console.WriteLine($"the station name for current element is {station.StationName}");
                StringAssert.AreEqualIgnoringCase(stationName, station.StationName);
            }
        }






        [TestCase("63rd Street Weather Station", Description = "API lists all the measurements", TestName = "Pagination Test", Category = "Positive")]
        public async Task TestPagination(string stationName)
        {
           
            var firstPageResults = await DataSensor_API.GetSensorData($"?$limit=10&$offset=0&$where=station_name=\"{stationName}\"");
            var SecondPageResults = await DataSensor_API.GetSensorData($"?$limit=10&$offset=10&$where=station_name=\"{stationName}\"");
           
            //Verify Only 10 records are retrieved 
            Assert.AreEqual(10, firstPageResults.Count);
            Assert.AreEqual(10, SecondPageResults.Count);
            
            //Make sure recors are not repeated from Page one to Page two
            var p1_measure_ts = firstPageResults.Select(a => a.MeasurementTimestamp).ToList();
            var p2_measure_ts = SecondPageResults.Select(a => a.MeasurementTimestamp).ToList();
            
            // as long as the field measurement_timestamp from one page do not another page do not intersect. we got the right data
            Assert.IsFalse(p1_measure_ts.Intersect(p2_measure_ts).Count() == p2_measure_ts.Count);

          
        }

        [TestCase("63rd Street Weather Station", Description = "API returns Malformed compiler message when malformed query is sent ", TestName = "Exception Test", Category = "Negative")]
        public async Task TestException(string stationName)
        {

            var filter = $"?$where=station_name=\"{stationName}\"&battery_life=%3Efull";          
            dynamic data = JObject.Parse(await DataSensor_API.GetResponse(filter));
            string errorCode = data.code;
            string message = data.message;
            StringAssert.AreEqualIgnoringCase("query.compiler.malformed", errorCode);
            StringAssert.Contains("Could not parse SoQL query", message);

        }
    }
}