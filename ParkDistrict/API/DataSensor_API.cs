using Newtonsoft.Json;
using ParkDistrict.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParkDistrict.API
{
    public class DataSensor_API : IDataSensor
    {
        private string BaseUrl { get; set; }
        private RestClient _client;
        private IRestResponse _response { get; set; }
        public DataSensor_API(string baseURL)
        {
            BaseUrl = baseURL ?? throw new ArgumentNullException(nameof(baseURL));
            _client = new RestClient(BaseUrl)
            {
                Timeout = -1
            };
        }
        public async Task<IList<SensorData>> GetSensorData()
        {
            RestRequest request = new RestRequest(Method.GET);
            await Console.Out.WriteLineAsync($" A call is made to {BaseUrl} to get all Data Center");

            try
            {
                _response = await _client.ExecuteGetAsync(request);
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException.ToString());
            }
            if (!_response.StatusCode.Equals(HttpStatusCode.OK))
            {
                await Console.Out.WriteLineAsync($"response status {_response.StatusCode}");
                await Console.Out.WriteLineAsync($"response.StatusDescription {_response.StatusDescription}");
                await Console.Out.WriteLineAsync($"response.Content {_response.Content}");

                return null;
            }
            return JsonConvert.DeserializeObject<IList<SensorData>>(_response.Content);
        }

        public async Task<IList<SensorData>> GetSensorData(string filter)
        {
          
            _client.BaseUrl = new Uri(BaseUrl + filter);
            RestRequest request = new RestRequest(Method.GET);
            await Console.Out.WriteLineAsync($" A call is made to {BaseUrl} with filters{filter} to get all Data Center");
            try
            {
                _response = await _client.ExecuteGetAsync(request);
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException.ToString());
            }
            if (!_response.StatusCode.Equals(HttpStatusCode.OK))
            {
                await Console.Out.WriteLineAsync($"response status {_response.StatusCode}");
                await Console.Out.WriteLineAsync($"response.StatusDescription {_response.StatusDescription}");
                await Console.Out.WriteLineAsync($"response.Content {_response.Content}");

                return null;
            }
            return JsonConvert.DeserializeObject<IList<SensorData>>(_response.Content);

        }

        public async Task<string> GetResponse(string filter)
        {
            _client.BaseUrl = new Uri(BaseUrl + filter);
            RestRequest request = new RestRequest(Method.GET);
            await Console.Out.WriteLineAsync($" A call is made to {BaseUrl} with filters{filter} to get all Data Center");
            try
            {
                _response = await _client.ExecuteGetAsync(request);
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException.ToString());
            }
            return _response.Content;
        }
    }
}
