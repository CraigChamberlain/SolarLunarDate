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
            string path = @"/assets/MoonPhase.sqlite";
            //this.WriteObject(path);
            var interpreter = new Standard.ApplicationServices.DateInterpreter();
            var solarLunarName = interpreter.GetSolarLunarName(UtcDateTime, path);
            
            this.WriteObject(solarLunarName);
            base.EndProcessing();
        }
    }
}

