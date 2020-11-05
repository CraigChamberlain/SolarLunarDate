using System.IO;
using SolarLunarName.SharedTypes.Primitives;

namespace SolarLunarName.Standard.RestServices.LocalJson{

    class Helpers {

        static internal void TestPath(string Path){
             if(!System.IO.Directory.Exists(Path)){
                 throw new System.ArgumentException($"Base URl Does not resolve: {Path}");
             }
        }
        
        static internal string CombinePath(string _basePath, ValidYear year, ValidLunarMonth month){
            var path = Path.Combine(_basePath, (string)year, (string)month, "index.json");
            return path;

        }

        static internal string CombinePath(string _basePath, ValidYear year){
            var path = Path.Combine(_basePath, (string)year, "index.json");
            return path;

        }


            


    }
}
