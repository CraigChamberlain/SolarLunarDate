using System;
using System.Collections.Generic;
using SolarLunarName.SharedTypes.Primitives;

namespace SolarLunarName.SharedTypes.Interfaces{

    public interface IMoonDataClient
    {   
        // TODO Delete method in version 1.0.0
        [Obsolete("This Overload is being deprecated in version 1.0.0 cast string to ValidYear")]
        IList<DateTime> GetYear(string year);
        
        IList<DateTime> GetYear(ValidYear year);
    }
}