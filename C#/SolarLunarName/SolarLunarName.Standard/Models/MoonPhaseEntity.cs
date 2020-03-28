using System;
using Newtonsoft.Json;

namespace SolarLunarName.Standard.Models
{
    public class MoonPhaseEntity
    {
        public MoonPhaseEntity(DateTime date, DateTime firstDay, DateTime lastDay, Moon.MoonPhase phase, int days)
        {

            Date = date;
            FirstDay = firstDay;
            LastDay = lastDay;
            Phase = phase;
            Days = days;
        }


            [JsonProperty("DateTime")]
            public DateTime Date { get; set; }
            public DateTime FirstDay { get; set; }
            public DateTime LastDay { get; set; }
            public Moon.MoonPhase Phase { get; set; }
        
            public int Days { get; set; }

    }
}