using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using SolarLunarName.Standard.Models;
using SolarLunarName.Standard.Types;

namespace SolarLunarName.Standard.RestServices.LocalJson{

    public class  MoonDataClient : IMoonDataClient
    {

            public MoonDataClient(string basePath){
               _basePath = basePath;
            }

            private string _basePath; 
            public List<DateTime> GetYear(string year){

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

        private string _basePath;
        
        public List<LunarSolarCalendarMonth> GetYearData(string year){

            string path = System.IO.Path.Combine(_basePath, year, "index.json");

                var yearJson = System.IO.File.ReadAllText(path);
                return JsonConvert.DeserializeObject<List<LunarSolarCalendarMonth>>(yearJson);

        }
    }
}