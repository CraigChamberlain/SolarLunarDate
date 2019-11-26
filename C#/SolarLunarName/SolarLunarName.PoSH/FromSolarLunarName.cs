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

        protected static void IsValidYear(int Year, string Title, string VariableName){
            if( Year < 1700 || Year > 2083){
                throw new ArgumentOutOfRangeException(Title, VariableName+" must be between 1700 and 2083");
            }

        }


        class ValidateYear:ValidateArgumentsAttribute {
        protected override void Validate(object arguments,EngineIntrinsics engineIntrinsics) {
            var year = (int)arguments;
            IsValidYear(year, "Year", "Year"); 
            
        }
        }

        class ValidateMonth:ValidateArgumentsAttribute {
        protected override void Validate(object arguments,EngineIntrinsics engineIntrinsics) {
            var month = (int)arguments;
            if( month < 0 || month > 13){
                throw new ArgumentOutOfRangeException("Month", "Month must be between 0 and 13");
            }
            
        }
        }

        class ValidateDay:ValidateArgumentsAttribute {
        protected override void Validate(object arguments,EngineIntrinsics engineIntrinsics) {
            var day = (int)arguments;
            if( day < 1 || day > 31){
                throw new ArgumentOutOfRangeException("Day", "Day must be between 1 and 31");
            }
            
        }
        }
    }
}
    

