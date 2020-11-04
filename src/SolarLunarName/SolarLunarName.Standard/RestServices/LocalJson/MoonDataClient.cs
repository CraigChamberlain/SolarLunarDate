using System;
using System.Collections.Generic;
using SolarLunarName.SharedTypes.Interfaces;
using System.IO;

namespace SolarLunarName.Standard.RestServices.LocalJson
{

    public class MoonDataClient : IMoonDataClient
    {

        public MoonDataClient(string basePath)
        {
            Helpers.TestPath(basePath);
            _basePath = basePath;
        }

        private string _basePath;
        public IList<DateTime> GetYear(string year)
        {
            SolarLunarName.SharedTypes.Validation.Helpers.ValidateYear(year);
            string path = Path.Combine(_basePath, year, "index.json");

            return Helpers.Deserialize<List<DateTime>>(path);
        }

    }
}
