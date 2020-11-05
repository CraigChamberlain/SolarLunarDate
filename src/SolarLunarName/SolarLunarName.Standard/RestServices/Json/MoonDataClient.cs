using System;
using System.Collections.Generic;
using SolarLunarName.SharedTypes.Interfaces;
using System.IO;

namespace SolarLunarName.Standard.RestServices.Json
{

    public abstract class MoonDataClient : IMoonDataClient
    {

        protected IList<DateTime> GetYear(string year, Stream s)
        {
            SolarLunarName.SharedTypes.Validation.Helpers.ValidateYear(year);
            return Helpers.Deserialize<List<DateTime>>(s);
        }
        public abstract IList<DateTime> GetYear(string year);

    }
}
