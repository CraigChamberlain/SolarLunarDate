using System.IO;
using Newtonsoft.Json;

namespace SolarLunarName.Standard.RestServices.Json{

    class Helpers {
        static internal T Deserialize<T>(Stream s){
                using (StreamReader sr = new StreamReader(s))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    return serializer.Deserialize<T>(reader);

                }
        }

    }
}