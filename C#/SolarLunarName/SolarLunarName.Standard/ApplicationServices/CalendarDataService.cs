using SolarLunarName.Standard.RestServices.RemoteJson;
using System.Collections.Generic;


namespace SolarLunarName.Standard.ApplicationServices
{
    public class CalendarDataService
    {   
        public CalendarDataService(){
            db = new RemoteLunarCalendarClient();
        }
        public CalendarDataService(RemoteLunarCalendarClient calendarClient){
            db = calendarClient;

        }
        private RemoteLunarCalendarClient db;

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

