using System;
using System.Collections.Generic;
using SolarLunarName.Standard.Models;

namespace SolarLunarName.Standard.Types{

    public interface ISolarLunarCalendarClient
    {   
        List<LunarSolarCalendarMonth> GetYearData(string year);
    }
}