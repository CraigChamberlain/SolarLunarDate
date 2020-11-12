using System.IO;
using SolarLunarName.SharedTypes.Primitives;
using System.Collections.Generic;
using System;

namespace SolarLunarName.Standard.RestServices.LocalJson{

    class Helpers {

        static internal void TestPath(string Path){
             if(!System.IO.Directory.Exists(Path)){
                 throw new System.ArgumentException($"Base URl Does not resolve: {Path}");
             }
        }
        
        static internal string CombinePath(string basePath, ValidYear year, ValidLunarMonth month){
            var path = Path.Combine(basePath, (string)year, (string)month, "index.json");
            return path;

        }

        static internal string CombinePath(string basePath, ValidYear year){
            var path = Path.Combine(basePath, (string)year, "index.json");
            return path;

        }

        static internal T StreamHandler<T>(string basePath, ValidYear year, Func<ValidYear, Stream, T> method){
            
            string path = Helpers.CombinePath(basePath, year);
            using (Stream s = File.OpenRead(path))
            {
                return method(year, s);
            }
        }
        static internal T StreamHandler<T>(string basePath, ValidYear year, ValidLunarMonth month, Func<ValidYear, ValidLunarMonth, Stream, T> method){
            
            string path = Helpers.CombinePath(basePath, year, month);
            using (Stream s = File.OpenRead(path))
            {
                return method(year, month, s);
            }
        }


            


    }
}
