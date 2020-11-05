using System.Collections.Generic;
using SolarLunarName.SharedTypes.Interfaces;
using SolarLunarName.SharedTypes.Primitives;
using System.IO;

namespace SolarLunarName.Standard.RestServices.LocalJson
{
    public class LunarCalendarClientDetailed : LunarCalendarClient, ISolarLunarCalendarClientDetailed
    {
        public LunarCalendarClientDetailed(string basePath) : base(basePath)
        {
        }

        public IList<ILunarSolarCalendarMonthDetailed> GetYearDataDetailed(ValidYear year)
        {


            string path = Helpers.CombinePath(base._basePath, year);
            using (Stream s = File.OpenRead(path))
            {
                return base.GetYearDataDetailed(year, s);
            }


        }

        public ILunarSolarCalendarMonthDetailed GetMonthDataDetailed(ValidYear year, ValidLunarMonth month)
        {
            string path = Helpers.CombinePath(base._basePath, year, month);
            using (Stream s = File.OpenRead(path))
            {
                return base.GetMonthDataDetailed(year, month, s);
            }

        }
        public IList<ILunarSolarCalendarMonthDetailed> GetYearDataDetailed(string year)
        {
            return GetYearDataDetailed((ValidYear)year);
        }

        public ILunarSolarCalendarMonthDetailed GetMonthDataDetailed(int year, int month)
        {
            return GetMonthDataDetailed((ValidYear)year, (ValidLunarMonth)month);
        }

    }
}
