using System;

namespace SolarLunarName.Standard.Models
{
    public class MoonPhaseEntity
    {
      
            public int Id { get; set; }
            public DateTime Date { get; set; }
            public Moon.MoonPhase Phase { get; set; }
        

    }
}
