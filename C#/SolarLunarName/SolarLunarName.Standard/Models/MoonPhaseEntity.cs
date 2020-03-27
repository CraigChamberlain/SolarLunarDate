using System;

namespace SolarLunarName.Standard.Models
{
    public class MoonPhaseEntity
    {
      
            public DateTime Date { get; set; }
            public DateTime FirstDay { get; set; }
            public DateTime LastDay { get; set; }
            public Moon.MoonPhase Phase { get; set; }
        
            public int Days { get; set; }

    }
}