//"Date":"1700-01-01T00:00:00","Days":19

using System;
using System.Collections.Generic;
using SolarLunarName.Standard.Types;

namespace SolarLunarName.Standard.Models
{
    public class LunarSolarCalendarMonthDetailed : ILunarSolarCalendarMonth
    {
        public int Days { get; set; }
        public int Month { get; set; }
        public DateTime FirstDay { get; set; }
        public List<Moon.MoonPhase> Phases { get; set; }
    }
}
