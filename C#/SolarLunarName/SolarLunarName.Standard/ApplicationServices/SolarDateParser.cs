using SolarLunarName.Standard.Models;
using System;
using System.Linq;
using SolarLunarName.Standard.RestServices.LocalJson;
using SolarLunarName.Standard.RestServices.RemoteJson;
using SolarLunarName.Standard.Types;

namespace SolarLunarName.Standard.ApplicationServices
{
    public class SolarDateParser
    {
        public SolarDateParser(ISolarLunarCalendarClient calendarClient){
            db = calendarClient;

        }
        private ISolarLunarCalendarClient db;
      
        public DateTime ConvertSolarLunarName(int year, int month, int day)
        {

            var startOfYear = new DateTime(year, 1, 1);
                        
            DateTime newMoon = db.GetYearData(year.ToString())
                            .OrderBy(x => x.Date)
                            .Where((_, index) => index == month )
                            .Select( x => x.Date)
                            .First();

            var solarDateTime = newMoon.AddDays(day - 1);

            return new DateTime(solarDateTime.Year, solarDateTime.Month, solarDateTime.Day);

            
        }


    }
}

