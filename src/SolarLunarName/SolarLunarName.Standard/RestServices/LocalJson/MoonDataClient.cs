using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SolarLunarName.SharedTypes.Interfaces;
using System.IO;

namespace SolarLunarName.Standard.RestServices.LocalJson{

    public class  MoonDataClient : IMoonDataClient
    {

            public MoonDataClient(string basePath){
               Helpers.TestPath(basePath);
               _basePath = basePath;
            }

            private string _basePath; 
            public IList<DateTime> GetYear(string year){

                
                string path = Path.Combine(_basePath, year, "index.json");
                
                using( Stream s = File.OpenRead(path))
                using (StreamReader sr = new StreamReader(s))
                using (JsonReader reader = new JsonTextReader(sr))
                {               
                    JsonSerializer serializer = new JsonSerializer();
                    return serializer.Deserialize<List<DateTime>>(reader);
                }
            }
    
    }
}
