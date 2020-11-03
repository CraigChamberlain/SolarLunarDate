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
                var MoonsOfYear = db.GetYear(year.ToString());
                var newMoonsToDate = MoonsOfYear.Where(
                                    x => new DateTime(x.Year,x.Month, x.Day)  <= solarDateTime
                                )
                                .OrderBy(x => x);

                var lunarMonth = newMoonsToDate.Count();

                int lunarDay;
                if (newMoonsToDate.Any())
                {
                    var dayOfNewMoon = newMoonsToDate.Last().DayOfYear;
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

