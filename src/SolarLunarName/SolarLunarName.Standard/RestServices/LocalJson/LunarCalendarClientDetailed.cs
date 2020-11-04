using System.Collections.Generic;
using System.Linq;
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

            return Helpers.Deserialize<List<LunarSolarCalendarMonthDetailed>>(path)
                .Select(month => (ILunarSolarCalendarMonthDetailed)month)
                .ToList();
            

        }

        public ILunarSolarCalendarMonthDetailed GetMonthDataDetailed(int year, int month)
        {

            SolarLunarName.SharedTypes.Validation.Helpers.ValidateYear(year);
            SolarLunarName.SharedTypes.Validation.Helpers.ValidateLunarMonth(month);

            string path = System.IO.Path.Combine(_basePath, year.ToString(), month.ToString(), "index.json");

            return Helpers.Deserialize<LunarSolarCalendarMonthDetailed>(path);

        }

    }
}
