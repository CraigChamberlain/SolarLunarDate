using System.Collections.Generic;
using SolarLunarName.SharedTypes.Interfaces;
using SolarLunarName.SharedTypes.Primitives;
using System.Net.Http;
using System;
using System.IO;

namespace SolarLunarName.Standard.RestServices.RemoteJson
{

    public class LunarCalendarClient : Json.LunarCalendarClient
    {   
        // FIXME Tests are not passing for Remote
        // TODO URI should not be in the compiled code.  
        // Need in a json file
        public LunarCalendarClient(HttpClient client, string baseUrl = "https://craigchamberlain.github.io/moon-data/api/lunar-solar-calendar-detailed/")
        {
            _baseUrl = baseUrl;
            _client = client;
        }

        protected HttpClient _client;
        protected string _baseUrl;

        protected override T StreamDeligate<T>(ValidYear year, ValidLunarMonth month, Func<Stream, T> method){
            
            Uri uri = Helpers.CombinePath(_baseUrl, year);
            using (Stream s = _client.GetStreamAsync(uri).Result){
               return method(s);
            };

        }
        protected override T StreamDeligate<T>(ValidYear year, Func<Stream, T> method){
            
            Uri uri = Helpers.CombinePath(_baseUrl, year);
            using (Stream s = _client.GetStreamAsync(uri).Result){
               return method(s);
            };

        }


    }

}
