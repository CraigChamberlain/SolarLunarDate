using System;
using System.Collections.Generic;
using System.Linq;
using SolarLunarName.SharedTypes.Models;
using SolarLunarName.SharedTypes.Interfaces;
using System.IO;
using SolarLunarName.SharedTypes.Primitives;

namespace SolarLunarName.Standard.RestServices.Json
{

    public abstract class LunarCalendarClient : ISolarLunarCalendarClient
    {

        protected IList<ILunarSolarCalendarMonth> GetYearData(ValidYear year, Stream s)
        {

            return Helpers.Deserialize<List<LunarSolarCalendarMonth>>(s)
                                        .Select(month => (ILunarSolarCalendarMonth)month)
                                        .ToList();


        }

        protected ILunarSolarCalendarMonth GetMonthData(ValidYear year, ValidLunarMonth month, Stream s)
        {

            try
            {
                return Helpers.Deserialize<LunarSolarCalendarMonth>(s);
            }
            catch (System.IO.DirectoryNotFoundException)
            {

                var monthsInYear = GetYear(year).Count();
                throw new SolarLunarName.SharedTypes.Exceptions.MonthDoesNotExistException(year, month, monthsInYear);
            }

        }

        public IList<DateTime> GetYear(ValidYear year){
                return GetYearData(year)
                    .Select(x=> x.FirstDay)
                    .ToList();
        }
        public IList<DateTime> GetYear(string year){
                return GetYear(year);
        }
        public abstract IList<ILunarSolarCalendarMonth> GetYearData(ValidYear year);
        public abstract ILunarSolarCalendarMonth GetMonthData(ValidYear year, ValidLunarMonth month);

        protected virtual IList<ILunarSolarCalendarMonthDetailed> GetYearDataDetailed(ValidYear year, Stream s)
        {

            return Helpers.Deserialize<List<LunarSolarCalendarMonthDetailed>>(s)
                .Select(month => (ILunarSolarCalendarMonthDetailed)month)
                .ToList();
            

        }

        protected virtual ILunarSolarCalendarMonthDetailed GetMonthDataDetailed(ValidYear year, ValidLunarMonth month, Stream s)
        {

            return Helpers.Deserialize<LunarSolarCalendarMonthDetailed>(s);

        }
        public IList<ILunarSolarCalendarMonth> GetYearData(string year){
            return GetYearData((ValidYear)year);
        }
        public ILunarSolarCalendarMonth GetMonthData(int year, int month){
            return GetMonthData((ValidYear)year, (ValidLunarMonth)month);
        }


    }

}
