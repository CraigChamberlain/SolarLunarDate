using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using SolarLunarName.SharedTypes.Models;
using SolarLunarName.SharedTypes.Interfaces;

namespace SolarLunarName.Standard.RestServices.RemoteJson{

    public class  MoonDataClient
    {

        const string BaseUrl = "https://craigchamberlain.github.io/moon-data/api/new-moon-data/";
        
        public IList<DateTime> GetYear(string year){
            using(var client = new WebClient()){
                var yearJson = client.DownloadString(BaseUrl+year);
                return JsonConvert.DeserializeObject<List<DateTime>>(yearJson);
            }
        }
    }

    public class  LunarCalendarClient
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
        
        public IList<DateTime> GetYear(string year)
        {
            return GetYearData(year)
                .Select(Month => Month.FirstDay)
                .ToList();
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

    public class  LunarCalendarClientDetailed
    {

        const string BaseUrl = "https://craigchamberlain.github.io/moon-data/api/lunar-solar-calendar-detailed/";

        public ILunarSolarCalendarMonthDetailed GetMonthDataDetailed(int year, int month)
        {
            throw new NotImplementedException();
        }

        public IList<ILunarSolarCalendarMonthDetailed> GetYearDataDetailed(string year)
        {
            throw new NotImplementedException();
        }

    
    }
}