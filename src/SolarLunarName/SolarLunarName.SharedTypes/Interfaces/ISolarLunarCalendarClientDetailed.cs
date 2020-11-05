using System.Collections.Generic;
using SolarLunarName.SharedTypes.Primitives;

namespace SolarLunarName.SharedTypes.Interfaces{

    public interface ISolarLunarCalendarClientDetailed : ISolarLunarCalendarClient
    {   
        //N.B Must write warning in compiler and release major version if remove string version of method
        IList<ILunarSolarCalendarMonthDetailed> GetYearDataDetailed(string year);
        ILunarSolarCalendarMonthDetailed GetMonthDataDetailed(int year, int month);
        IList<ILunarSolarCalendarMonthDetailed> GetYearDataDetailed(ValidYear year);
        ILunarSolarCalendarMonthDetailed GetMonthDataDetailed(ValidYear year, ValidLunarMonth month);
    }
}