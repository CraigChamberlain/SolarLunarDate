using SolarLunarName.Standard.Models;
using System;
using System.Linq;
using SolarLunarName.Standard.RestServices.LocalJson;
using SolarLunarName.Standard.RestServices.RemoteJson;
using System.Text.RegularExpressions;

namespace SolarLunarName.Standard.ApplicationServices
{
    public partial class SolarDateParser
    {
        public DateTime ConvertRemoteSolarLunarName(string date){

            var SolarLunarName = ParseSolarLunarName(date);

            return ConvertRemoteSolarLunarName(SolarLunarName.Year, SolarLunarName.LunarMonth, SolarLunarName.LunarDay);
        }
        public DateTime ConvertRemoteSolarLunarName(int year, int month, int day)
        {

            try{
                return ConvertRemoteSolarLunarNameExact(year, month, day);
            }
            catch
            {   
                var nextMonth = NextMonth(new SolarLunarNameSimple(year, month, day));
                return ConvertRemoteSolarLunarName(nextMonth.Year, nextMonth.LunarMonth, nextMonth.LunarDay);
            }
            
        }

        // will find next month if day not available in month even if in next year.
        // Wraps on month or year but not recursively.  Should probably be targeted better.
        // Wrapping may be better precisely defined before more work.
        public SolarLunarNameSimple NextMonth(SolarLunarNameSimple solarLunarNameSimple){
            
            var db = new RemoteLunarCalendarClient(); 
            
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

            if(month > data.Count - 1){
                year += 1;
                month = month - data.Count;
            }

            return new SolarLunarNameSimple(year, month, daysRemaining);
        }
       

    }
}

