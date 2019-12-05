using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using SolarLunarName.Standard.Models;


namespace SolarLunarName.Standard.RestServices.RemoteJson{

    public class  RemoteMoonDataClient
    {

        const string BaseUrl = "https://raw.githubusercontent.com/CraigChamberlain/SolarLunarDate/master/docs/api/moon-data/";
        
        public List<MoonPhaseEntity> GetYear(string year){
            using(var client = new WebClient()){
                var yearJson = client.DownloadString(BaseUrl+year+".json");
                return JsonConvert.DeserializeObject<List<MoonPhaseEntity>>(yearJson);
            }
        }
    }
}