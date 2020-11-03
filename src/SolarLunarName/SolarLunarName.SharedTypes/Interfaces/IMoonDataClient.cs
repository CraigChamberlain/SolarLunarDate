using System;
using System.Collections.Generic;

namespace SolarLunarName.SharedTypes.Interfaces{

    public interface IMoonDataClient
    {
        IList<DateTime> GetYear(string year);
    }
}