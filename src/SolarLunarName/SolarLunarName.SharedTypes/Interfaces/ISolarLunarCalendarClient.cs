using System.Collections.Generic;
using SolarLunarName.SharedTypes.Primitives;

namespace SolarLunarName.SharedTypes.Interfaces{

    public interface ISolarLunarCalendarClient: IMoonDataClient
    {   
        //N.B Must write warning in compiler and release major version if remove string version of method
        IList<ILunarSolarCalendarMonth> GetYearData(ValidYear year);
        ILunarSolarCalendarMonth GetMonthData(ValidYear year, ValidLunarMonth month);
        IList<ILunarSolarCalendarMonth> GetYearData(string year);
        ILunarSolarCalendarMonth GetMonthData(int year, int month); 
    }
}