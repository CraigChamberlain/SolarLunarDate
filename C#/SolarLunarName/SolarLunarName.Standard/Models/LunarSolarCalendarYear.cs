//"Date":"1700-01-01T00:00:00","Days":19

using System;

namespace SolarLunarName.Standard.Models
{
    public class LunarSolarCalendarMonth
    {
        public LunarSolarCalendarMonth(int days, DateTime date){
            Days = days;
            Date = date;
        }
        public int Days { get; set; }

        public DateTime Date { get; set;}
    }
}