using System.IO;
using Newtonsoft.Json;

namespace SolarLunarName.Standard.RestServices.LocalJson{

    class Helpers {

        static internal void TestPath(string Path){
             if(!System.IO.Directory.Exists(Path)){
                 throw new System.ArgumentException($"Base URl Does not resolve: {Path}");
             }
        }
        
        static internal string CombinePath(string _basePath, string year, string month){
            SolarLunarName.SharedTypes.Validation.Helpers.ValidateYear(year);
            SolarLunarName.SharedTypes.Validation.Helpers.ValidateLunarMonth(month);
            var path = Path.Combine(_basePath, year, month, "index.json");
            return path;

        }

        static internal string CombinePath(string _basePath, string year){
            SolarLunarName.SharedTypes.Validation.Helpers.ValidateYear(year);
            var path = Path.Combine(_basePath, year, "index.json");
            return path;

        }


            


    }
}
