using System;
using SolarLunarName.SharedTypes.Primitives;

namespace SolarLunarName.Standard.RestServices.RemoteJson{

    public class Helpers {

        
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
