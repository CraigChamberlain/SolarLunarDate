using System.Collections.Generic;
using SolarLunarName.SharedTypes.Interfaces;
using SolarLunarName.SharedTypes.Primitives;
using System.Net.Http;
using System;
using System.IO;

namespace SolarLunarName.Standard.RestServices.RemoteJson
{
    // TODO Delete method in version 1.0.0
    [Obsolete("This Class is being deprecated in version 1.0.0 use LunarCalendarClient instead.  LunarCalendarClient now implements the ILunarCalendarClientDetailed Interface, downcast it to ILunarCalendarClient if lesser API is sufficient")]
    public class LunarCalendarClientDetailed : LunarCalendarClient
    {  
        public LunarCalendarClientDetailed(HttpClient client, string baseUrl = "https://craigchamberlain.github.io/moon-data/api/lunar-solar-calendar-detailed/"):base(client, baseUrl)
        {   
        }
        
    }

}
