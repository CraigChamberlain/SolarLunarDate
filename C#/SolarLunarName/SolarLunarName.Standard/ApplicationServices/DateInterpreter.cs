using SolarLunarName.Standard.Models;
using System;
using System.Linq;
using static SolarLunarName.Standard.Models.Moon;
using SQLite;

namespace SolarLunarName.Standard.ApplicationServices
{
    public class GetSolarLunarName
    {
        public DateTime SolarDateTime { get; }
        public int Year { get; }
        public int LunarMonth { get; }
        public int LunarDay { get; }

        public override string ToString()
        {
            var stringFormat = string.Format("{0}-{1}-{2}", Year.ToString(), LunarMonth.ToString(), LunarDay.ToString());
            return stringFormat;
        }
        public GetSolarLunarName(DateTime solarDateTime, string database)
        {

            SolarDateTime = solarDateTime;
            Year = solarDateTime.Year;
            var startOfYear = new DateTime(Year, 1, 1);
            var db = new SQLiteConnection(database);

            var newMoons = db.Table<MoonPhaseEntity>().Where(
                                x => x.Date > startOfYear
                                && x.Date < SolarDateTime
                                &&  x.Phase == MoonPhase.NewMoon

                            )
                            .OrderBy(x => x.Date);

            LunarMonth = newMoons.Count();

            if (newMoons.Any())
            {
                var dayOfNewMoon = newMoons.Last().Date.DayOfYear;
                LunarDay = SolarDateTime.DayOfYear - dayOfNewMoon;
            }
            else
            {
                LunarDay = SolarDateTime.DayOfYear;
            }



        }


    }
}
