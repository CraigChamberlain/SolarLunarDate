using System.Collections.Generic;

namespace SolarLunarName.SharedTypes.Interfaces{

    public interface ISolarLunarCalendarClient: IMoonDataClient
    {   
        IList<ILunarSolarCalendarMonth> GetYearData(string year);
        ILunarSolarCalendarMonth GetMonthData(int year, int month);
    }
}