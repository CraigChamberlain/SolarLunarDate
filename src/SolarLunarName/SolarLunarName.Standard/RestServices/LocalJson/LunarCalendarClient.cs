using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using SolarLunarName.SharedTypes.Models;
using SolarLunarName.SharedTypes.Interfaces;

namespace SolarLunarName.Standard.RestServices.LocalJson{

    public class  LunarCalendarClient: ISolarLunarCalendarClient
    {

        public LunarCalendarClient(string basePath){
            Helpers.TestPath(basePath);
            _basePath = basePath;
        }

        protected string _basePath;
        
        public IList<ILunarSolarCalendarMonth> GetYearData(string year){

            SolarLunarName.SharedTypes.Validation.Helpers.ValidateYear(year);

            string path = System.IO.Path.Combine(_basePath, year, "index.json");

                var yearJson = System.IO.File.ReadAllText(path);
                
                IList<ILunarSolarCalendarMonth> yearData = 
                     JsonConvert
                            .DeserializeObject<List<LunarSolarCalendarMonth>>(yearJson)
                            .Select(month => (ILunarSolarCalendarMonth) month)
                            .ToList();

                return (List<ILunarSolarCalendarMonth>)yearData;
 
        }

        public ILunarSolarCalendarMonth GetMonthData(int year, int month)
        {

            SolarLunarName.SharedTypes.Validation.Helpers.ValidateYear(year);
            SolarLunarName.SharedTypes.Validation.Helpers.ValidateLunarMonth(month);

            try{
                string path = System.IO.Path.Combine(_basePath, year.ToString(), month.ToString(), "index.json");

                    var yearJson = System.IO.File.ReadAllText(path);
                    
                    return JsonConvert.DeserializeObject<LunarSolarCalendarMonth>(yearJson);
            }
            catch (System.IO.DirectoryNotFoundException){

                var monthsInYear = GetYear(year.ToString()).Count();
                throw new SolarLunarName.SharedTypes.Exceptions.MonthDoesNotExistException(year, month, monthsInYear);
            }
                
        }

        public IList<DateTime> GetYear(string year)
        {
            return GetYearData(year)
                .Select(Month => Month.FirstDay)
                .ToList();
        }
    }

}
