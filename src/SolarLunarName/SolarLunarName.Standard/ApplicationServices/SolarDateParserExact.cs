using SolarLunarName.SharedTypes.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using SolarLunarName.SharedTypes.Exceptions;
using SolarLunarName.SharedTypes.Primitives;

namespace SolarLunarName.Standard.ApplicationServices
{
    public partial class  SolarDateParser
    {

        public DateTime ConvertSolarLunarNameExact(string date){

            var solarLunarName = ParseSolarLunarName(date);
            return ConvertSolarLunarNameExact(solarLunarName);
        }

        public DateTime ConvertSolarLunarNameExact(int year, int month, int day)
        {
            var solarLunarName = new SolarLunarNameSimple(year, month, day);
            return ConvertSolarLunarNameExact(solarLunarName);
            
        }
        public DateTime ConvertSolarLunarNameExact(SolarLunarNameSimple solarLunarName)
        {
                int daysInMonth = db.GetMonthData((ValidYear)solarLunarName.Year, (ValidLunarMonth)solarLunarName.LunarMonth).Days;
                if( daysInMonth < solarLunarName.LunarDay){
                    throw new DayDoesNotExistException(solarLunarName.Year, solarLunarName.LunarMonth, solarLunarName.LunarDay, daysInMonth);
                };
    
                var startOfYear = new DateTime(solarLunarName.Year, 1, 1);

                DateTime newMoon = db.GetYearData(solarLunarName.Year)
                                .OrderBy(x => x.FirstDay)
                                .Where((_, index) => index == solarLunarName.LunarMonth )
                                .Select( x => x.FirstDay)
                                .First();

                var solarDateTime = newMoon.AddDays(solarLunarName.LunarDay - 1);

                return new DateTime(solarDateTime.Year, solarDateTime.Month, solarDateTime.Day);
            
        }
        public SolarLunarNameSimple ParseSolarLunarName(string date){

            var rx = new Regex(@"(?<year>\d{4})-(?<month>\d{1,2})-(?<day>\d{1,2})", RegexOptions.Compiled);
            
            var match = rx.Match(date);
            if( match.Success == false ){
                throw new FormatException("Should be of format '{{Year}}-{{Month}}-{{Day}}' for example '1750-10-6'.  Year must be four digits and Month & Day one or two digits.");
            }
            var year = Int16.Parse(match.Groups["year"].Value);
            var month = Int16.Parse(match.Groups["month"].Value);
            var day = Int16.Parse(match.Groups["day"].Value);
            return new SolarLunarNameSimple(year, month, day);
        }
    }
}

