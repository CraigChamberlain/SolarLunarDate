using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using SolarLunarName.SharedTypes.Models;
using SolarLunarName.SharedTypes.Interfaces;

namespace SolarLunarName.Standard.RestServices.LocalJson{

    public class  MoonDataClient : IMoonDataClient
    {

            public MoonDataClient(string basePath){
               Helpers.TestPath(basePath);
               _basePath = basePath;
            }

            private string _basePath; 
            public IList<DateTime> GetYear(string year){

                string path = System.IO.Path.Combine(_basePath, year, "index.json");

                var yearJson = System.IO.File.ReadAllText(path);
                return JsonConvert.DeserializeObject<List<DateTime>>(yearJson);
            }
    
    }
}
