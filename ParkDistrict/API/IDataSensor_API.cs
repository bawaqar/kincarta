using ParkDistrict.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParkDistrict.API
{
    public interface IDataSensor
    {
        Task<IList<SensorData>> GetSensorData();
        Task<IList<SensorData>> GetSensorData(string filter);
        Task<string> GetResponse(string filter);
    }
}
