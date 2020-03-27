using System;
using System.Collections.Generic;
using SolarLunarName.Standard.Models;

namespace SolarLunarName.Standard.Types{

    public interface ISolarLunarCalendarClientDetailed : ISolarLunarCalendarClient
    {    
        IList<ILunarSolarCalendarMonthDetailed> GetYearDataDetailed(string year);
    }
}