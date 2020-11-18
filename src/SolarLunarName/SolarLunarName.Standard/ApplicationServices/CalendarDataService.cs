using SolarLunarName.SharedTypes.Interfaces;
using System.Collections.Generic;
using SolarLunarName.SharedTypes.Primitives;


namespace SolarLunarName.Standard.ApplicationServices
{
    public class CalendarDataService
    {   

        public CalendarDataService(ISolarLunarCalendarClient calendarClient){
            db = calendarClient;

        }
        protected ISolarLunarCalendarClient db;

        public IList<ILunarSolarCalendarMonth> GetSolarLunarYear(int year)
        {       
                return db.GetYearData((ValidYear)year);

            }

        public ILunarSolarCalendarMonth GetSolarLunarMonth(int year, int month)
        {                
                return  db.GetMonthData((ValidYear)year, (ValidLunarMonth)month);

            }

        public int DaysInMonth (int year, int month){

            return GetSolarLunarMonth(year, month).Days;
        
        }

        public int MonthsInYear (int year){

            return GetSolarLunarYear(year).Count;
        
        }


    }
    
}

