using System.Collections.Generic;
using SolarLunarName.SharedTypes.Interfaces;
using SolarLunarName.SharedTypes.Primitives;
using System.IO;
using System;
using System.Net.Http;

namespace SolarLunarName.Standard.RestServices.RemoteJson
{
    public class LunarCalendarClientDetailed : LunarCalendarClient, ISolarLunarCalendarClientDetailed
    {

        // TODO URI should not be in the compiled code.  
        // Need in a json file
        public LunarCalendarClientDetailed(HttpClient client, string baseUrl = "https://craigchamberlain.github.io/moon-data/api/lunar-solar-calendar-detailed/") : base(client, baseUrl)
        {
        }

        public IList<ILunarSolarCalendarMonthDetailed> GetYearDataDetailed(ValidYear year)
        {


            Uri uri = Helpers.CombinePath(_baseUrl, year);
            using (Stream s = _client.GetStreamAsync(uri).Result)
            {
                return base.GetYearDataDetailed(year, s);
            }


        }

        public ILunarSolarCalendarMonthDetailed GetMonthDataDetailed(ValidYear year, ValidLunarMonth month)
        {   
            Uri uri = Helpers.CombinePath(_baseUrl, year, month);
            using (Stream s = _client.GetStreamAsync(uri).Result)
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
