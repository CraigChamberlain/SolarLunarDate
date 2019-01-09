using System;
using System.Management.Automation;

namespace SolarLunarName.PoSH
{
    [Cmdlet(VerbsCommon.Get, "SolarLunarName")]
    public class GetSolarLunarName : PSCmdlet
    {
        [Parameter(Position = 0, ValueFromPipeline = true)]
        public DateTime UtcDateTime { get; set; }

        protected override void EndProcessing()
        {
            var solarLunarName = new Standard.ApplicationServices.GetSolarLunarName(UtcDateTime);
            
            this.WriteObject(solarLunarName);
            base.EndProcessing();
        }
    }
}

