//"Date":"1700-01-01T00:00:00","Days":19

using System;
using SolarLunarName.Standard.Types;

namespace SolarLunarName.Standard.Models
{
    public class LunarSolarCalendarMonth : ILunarSolarCalendarMonth
    {
        public LunarSolarCalendarMonth(int days, DateTime date){
            Days = days;
            FirstDay = date;
        }
        public int Days { get; set; }

        public DateTime FirstDay { get; set;}
    }
}