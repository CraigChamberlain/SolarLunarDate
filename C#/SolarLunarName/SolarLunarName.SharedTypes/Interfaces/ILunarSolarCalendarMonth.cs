using System;

namespace SolarLunarName.SharedTypes.Interfaces
{
    public interface ILunarSolarCalendarMonth
    {
        int Days { get; set; }

        DateTime FirstDay { get; set;}
    }
}