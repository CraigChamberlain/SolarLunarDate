using System.Collections.Generic;
using Newtonsoft.Json;
using SolarLunarName.Standard.Models;

namespace SolarLunarName.Standard.RestServices.LocalJson{

    public class  MoonDataClient
    {

            public List<MoonPhaseEntity> GetYear(string path){
                var yearJson = System.IO.File.ReadAllText(path);
                return JsonConvert.DeserializeObject<List<MoonPhaseEntity>>(yearJson);
            }
    }
}