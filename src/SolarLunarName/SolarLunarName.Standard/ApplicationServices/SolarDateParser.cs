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

            var solarLunarName = ParseSolarLunarName(date);

            return ConvertSolarLunarName(solarLunarName);
        }
        public DateTime ConvertSolarLunarName(int year, int month, int day)
        {
            var solarLunarName = new SolarLunarNameSimple(year, month, day);
            return ConvertSolarLunarName(solarLunarName);

        }
        public DateTime ConvertSolarLunarName(SolarLunarNameSimple solarLunarName)
        {
            try{
                return ConvertSolarLunarNameExact(solarLunarName);
            }
            catch{
                var resolvedDate = ResolveOverflowingDate(solarLunarName);
                return ConvertSolarLunarNameExact(resolvedDate);
            }

        }

        // TODO Delete method in version 1.0.0
        [Obsolete("NextMonth is being deprecated in version 1.0.0 use ResolveOverflowingDate which is now recursive, will wrap both overflowing month and year.")]
        public SolarLunarNameSimple NextMonth(SolarLunarNameSimple solarLunarNameSimple){
            return ResolveOverflowingDate(solarLunarNameSimple);
        }

        private SolarLunarNameSimple ResolveOverflowingDateInner(SolarLunarNameSimple solarLunarNameSimple){
            
                   
            var data = db.GetYearData(solarLunarNameSimple.Year);
            
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
        public SolarLunarNameSimple ResolveOverflowingDate(SolarLunarNameSimple solarLunarNameSimple){
            
            var reslovedMonth = ResolveOverflowingDateInner(solarLunarNameSimple);
            if(
                reslovedMonth.Year == solarLunarNameSimple.Year &&
                reslovedMonth.LunarMonth == solarLunarNameSimple.LunarMonth &&
                reslovedMonth.LunarDay == solarLunarNameSimple.LunarDay
                ){
                return reslovedMonth;
            }
            else{
                return ResolveOverflowingDateInner(reslovedMonth);
            }
        }
       

    }
}

