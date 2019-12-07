using SolarLunarName.Standard.RestServices.RemoteJson;
using System.Collections.Generic;


namespace SolarLunarName.Standard.ApplicationServices
{
    public class CalendarDataService
    {   
        private RemoteLunarCalendarClient db = new RemoteLunarCalendarClient();

        public List<Models.LunarSolarCalendarMonth> GetSolarLunarYear(int year)
        {       
                return db.GetYearData(year.ToString());

            }

        public Models.LunarSolarCalendarMonth GetSolarLunarMonth(int year, int month)
        {                
                return  db.GetYearData(year.ToString())[month];

            }


    }
    
}

