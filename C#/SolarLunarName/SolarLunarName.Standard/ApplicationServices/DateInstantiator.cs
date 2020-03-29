using System;
using System.Linq;
using SolarLunarName.SharedTypes.Interfaces;
using SolarLunarName.SharedTypes.Models;

namespace SolarLunarName.Standard.ApplicationServices
{
    public class DateInstantiator
    {
        public DateInstantiator(IMoonDataClient calendarClient){
            db = calendarClient;

        }
        private IMoonDataClient db;

        public SolarLunarNameModel GetSolarLunarName(DateTime solarDateTime)
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

                return new SolarLunarNameModel(solarDateTime, year, lunarMonth, lunarDay);

                
            }


    }
    
}

