using System;
using System.Management.Automation;
using SolarLunarName.Standard.ApplicationServices;

namespace SolarLunarName.PoSH
{
    [Cmdlet(VerbsCommon.Get, "SolarLunarName", DefaultParameterSetName="typed")]
    public class GetSolarLunarName : PSCmdlet
    {   
        [Parameter(ParameterSetName="dateTime", Position = 0, ValueFromPipeline = true, Mandatory = true)]
        [ValidateDateTime()]
        public DateTime UtcDateTime { get; set; }

        [Parameter(ParameterSetName="typed", Position = 0)]
        [ValidateYear()]
        public int Year { get; set; }

        [Parameter(ParameterSetName="typed", Position = 1)]
        [ValidateMonth()]
        public int Month  { get; set; }

        [Parameter(ParameterSetName="typed", Position = 2)]
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

        protected static void IsValidYear(int Year, string Title, string VariableName){
            if( Year < 1700 || Year > 2083){
                throw new ArgumentOutOfRangeException(Title, VariableName+" must be between 1700 and 2083");
            }

        }


        class ValidateDateTime:ValidateArgumentsAttribute {
        protected override void Validate(object arguments,EngineIntrinsics engineIntrinsics) {
            var date = (DateTime)arguments;
            IsValidYear(date.Year, "UtcDateTime", "UtcDateTime.Year"); 
            
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
            if( month < 1 || month > 12){
                throw new ArgumentOutOfRangeException("Month", "Month must be between 1 and 12");
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
    

