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
            string path = @"C:\Users\Craig\Documents\LunarSolarDate\C#\SolarLunarName\SolarLunarName.PoSH\bin\Debug\netstandard2.0\assets\MoonPhase.sqlite";
            //this.WriteObject(path);
            var solarLunarName = new Standard.ApplicationServices.GetSolarLunarName(UtcDateTime, path);
            
            this.WriteObject(solarLunarName);
            base.EndProcessing();
        }
    }
}

