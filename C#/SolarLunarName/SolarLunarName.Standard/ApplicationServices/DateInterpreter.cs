using SolarLunarName.Standard.Models;
using System;
using System.Linq;
using SolarLunarName.Standard.RestServices.LocalJson;

namespace SolarLunarName.Standard.ApplicationServices
{
    public partial class DateInterpreter
    {

        public Models.SolarLunarName GetSolarLunarName(DateTime solarDateTime)
        {

            var year = solarDateTime.Year;
            var startOfYear = new DateTime(year, 1, 1);
            var db = new MoonDataClient();
                
            string path = @"./assets/moon-data/"+ year+".json";

            var newMoons = db.GetYear(path).Where(
                                x => x.Date > startOfYear
                                && x.Date < solarDateTime
                                && x.Phase == Moon.MoonPhase.NewMoon

                            )
                            .OrderBy(x => x.Date);

            var lunarMonth = newMoons.Count();

            int lunarDay;
            if (newMoons.Any())
            {
                var dayOfNewMoon = newMoons.Last().Date.DayOfYear;
                lunarDay = solarDateTime.DayOfYear - dayOfNewMoon;
            }
            else
            {
                lunarDay = solarDateTime.DayOfYear;
            }

            return new Models.SolarLunarName(solarDateTime, year, lunarMonth, lunarDay);

            
        }


    
        public Models.SolarLunarName GetRemoteSolarLunarName(DateTime solarDateTime)
            {

                var year = solarDateTime.Year;
                var startOfYear = new DateTime(year, 1, 1);
                var db = new RestServices.RemoteJson.RemoteMoonDataClient();

                var newMoons = db.GetYear(year.ToString()).Where(
                                    x => x < solarDateTime
                                )
                                .OrderBy(x => x);

                var lunarMonth = newMoons.Count();

                int lunarDay;
                if (newMoons.Any())
                {
                    var dayOfNewMoon = newMoons.Last().DayOfYear;
                    lunarDay = solarDateTime.DayOfYear - dayOfNewMoon;
                }
                else
                {
                    lunarDay = solarDateTime.DayOfYear;
                }

                return new Models.SolarLunarName(solarDateTime, year, lunarMonth, lunarDay);

                
            }


    }
    
}

