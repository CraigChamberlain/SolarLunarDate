using SolarLunarName.Standard.Models;
using SolarLunarName.Standard.RestServices.Usno;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using static SolarLunarName.Standard.Models.Moon;
using static SolarLunarName.Standard.RestServices.Usno.UsnoApi;

namespace SolarLunarName.CLI
{
    public class DataAccess
    {
        public SQLiteConnection db { get; set; }

        public DataAccess() {

            db = new SQLiteConnection("MoonPhase.sqlite");
            db.CreateTable<MoonPhaseEntity>();

        }

        void AddPhase(SQLiteConnection db, Moon.MoonPhase phase, DateTime date)
        {
            var Id = db.Insert(new MoonPhaseEntity()
            {
                Phase = phase,
                Date = date
            });
            Console.WriteLine("{0}", Id);
        }

               
        public void PopulateYear(string yearString)
        {

            var Usno = new UsnoApi();
            var response = Usno.GetMoonPhaseCalendar(yearString);

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
            foreach (PhaseDataResponse value in response.PhaseData)
            {
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

                AddPhase(this.db, phase, date);

            }



        }
    }
}
