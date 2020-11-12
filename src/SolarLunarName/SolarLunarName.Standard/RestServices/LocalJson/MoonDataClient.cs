using System;
using System.Collections.Generic;
using System.IO;
using SolarLunarName.SharedTypes.Primitives;


namespace SolarLunarName.Standard.RestServices.LocalJson
{

    public class MoonDataClient : Json.MoonDataClient
    {   
        protected override T StreamDeligate<T>(ValidYear year, Func<Stream, T> method)=> throw new NotImplementedException();

        public MoonDataClient(string basePath)
        {
            Helpers.TestPath(basePath);
            _basePath = basePath;
        }

        private string _basePath;
        public override IList<DateTime> GetYear(ValidYear year)
        {
            string path = Helpers.CombinePath(_basePath, year);
            using (Stream s = File.OpenRead(path)){
                return base.GetYear(year, s);
            }

        }

    }
}
