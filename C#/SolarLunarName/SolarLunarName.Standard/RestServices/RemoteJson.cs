using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using SolarLunarName.Standard.Models;
using SolarLunarName.Standard.Types;

namespace SolarLunarName.Standard.RestServices.RemoteJson{

    public class  MoonDataClient: IMoonDataClient
    {

        const string BaseUrl = "https://craigchamberlain.github.io/moon-data/api/new-moon-data/";
        
        public IList<DateTime> GetYear(string year){
            using(var client = new WebClient()){
                var yearJson = client.DownloadString(BaseUrl+year);
                return JsonConvert.DeserializeObject<List<DateTime>>(yearJson);
            }
        }
    }

    public class  LunarCalendarClient: ISolarLunarCalendarClient
    {

        const string BaseUrl = "https://craigchamberlain.github.io/moon-data/api/lunar-solar-calendar/";

        public ILunarSolarCalendarMonth GetMonthData(int year, int month)
        {
            using(var client = new WebClient()){
                var uri = new Uri (new Uri(new Uri(BaseUrl), year.ToString()), month.ToString());
                
                var yearJson = client.DownloadString(uri);

                return  JsonConvert.DeserializeObject<LunarSolarCalendarMonth>(yearJson);
            }
        }

        public IList<ILunarSolarCalendarMonth> GetYearData(string year){
            using(var client = new WebClient()){
                var yearJson = client.DownloadString(BaseUrl+year);
                IList<ILunarSolarCalendarMonth> yearData = 
                     JsonConvert
                            .DeserializeObject<List<LunarSolarCalendarMonth>>(yearJson)
                            .Select(month => (ILunarSolarCalendarMonth) month)
                            .ToList();
                return yearData;
            }
        }
    }

    public class  LunarCalendarClientDetailed: LunarCalendarClient, ISolarLunarCalendarClientDetailed
    {

        const string BaseUrl = "https://craigchamberlain.github.io/moon-data/api/lunar-solar-calendar-detailed/";
        
        public IList<ILunarSolarCalendarMonthDetailed> GetYearDataDetailed(string year)
        {
            throw new NotImplementedException();
        }

    
    }
}