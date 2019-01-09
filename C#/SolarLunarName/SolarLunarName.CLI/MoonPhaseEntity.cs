using SQLite;
using System;

namespace SolarLunarName.Standard.Models
{
    class MoonPhaseEntity
    {
      
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public DateTime Date { get; set; }
            public Moon.MoonPhase Phase { get; set; }
        

    }
}
