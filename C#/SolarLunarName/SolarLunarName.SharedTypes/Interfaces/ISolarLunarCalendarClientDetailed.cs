using System.Collections.Generic;

namespace SolarLunarName.SharedTypes.Interfaces{

    public interface ISolarLunarCalendarClientDetailed : ISolarLunarCalendarClient
    {    
        IList<ILunarSolarCalendarMonthDetailed> GetYearDataDetailed(string year);
        ILunarSolarCalendarMonthDetailed GetMonthDataDetailed(int year, int month);
    }
}