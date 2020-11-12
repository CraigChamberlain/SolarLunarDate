using System;
using System.Collections.Generic;
using SolarLunarName.SharedTypes.Interfaces;
using SolarLunarName.SharedTypes.Primitives;
using System.IO;

namespace SolarLunarName.Standard.RestServices.Json
{

    public abstract class MoonDataClient : Client, IMoonDataClient
    {

        protected override abstract T StreamDeligate<T>(ValidYear year, Func<Stream, T> method);

        protected IList<DateTime> GetYear(ValidYear year, Stream s)
        {
            return base.Deserialize<List<DateTime>>(s);
        }
        public abstract IList<DateTime> GetYear(ValidYear year);
        public IList<DateTime> GetYear(string year){
            return GetYear((ValidYear)year);
        }

    }
}
