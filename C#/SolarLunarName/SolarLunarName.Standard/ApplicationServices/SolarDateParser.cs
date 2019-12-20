using SolarLunarName.Standard.Models;
using System;
using System.Linq;
using SolarLunarName.Standard.RestServices.LocalJson;

namespace SolarLunarName.Standard.ApplicationServices
{
    public class SolarDateParser
    {

        public DateTime ConvertSolarLunarName(int year, int month, int day)
        {

            var startOfYear = new DateTime(year, 1, 1);
            var db = new MoonDataClient();
                
            string path = @"./assets/moon-data/"+ year+".json";

            DateTime newMoon = db.GetYear(path).Where(
                                x => x.Date.Year == year
                                && x.Phase == Moon.MoonPhase.NewMoon

                            )
                            .OrderBy(x => x.Date)
                            .Where((_, index) => index == month )
                            .Select(x => x.Date )
                            .First();

            var solarDateTime = newMoon.AddDays(day - 1);

            return new DateTime(solarDateTime.Year, solarDateTime.Month, solarDateTime.Day);

            
        }


    }
}

