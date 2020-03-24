using System;
using System.Collections.Generic;

namespace SolarLunarName.Standard.Types{

    public interface IMoonDataClient
    {
        List<DateTime> GetYear(string year);
    }
}