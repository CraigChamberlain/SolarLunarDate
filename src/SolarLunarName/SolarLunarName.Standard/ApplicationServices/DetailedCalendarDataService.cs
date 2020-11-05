using SolarLunarName.SharedTypes.Interfaces;
using System.Collections.Generic;


namespace SolarLunarName.Standard.ApplicationServices
{
    public class DetailedCalendarDataService : CalendarDataService
    {   

       private new ISolarLunarCalendarClientDetailed db;

        public DetailedCalendarDataService(ISolarLunarCalendarClientDetailed calendarClient) : base(calendarClient)
        {
            db = calendarClient;

        }

        public IList<ILunarSolarCalendarMonthDetailed> GetDetailedSolarLunarYear(int year)
        {       
                return db.GetYearDataDetailed(year);

        }

        public ILunarSolarCalendarMonthDetailed GetDetailedSolarLunarMonth(int year, int month)
        {                
                return  db.GetMonthDataDetailed(year, month);

        }


    }
    
}

