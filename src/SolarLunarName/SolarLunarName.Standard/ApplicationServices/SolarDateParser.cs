using SolarLunarName.SharedTypes.Interfaces;
using SolarLunarName.SharedTypes.Models;
using System;
using System.Linq;


namespace SolarLunarName.Standard.ApplicationServices
{
    public partial class SolarDateParser
    {

        public SolarDateParser(ISolarLunarCalendarClient calendarClient){
            db = calendarClient;

        }
        private ISolarLunarCalendarClient db;
      
        public DateTime ConvertRemoteSolarLunarName(string date){

            var SolarLunarName = ParseSolarLunarName(date);

            return ConvertSolarLunarName(SolarLunarName.Year, SolarLunarName.LunarMonth, SolarLunarName.LunarDay);
        }
        public DateTime ConvertSolarLunarName(int year, int month, int day)
        {

            try{
                return ConvertSolarLunarNameExact(year, month, day);
            }
            catch
            {   
                var nextMonth = NextMonth(new SolarLunarNameSimple(year, month, day));
                return ConvertSolarLunarName(nextMonth.Year, nextMonth.LunarMonth, nextMonth.LunarDay);
            }
            
        }

        // FIXME
        // Not a good name. Should be resolve out of bounds?  Sounds like add month.
        // will find next month if day not available in month even if in next year.
        // Wraps on month or year but not recursively.  Should probably be targeted better.
        // Wrapping may be better precisely defined before more work.
        public SolarLunarNameSimple NextMonth(SolarLunarNameSimple solarLunarNameSimple){
            
                   
            var data = db.GetYearData(solarLunarNameSimple.Year.ToString());
            
            var daysOfMonth = 
                            data                
                            .Where((_, index) => index == solarLunarNameSimple.LunarMonth )
                            .Select( x => x.Days)
                            .FirstOrDefault();

            int month = solarLunarNameSimple.LunarMonth;
            int daysRemaining;
            int dayDifference = solarLunarNameSimple.LunarDay - daysOfMonth;
            var year = solarLunarNameSimple.Year;
            
            if(dayDifference > 0){
              daysRemaining = dayDifference;
              if(daysOfMonth != 0){month += 1;}
            }
            else{
                daysRemaining = solarLunarNameSimple.LunarDay;
            }

            if(month > data.Count() - 1){
                year += 1;
                month = month - data.Count();
            }

            return new SolarLunarNameSimple(year, month, daysRemaining);
        }
       

    }
}

