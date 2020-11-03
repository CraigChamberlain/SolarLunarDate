using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using SolarLunarName.SharedTypes.Models;
using SolarLunarName.SharedTypes.Interfaces;

namespace SolarLunarName.Standard.RestServices.LocalJson{

    public class  MoonDataClient : IMoonDataClient
    {

            public MoonDataClient(string basePath){
               _basePath = basePath;
            }

            private string _basePath; 
            public IList<DateTime> GetYear(string year){

                string path = System.IO.Path.Combine(_basePath, year, "index.json");

                var yearJson = System.IO.File.ReadAllText(path);
                return JsonConvert.DeserializeObject<List<DateTime>>(yearJson);
            }
    }

    public class  LunarCalendarClient: ISolarLunarCalendarClient
    {

        public LunarCalendarClient(string basePath){
            _basePath = basePath;
        }

        protected string _basePath;
        
        public IList<ILunarSolarCalendarMonth> GetYearData(string year){

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
            string path = System.IO.Path.Combine(_basePath, year.ToString(), month.ToString(), "index.json");

                var yearJson = System.IO.File.ReadAllText(path);
                
                return JsonConvert.DeserializeObject<LunarSolarCalendarMonth>(yearJson);
                
        }

        public IList<DateTime> GetYear(string year)
        {
            return GetYearData(year)
                .Select(Month => Month.FirstDay)
                .ToList();
        }
    }

    public class  LunarCalendarClientDetailed: LunarCalendarClient, ISolarLunarCalendarClientDetailed
    {
        public LunarCalendarClientDetailed(string basePath) : base(basePath)
        {
            base._basePath = basePath;
        }

        public IList<ILunarSolarCalendarMonthDetailed> GetYearDataDetailed(string year)
        {
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
            string path = System.IO.Path.Combine(_basePath, year.ToString(), month.ToString(), "index.json");

                var yearJson = System.IO.File.ReadAllText(path);
                
                return JsonConvert.DeserializeObject<LunarSolarCalendarMonthDetailed>(yearJson);
                
        }

    }
}
