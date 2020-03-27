using System;
using System.Collections.Generic;

namespace SolarLunarName.Standard.Types{

    public interface IMoonDataClient
    {
        IList<DateTime> GetYear(string year);
    }
}