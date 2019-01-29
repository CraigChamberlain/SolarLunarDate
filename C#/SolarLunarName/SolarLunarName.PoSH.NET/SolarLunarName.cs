using System;
using System.Linq;
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
            //path to sqlite file in manifest
            string path = MyInvocation.MyCommand.Module.FileList.First();

            var dI = new Standard.ApplicationServices.DateInterpreter();
            var solarLunarName = dI.GetSolarLunarName(UtcDateTime, path);
            
            this.WriteObject(solarLunarName);
            base.EndProcessing();
        }
    }
}

