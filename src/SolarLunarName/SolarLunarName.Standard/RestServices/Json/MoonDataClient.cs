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

        // TODO Delete method in version 1.0.0
        [Obsolete("This Overload is being deprecated in version 1.0.0 cast string to ValidYear")]
        public IList<DateTime> GetYear(string year){
            return GetYear((ValidYear)year);
        }

    }
}
