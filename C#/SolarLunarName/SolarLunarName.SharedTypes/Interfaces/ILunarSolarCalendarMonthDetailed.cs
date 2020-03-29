using System.Collections.Generic;
using SolarLunarName.SharedTypes.Models;

namespace SolarLunarName.SharedTypes.Interfaces
{
    public interface ILunarSolarCalendarMonthDetailed : ILunarSolarCalendarMonth
    {
        int Month { get; set; }
        IList<MoonPhaseEntity> Phases { get; set; }
    }
}