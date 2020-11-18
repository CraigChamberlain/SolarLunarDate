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
        protected override bool ExpectedExceptionPredicate(Exception e) => 
            e.GetType() == typeof(System.IO.DirectoryNotFoundException); 
    
        protected override T StreamDeligate<T>(ValidYear year, ValidLunarMonth month, Func<Stream, T> method){
            
            string path = Helpers.CombinePath(_basePath, year, month);
            return StreamDeligate<T>(path, method);

        }
        protected override T StreamDeligate<T>(ValidYear year, Func<Stream, T> method){
            
            string path = Helpers.CombinePath(_basePath, year);
            return StreamDeligate<T>(path, method);

        }
        private T StreamDeligate<T>(string path, Func<Stream, T> method){
            
            using (Stream s = File.OpenRead(path))
            {
                return method(s);
            }

        }


    }

}
