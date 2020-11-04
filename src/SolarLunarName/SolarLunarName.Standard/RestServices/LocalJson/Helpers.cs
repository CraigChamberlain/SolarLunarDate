using System.IO;
using Newtonsoft.Json;

namespace SolarLunarName.Standard.RestServices.LocalJson{

    class Helpers {

        static internal void TestPath(string Path){
             if(!System.IO.Directory.Exists(Path)){
                 throw new System.ArgumentException("Base URl Does not resolve.");
             }
        }

        static internal T Deserialize<T>(string path){
                using (Stream s = File.OpenRead(path))
                using (StreamReader sr = new StreamReader(s))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    return serializer.Deserialize<T>(reader);

                }
        }

    }
}
