using SolarLunarName.Standard.Models;
using SolarLunarName.Standard.RestServices.Usno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static SolarLunarName.Standard.Models.Moon;
using static SolarLunarName.Standard.RestServices.Usno.UsnoApi;


namespace SolarLunarName.Standard.ApplicationServices
{
    public class GetSolarLunarName
    {
        public DateTime SolarDateTime { get; }
        public int Year { get; }
        public int LunarMonth { get; }
        public int LunarDay { get; }
        Dictionary<DateTime, MoonPhase> LunarCalendar { get; set; } = new Dictionary<DateTime, MoonPhase>();

        public override string ToString()
        { var stringFormat = string.Format("{0}-{1}-{2}", Year.ToString(), LunarMonth.ToString(), LunarDay.ToString()) ;
            return stringFormat;
        }
        public GetSolarLunarName(DateTime solarDateTime) {

            SolarDateTime = solarDateTime;
            Year = solarDateTime.Year;

            FormMoonPhaseCalendar();

            var newMoons = LunarCalendar
                            .Where(
                                x => x.Value == MoonPhase.NewMoon 
                                && x.Key < SolarDateTime
                            )
                            .OrderBy(x => x.Key);

            LunarMonth = newMoons.Count();

            if (newMoons.Any())
            {
                var dayOfNewMoon = newMoons.Last().Key.DayOfYear;
                LunarDay = SolarDateTime.DayOfYear - dayOfNewMoon;
            }
            else
            {
                LunarDay = SolarDateTime.DayOfYear;
            }



        }

        

        private void FormMoonPhaseCalendar() {

            var Usno = new UsnoApi();
            var response = Usno.GetMoonPhaseCalendar(Year.ToString());
            
            var MonthList = new Dictionary<string, int>() {

                { "Jan" , 1},
                { "Feb" , 2},
                { "Mar" , 3},
                { "Apr" , 4},
                { "May" , 5},
                { "Jun" , 6},
                { "Jul" , 7},
                { "Aug" , 8},
                { "Sep" , 9},
                { "Oct" , 10},
                { "Nov" , 11},
                { "Dec" , 12}

            };
            foreach (PhaseDataResponse value in response.PhaseData) {
                //Example Date "date": "2018 Jan 08",
                var dateParts = value.Date.Split(' ');
                int year = int.Parse(dateParts[0]);
                int month = MonthList[(dateParts[1])];
                int day = int.Parse(dateParts[2]);


                //Example Time "time": "22:25"
                var timeParts = value.Time.Split(':');
                int hour = int.Parse(timeParts[0]);
                int minute = int.Parse(timeParts[1]);
                int second = 0;
                var date = new DateTime(year, month, day, hour, minute, second, DateTimeKind.Utc);
                string phaseString = value.Phase.Replace(" ", "");
                Enum.TryParse(phaseString, out MoonPhase phase);

                LunarCalendar.Add(date, phase);

            }



        }




    }
}
