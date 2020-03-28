//"Date":"1700-01-01T00:00:00","Days":19

using System;
using System.Collections.Generic;
using SolarLunarName.Standard.Types;

namespace SolarLunarName.Standard.Models
{
    public class LunarSolarCalendarMonthDetailed : ILunarSolarCalendarMonth, ILunarSolarCalendarMonthDetailed
    {
        public LunarSolarCalendarMonthDetailed(int days, int month, DateTime firstDay, IList<MoonPhaseEntity> phases)
        {
            Days = days;
            Month = month;
            FirstDay = firstDay;
            Phases = phases; 
        }

        public int Days { get; set; }
        public int Month { get; set; }
        public DateTime FirstDay { get; set; }
        public IList<MoonPhaseEntity> Phases { get; set; }
    }
}
