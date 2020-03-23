using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using SolarLunarName.Standard.Models;
using SolarLunarName.Standard.Types;

namespace SolarLunarName.Standard.RestServices.RemoteJson{

    public class  MoonDataClient: IMoonDataClient
    {

        const string BaseUrl = "https://craigchamberlain.github.io/moon-data/api/new-moon-data/";
        
        public List<DateTime> GetYear(string year){
            using(var client = new WebClient()){
                var yearJson = client.DownloadString(BaseUrl+year);
                return JsonConvert.DeserializeObject<List<DateTime>>(yearJson);
            }
        }
    }

    public class  LunarCalendarClient: ISolarLunarCalendarClient
    {

        const string BaseUrl = "https://craigchamberlain.github.io/moon-data/api/lunar-solar-calendar/";
        
        public List<LunarSolarCalendarMonth> GetYearData(string year){
            using(var client = new WebClient()){
                var yearJson = client.DownloadString(BaseUrl+year);
                return JsonConvert.DeserializeObject<List<LunarSolarCalendarMonth>>(yearJson);
            }
        }
    }
}