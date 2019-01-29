using SolarLunarName.Standard.Models;
using System;
using System.Linq;
using static SolarLunarName.Standard.Models.Moon;
using SQLite;
using System.Threading.Tasks;

namespace SolarLunarName.Standard.ApplicationServices
{
    public class DateInterpreter
    {

        public Models.SolarLunarName GetSolarLunarName(DateTime solarDateTime, string database)
        {

            var year = solarDateTime.Year;
            var startOfYear = new DateTime(year, 1, 1);
            using (var db = new SQLiteConnection(database))
            {

                var newMoons = db.Table<MoonPhaseEntity>().Where(
                                    x => x.Date > startOfYear
                                    && x.Date < solarDateTime
                                    && x.Phase == MoonPhase.NewMoon

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
        }






        public async Task<Models.SolarLunarName> GetSolarLunarNameAsync(DateTime solarDateTime, string database)
        {

            var year = solarDateTime.Year;
            var startOfYear = new DateTime(year, 1, 1);
            var db = new SQLiteAsyncConnection(database);
            

                var query = db.Table<MoonPhaseEntity>().Where(
                                    x => x.Date > startOfYear
                                    && x.Date < solarDateTime
                                    && x.Phase == MoonPhase.NewMoon

                                )
                                .OrderBy(x => x.Date);

                var newMoons = await query.ToListAsync();

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




    }
}

