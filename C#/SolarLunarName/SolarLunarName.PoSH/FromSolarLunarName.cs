using System;
using System.Management.Automation;
using SolarLunarName.Standard.ApplicationServices;

namespace SolarLunarName.PoSH
{
    [Cmdlet(VerbsData.ConvertFrom, "SolarLunarName")]
    public class ConvertFromSolarLunarName : PSCmdlet
    {   

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateYear()]
        public int Year { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateMonth()]
        public int Month  { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateDay()]
        public int Day  { get; set; }

        protected override void ProcessRecord()
        {
            var di = new DateInterpreter();
            var solarLunarName = di.ConvertSolarLunarName(Year, Month, Day);

            this.WriteObject(solarLunarName);
            base.EndProcessing();
        }
    }
}
    

