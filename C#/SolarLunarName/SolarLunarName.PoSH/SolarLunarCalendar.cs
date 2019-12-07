using System;
using System.Management.Automation;

namespace SolarLunarName.PoSH
{
    [Cmdlet(VerbsCommon.Get, "SolarLunarCalendar", DefaultParameterSetName="year")]
    public class GetSolarLunarCalendar : PSCmdlet
    {   
        [Parameter(Position = 0, Mandatory=true)]
        [ValidateYear()]
        public int Year { get; set; }

        [Parameter(ParameterSetName="month", Position = 1, Mandatory=true)]
        [ValidateMonth()]
        public int Month  { get; set; }


        protected override void ProcessRecord()
        {   
                 
            if(this.ParameterSetName == "year")
            {   
                var data = SolarLunarName.Standard.Models.SolarLunarName.MonthsInYear(Year);
                this.WriteObject(data);
            }
            else{

                var data = SolarLunarName.Standard.Models.SolarLunarName.DaysInMonth(Year, Month);
                this.WriteObject(data);
            }
            
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
            if( month < 1 || month > 12){
                throw new ArgumentOutOfRangeException("Month", "Month must be between 1 and 12");
            }
            
        }
        }

    }
}
    

