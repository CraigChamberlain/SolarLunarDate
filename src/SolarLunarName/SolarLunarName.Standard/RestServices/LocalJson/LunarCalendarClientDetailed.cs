using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using SolarLunarName.SharedTypes.Models;
using SolarLunarName.SharedTypes.Interfaces;
using System.IO;

namespace SolarLunarName.Standard.RestServices.LocalJson
{


    public class LunarCalendarClientDetailed : LunarCalendarClient, ISolarLunarCalendarClientDetailed
    {
        public LunarCalendarClientDetailed(string basePath) : base(basePath)
        {
            base._basePath = basePath;
        }

        public IList<ILunarSolarCalendarMonthDetailed> GetYearDataDetailed(string year)
        {
            SolarLunarName.SharedTypes.Validation.Helpers.ValidateLunarMonth(year);

            string path = Path.Combine(_basePath, year, "index.json");

            using (Stream s = File.OpenRead(path))
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                JsonSerializer serializer = new JsonSerializer();
                var yearData = serializer.Deserialize<List<LunarSolarCalendarMonthDetailed>>(reader)
                        .Select(month => (ILunarSolarCalendarMonthDetailed)month)
                        .ToList();

                return yearData;
            }

        }

        public ILunarSolarCalendarMonthDetailed GetMonthDataDetailed(int year, int month)
        {

            SolarLunarName.SharedTypes.Validation.Helpers.ValidateYear(year);
            SolarLunarName.SharedTypes.Validation.Helpers.ValidateLunarMonth(month);

            string path = System.IO.Path.Combine(_basePath, year.ToString(), month.ToString(), "index.json");

            using (Stream s = File.OpenRead(path))
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                JsonSerializer serializer = new JsonSerializer();
                return serializer.Deserialize<LunarSolarCalendarMonthDetailed>(reader);

            }

        }

    }
}
