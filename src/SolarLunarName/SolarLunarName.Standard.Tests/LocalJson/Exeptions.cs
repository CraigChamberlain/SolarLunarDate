using System;
using System.Collections.Generic;
using Xunit;
using SolarLunarName.Standard.ApplicationServices;
using System.Linq;
using SolarLunarName.SharedTypes.Models;
using SolarLunarName.Standard.Tests.JsonClient;
using SolarLunarName.Standard.RestServices.LocalJson;
using SolarLunarName.SharedTypes.Interfaces;

namespace SolarLunarName.Standard.Tests.LocalJson
{
    public class LunarCalendarClientExceptions : GetMonthDataExceptions
    {   
        public LunarCalendarClientExceptions(){
            _client = new LunarCalendarClient(Paths.calendarApi);
        }
    }
    
}