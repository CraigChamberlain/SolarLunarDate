//"Date":"1700-01-01T00:00:00","Days":19

using System;
using System.Collections.Generic;
using SolarLunarName.Standard.Models;

namespace SolarLunarName.Standard.Types
{
    public interface ILunarSolarCalendarMonthDetailed : ILunarSolarCalendarMonth
    {
        int Month { get; set; }
        List<Moon.MoonPhase> Phases { get; set; }
    }
}