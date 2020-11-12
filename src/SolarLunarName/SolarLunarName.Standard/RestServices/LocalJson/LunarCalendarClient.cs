using System.Collections.Generic;
using SolarLunarName.SharedTypes.Interfaces;
using SolarLunarName.SharedTypes.Primitives;
using System.IO;
using System;

namespace SolarLunarName.Standard.RestServices.LocalJson
{

    public class LunarCalendarClient : Json.LunarCalendarClient
    {

        public LunarCalendarClient(string basePath)
        {
            Helpers.TestPath(basePath);
            _basePath = basePath;
        }

        protected string _basePath;

    
        protected override T StreamDeligate<T>(ValidYear year, ValidLunarMonth month, Func<Stream, T> method){
            
            string path = Helpers.CombinePath(_basePath, year, month);
            using (Stream s = File.OpenRead(path))
            {
                return method(s);
            }

        }
        protected override T StreamDeligate<T>(ValidYear year, Func<Stream, T> method){
            
            string path = Helpers.CombinePath(_basePath, year);
            using (Stream s = File.OpenRead(path))
            {
                return method(s);
            }

        }


    }

}
