﻿using System;
using System.Management.Automation;
using SolarLunarName.Standard.ApplicationServices;

namespace SolarLunarName.PoSH
{
    [Cmdlet(VerbsCommon.Get, "SolarLunarName", DefaultParameterSetName="typed")]
    public class GetSolarLunarName : PSCmdlet
    {   
        [Parameter(ParameterSetName="dateTime", Position = 0, ValueFromPipeline = true, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateDateTime()]
        public DateTime UtcDateTime { get; set; }

        [Parameter(ParameterSetName="typed", Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateYear()]
        public int Year { get; set; }

        [Parameter(ParameterSetName="typed", Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateMonth()]
        public int Month  { get; set; }

        [Parameter(ParameterSetName="typed", Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateDay()]
        public int Day  { get; set; }

        protected override void ProcessRecord()
        {
            if(this.ParameterSetName != "dateTime")
            {   
                var now = DateTime.Now;
                if (Year == 0 ) Year = now.Year;
                if (Month == 0 ) Month = now.Month;
                if (Day == 0 ) Day = now.Day;
                UtcDateTime = new DateTime(Year, Month, Day);
            }

            var di = new DateInterpreter();
            var solarLunarName = di.GetRemoteSolarLunarName(UtcDateTime);

            this.WriteObject(solarLunarName);
            base.EndProcessing();
        }

    }
}
    

