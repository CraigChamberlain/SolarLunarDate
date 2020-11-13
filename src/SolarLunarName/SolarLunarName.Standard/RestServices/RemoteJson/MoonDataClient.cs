using System;
using System.Collections.Generic;
using System.IO;
using SolarLunarName.SharedTypes.Primitives;
using System.Net.Http;

namespace SolarLunarName.Standard.RestServices.RemoteJson
{

    public class MoonDataClient : Json.MoonDataClient
    {

        public MoonDataClient(HttpClient client, string baseUrl)
        {   
            _client = client;
            
            Helpers.TestUrl(_client, baseUrl);
            _baseUrl = baseUrl;
        }

        // TODO Delete this constructor in version 1.0.0
        [Obsolete("This Constructor is being deprecated in version 1.0.0, You must provide both a HTTPClient instance and a baseUrl")]
        public MoonDataClient(string baseUrl ="https://craigchamberlain.github.io/moon-data/api/new-moon-data/"){
            
            _client = new HttpClient();
            
            Helpers.TestUrl(_client, baseUrl);
            _baseUrl = baseUrl;

        }

        protected HttpClient _client;
        private string _baseUrl;

        protected override  T StreamDeligate<T>(ValidYear year, Func<Stream, T> method){
            Uri uri = Helpers.CombinePath(_baseUrl, year);
            using (Stream s = _client.GetStreamAsync(uri).Result){
                return method(s);
            }

        }

    }
}
