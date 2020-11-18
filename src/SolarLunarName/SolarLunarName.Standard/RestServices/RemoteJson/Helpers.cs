using System;
using SolarLunarName.SharedTypes.Primitives;
using System.Net.Http;

namespace SolarLunarName.Standard.RestServices.RemoteJson{

    public class Helpers {

        static internal void TestUrl(HttpClient client, string uri){
            
            try
            {   
                _ = client.GetAsync(uri).Result;
            }
            catch //If exception thrown then couldn't get response from address
            {
                throw new System.ArgumentException($"Base URl Does not resolve: {uri}");
            }

        }
        
        static public Uri CombinePath(string baseUrl, ValidYear year, ValidLunarMonth month){
            var path = $"{baseUrl}/{year}/{month}/index.json";
            return new Uri(path);
        }

        static public Uri CombinePath(string baseUrl, ValidYear year){
            var path = $"{baseUrl}/{year}/index.json";
            return new Uri(path);
        }


            


    }
}
