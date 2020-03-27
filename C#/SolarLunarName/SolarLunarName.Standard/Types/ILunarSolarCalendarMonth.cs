//"Date":"1700-01-01T00:00:00","Days":19

using System;

namespace SolarLunarName.Standard.Types
{
    public interface ILunarSolarCalendarMonth
    {
        int Days { get; set; }

        DateTime FirstDay { get; set;}
    }
}