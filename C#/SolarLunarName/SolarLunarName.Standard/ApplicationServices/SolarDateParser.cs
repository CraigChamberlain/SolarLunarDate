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

        // will find next month if day not available in month. Does not handle month not in year?
        public SolarLunarNameSimple NextMonth(SolarLunarNameSimple solarLunarNameSimple){
            
            var db = new RemoteLunarCalendarClient(); 
            
            var data = db.GetYearData(solarLunarNameSimple.Year.ToString());
                            
            var daysOfMonth = 
                            data                
                            .Where((_, index) => index == solarLunarNameSimple.LunarMonth )
                            .Select( x => x.Days)
                            .First();

            int daysRemaining;
            int dayDifference = solarLunarNameSimple.LunarDay - daysOfMonth;
            if(dayDifference > 0){
              daysRemaining = dayDifference;
            }
            else{
                daysRemaining = solarLunarNameSimple.LunarDay;
            }

            var year = solarLunarNameSimple.Year;
            var month = solarLunarNameSimple.LunarMonth + 1;

            if(month > data.Count){
                year += 1;
                month = 0;
            }  
            
            return new SolarLunarNameSimple(year, month, daysRemaining);
        }
       

    }
}

