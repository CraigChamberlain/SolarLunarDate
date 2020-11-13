using SolarLunarName.SharedTypes.Interfaces;
using SolarLunarName.SharedTypes.Primitives;
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
                return db.GetYearDataDetailed((ValidYear)year);

        }

        public ILunarSolarCalendarMonthDetailed GetDetailedSolarLunarMonth(int year, int month)
        {                
                return  db.GetMonthDataDetailed((ValidYear)year, (ValidLunarMonth)month);

        }


    }
    
}

