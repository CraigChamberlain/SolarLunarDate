using System.Collections.Generic;
using SolarLunarName.SharedTypes.Primitives;
using System;

namespace SolarLunarName.SharedTypes.Interfaces{

    public interface ISolarLunarCalendarClientDetailed : ISolarLunarCalendarClient
    {   
        // TODO Delete method in version 1.0.0
        [Obsolete("This Overload is being deprecated in version 1.0.0 cast string to ValidYear")]
        IList<ILunarSolarCalendarMonthDetailed> GetYearDataDetailed(string year);
        
        // TODO Delete method in version 1.0.0
        [Obsolete("This Overload is being deprecated in version 1.0.0 cast ints to ValidYear and ValidLunarMonth")]
        ILunarSolarCalendarMonthDetailed GetMonthDataDetailed(int year, int month);
        
        IList<ILunarSolarCalendarMonthDetailed> GetYearDataDetailed(ValidYear year);
        
        ILunarSolarCalendarMonthDetailed GetMonthDataDetailed(ValidYear year, ValidLunarMonth month);
    }
}