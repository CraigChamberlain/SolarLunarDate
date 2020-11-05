using System.Collections.Generic;
using SolarLunarName.SharedTypes.Interfaces;
using System.IO;

namespace SolarLunarName.Standard.RestServices.LocalJson
{
    public class LunarCalendarClientDetailed : LunarCalendarClient, ISolarLunarCalendarClientDetailed
    {
        public LunarCalendarClientDetailed(string basePath) : base(basePath)
        {
        }

        public IList<ILunarSolarCalendarMonthDetailed> GetYearDataDetailed(string year)
        {


            string path = Helpers.CombinePath(base._basePath, year);
            using (Stream s = File.OpenRead(path))
            {
                return base.GetYearDataDetailed(year, s);
            }


        }

        public ILunarSolarCalendarMonthDetailed GetMonthDataDetailed(int year, int month)
        {
            string path = Helpers.CombinePath(base._basePath, year.ToString(), month.ToString());
            using (Stream s = File.OpenRead(path))
            {
                return base.GetMonthDataDetailed(year, month, s);
            }

        }

    }
}
