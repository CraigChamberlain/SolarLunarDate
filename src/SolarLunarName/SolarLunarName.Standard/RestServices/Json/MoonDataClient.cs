using System;
using System.Collections.Generic;
using SolarLunarName.SharedTypes.Interfaces;
using SolarLunarName.SharedTypes.Primitives;
using System.IO;

namespace SolarLunarName.Standard.RestServices.Json
{

    public abstract class MoonDataClient : IMoonDataClient
    {

        protected IList<DateTime> GetYear(ValidYear year, Stream s)
        {
            return Helpers.Deserialize<List<DateTime>>(s);
        }
        public abstract IList<DateTime> GetYear(ValidYear year);
        public IList<DateTime> GetYear(string year){
            return GetYear((ValidYear)year);
        }

    }
}
