using SolarLunarName.Standard.Models;
using System;
using System.Linq;
using SolarLunarName.Standard.RestServices.LocalJson;
using SolarLunarName.Standard.Types;

namespace SolarLunarName.Standard.ApplicationServices
{
    public class DateInstantiator
    {
        public DateInstantiator(IMoonDataClient calendarClient){
            db = calendarClient;

        }
        private IMoonDataClient db;

        public Models.SolarLunarName GetSolarLunarName(DateTime solarDateTime)
            {

                var year = solarDateTime.Year;
                var startOfYear = new DateTime(year, 1, 1);
               
                var newMoons = db.GetYear(year.ToString()).Where(
                                    x => x < solarDateTime
                                )
                                .OrderBy(x => x);

                var lunarMonth = newMoons.Count();

                int lunarDay;
                if (newMoons.Any())
                {
                    var dayOfNewMoon = newMoons.Last().DayOfYear;
                    lunarDay = solarDateTime.DayOfYear - dayOfNewMoon + 1;
                }
                else
                {
                    lunarDay = solarDateTime.DayOfYear;
                }

                return new Models.SolarLunarName(solarDateTime, year, lunarMonth, lunarDay);

                
            }


    }
    
}

