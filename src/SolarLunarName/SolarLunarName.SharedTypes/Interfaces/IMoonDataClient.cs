using System;
using System.Collections.Generic;
using SolarLunarName.SharedTypes.Primitives;

namespace SolarLunarName.SharedTypes.Interfaces{

    public interface IMoonDataClient
    {
        //N.B Must write warning in compiler and release major version if remove string version of method
        IList<DateTime> GetYear(string year);
        IList<DateTime> GetYear(ValidYear year);
    }
}