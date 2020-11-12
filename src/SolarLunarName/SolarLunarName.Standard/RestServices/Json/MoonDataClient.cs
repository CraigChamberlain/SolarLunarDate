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

        public IList<DateTime> GetYear(ValidYear year)
        {   
            return StreamDeligate<IList<DateTime>>(
                year,
                Deserialize<List<DateTime>>
            );
        }

        public IList<DateTime> GetYear(string year){
            return GetYear((ValidYear)year);
        }

    }
}
