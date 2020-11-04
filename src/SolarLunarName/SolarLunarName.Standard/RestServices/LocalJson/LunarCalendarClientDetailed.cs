using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using SolarLunarName.SharedTypes.Models;
using SolarLunarName.SharedTypes.Interfaces;

namespace SolarLunarName.Standard.RestServices.LocalJson{

    
    public class  LunarCalendarClientDetailed: LunarCalendarClient, ISolarLunarCalendarClientDetailed
    {
        public LunarCalendarClientDetailed(string basePath) : base(basePath)
        {   
            base._basePath = basePath;
        }

        public IList<ILunarSolarCalendarMonthDetailed> GetYearDataDetailed(string year)
        {
            SolarLunarName.SharedTypes.Validation.Helpers.ValidateLunarMonth(year);

            string path = System.IO.Path.Combine(_basePath, year, "index.json");

                var yearJson = System.IO.File.ReadAllText(path);
                
                IList<ILunarSolarCalendarMonthDetailed> yearData = 
                     JsonConvert
                            .DeserializeObject<List<LunarSolarCalendarMonthDetailed>>(yearJson)
                            .Select(month => (ILunarSolarCalendarMonthDetailed) month)
                            .ToList();

                return (List<ILunarSolarCalendarMonthDetailed>)yearData;
        }

        public ILunarSolarCalendarMonthDetailed GetMonthDataDetailed(int year, int month)
        {

            SolarLunarName.SharedTypes.Validation.Helpers.ValidateYear(year);
            SolarLunarName.SharedTypes.Validation.Helpers.ValidateLunarMonth(month);

            string path = System.IO.Path.Combine(_basePath, year.ToString(), month.ToString(), "index.json");

                var yearJson = System.IO.File.ReadAllText(path);
                
                return JsonConvert.DeserializeObject<LunarSolarCalendarMonthDetailed>(yearJson);
                
        }

    }
}
