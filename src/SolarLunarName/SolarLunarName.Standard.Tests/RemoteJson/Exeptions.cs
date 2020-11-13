using System;
using System.Collections.Generic;
using Xunit;
using SolarLunarName.Standard.ApplicationServices;
using System.Linq;
using SolarLunarName.SharedTypes.Models;
using SolarLunarName.Standard.Tests.JsonClient;
using SolarLunarName.Standard.RestServices.RemoteJson;
using SolarLunarName.SharedTypes.Interfaces;
using System.Net.Http;

namespace SolarLunarName.Standard.Tests.RemoteJson
{
    public class LunarCalendarClientExceptions : GetMonthDataExceptions
    {   
        public LunarCalendarClientExceptions(){
            
            _client = new LunarCalendarClient(_httpClient, Paths.Remote.DetailedcalendarApi);
        }
        protected HttpClient _httpClient = new HttpClient();
    }
    
}