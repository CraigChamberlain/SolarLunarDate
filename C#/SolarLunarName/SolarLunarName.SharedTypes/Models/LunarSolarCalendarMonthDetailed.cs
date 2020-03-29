using System;
using System.Collections.Generic;
using SolarLunarName.SharedTypes.Interfaces;

namespace SolarLunarName.SharedTypes.Models
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
