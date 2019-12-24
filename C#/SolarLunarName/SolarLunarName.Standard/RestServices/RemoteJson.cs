using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using SolarLunarName.Standard.Models;


namespace SolarLunarName.Standard.RestServices.RemoteJson{

    public class  RemoteMoonDataClient
    {

        const string BaseUrl = "https://craigchamberlain.github.io/moon-data/api/new-moon-data/";
        
        public List<DateTime> GetYear(string year){
            using(var client = new WebClient()){
                var yearJson = client.DownloadString(BaseUrl+year);
                return JsonConvert.DeserializeObject<List<DateTime>>(yearJson);
            }
        }
    }

    public class  RemoteLunarCalendarClient
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