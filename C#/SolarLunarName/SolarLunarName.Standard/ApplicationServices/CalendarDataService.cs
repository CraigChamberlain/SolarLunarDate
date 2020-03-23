using SolarLunarName.Standard.RestServices.RemoteJson;
using SolarLunarName.Standard.Types;
using System.Collections.Generic;


namespace SolarLunarName.Standard.ApplicationServices
{
    public class CalendarDataService
    {   

        public CalendarDataService(ISolarLunarCalendarClient calendarClient){
            db = calendarClient;

        }
        private ISolarLunarCalendarClient db;

        public List<Models.LunarSolarCalendarMonth> GetSolarLunarYear(int year)
        {       
                return db.GetYearData(year.ToString());

            }

        public Models.LunarSolarCalendarMonth GetSolarLunarMonth(int year, int month)
        {                
                return  db.GetYearData(year.ToString())[month];

            }

        public int DaysInMonth (int year, int month){

            return GetSolarLunarMonth(year, month).Days;
        
        }

        public int MonthsInYear (int year){

            return GetSolarLunarYear(year).Count;
        
        }


    }
    
}

