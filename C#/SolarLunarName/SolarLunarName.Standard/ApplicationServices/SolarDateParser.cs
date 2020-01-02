using SolarLunarName.Standard.Models;
using System;
using System.Linq;
using SolarLunarName.Standard.RestServices.LocalJson;
using SolarLunarName.Standard.RestServices.RemoteJson;
using System.Text.RegularExpressions;

namespace SolarLunarName.Standard.ApplicationServices
{
    public class SolarDateParser
    {

        public DateTime ConvertRemoteSolarLunarName(string date){

            var SolarLunarName = ParseSolarLunarName(date);

            return ConvertRemoteSolarLunarName(SolarLunarName.Year, SolarLunarName.LunarMonth, SolarLunarName.LunarDay);
        }
        public DateTime ConvertSolarLunarName(int year, int month, int day)
        {

            var startOfYear = new DateTime(year, 1, 1);
            var db = new MoonDataClient();
                
            string path = @"./assets/moon-data/"+ year+".json";

            DateTime newMoon = db.GetYear(path).Where(
                                x => x.Date.Year == year
                                && x.Phase == Moon.MoonPhase.NewMoon

                            )
                            .OrderBy(x => x.Date)
                            .Where((_, index) => index == month )
                            .Select(x => x.Date )
                            .First();

            var solarDateTime = newMoon.AddDays(day - 1);

            return new DateTime(solarDateTime.Year, solarDateTime.Month, solarDateTime.Day);

            
        }
        public DateTime ConvertRemoteSolarLunarName(int year, int month, int day)
        {

            var startOfYear = new DateTime(year, 1, 1);
            var db = new RemoteLunarCalendarClient();
                
            
            DateTime newMoon = db.GetYearData(year.ToString())
                            .OrderBy(x => x.Date)
                            .Where((_, index) => index == month )
                            .Select( x => x.Date)
                            .First();

            var solarDateTime = newMoon.AddDays(day - 1);

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

