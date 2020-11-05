using System;
using System.Collections.Generic;
using System.IO;
using SolarLunarName.SharedTypes.Primitives;
using System.Net.Http;

namespace SolarLunarName.Standard.RestServices.RemoteJson
{

    public class MoonDataClient : Json.MoonDataClient
    {

        public MoonDataClient(HttpClient client, string baseUrl="https://craigchamberlain.github.io/moon-data/api/new-moon-data/")
        {
            _baseUrl = baseUrl;
            _client = client;
        }

        protected HttpClient _client;
        private string _baseUrl;
        public override IList<DateTime> GetYear(ValidYear year)
        {
            Uri uri = Helpers.CombinePath(_baseUrl, year);
            using (Stream s = _client.GetStreamAsync(uri).Result){
                return base.GetYear(year, s);
            }

        }

    }
}
