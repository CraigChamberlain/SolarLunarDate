using System;
using System.Collections.Generic;
using SolarLunarName.Standard.Models;

namespace SolarLunarName.Standard.Types{

    public interface ISolarLunarCalendarClient: IMoonDataClient
    {   
        IList<ILunarSolarCalendarMonth> GetYearData(string year);
        ILunarSolarCalendarMonth GetMonthData(int year, int month);
    }
}