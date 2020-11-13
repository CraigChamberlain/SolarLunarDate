using System.Collections.Generic;
using SolarLunarName.SharedTypes.Primitives;
using System;

namespace SolarLunarName.SharedTypes.Interfaces{

    public interface ISolarLunarCalendarClient: IMoonDataClient
    {   

        // TODO Delete method in version 1.0.0
        [Obsolete("This Overload is being deprecated in version 1.0.0 cast string to ValidYear")]
        IList<ILunarSolarCalendarMonth> GetYearData(string year);
        
        // TODO Delete method in version 1.0.0
        [Obsolete("This Overload is being deprecated in version 1.0.0 cast ints to ValidYear and ValidLunarMonth")]
        ILunarSolarCalendarMonth GetMonthData(int year, int month); 
        
        IList<ILunarSolarCalendarMonth> GetYearData(ValidYear year);
        
        ILunarSolarCalendarMonth GetMonthData(ValidYear year, ValidLunarMonth month);

    }
}