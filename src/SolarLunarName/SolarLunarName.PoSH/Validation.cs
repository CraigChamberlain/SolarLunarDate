using System.Management.Automation;
using System;
using SolarLunarName.SharedTypes.Constants;

namespace SolarLunarName.PoSH
{
    static class Helper {
        internal static void IsValidYear(int Year, string Title, string VariableName){
                    if (! Ranges.Year.InRange(Year))
                    {
                        throw new ArgumentOutOfRangeException(Title,
                            ($"{VariableName} must be {Ranges.Year.Min} and {Ranges.Year.Max}"));
                    }
        }
    }
    class ValidateDateTime:ValidateArgumentsAttribute {
        protected override void Validate(object arguments,EngineIntrinsics engineIntrinsics) {
            var date = (DateTime)arguments;
            Helper.IsValidYear(date.Year, "UtcDateTime", "UtcDateTime.Year"); 
            
        }
    }

    class ValidateYear:ValidateArgumentsAttribute {
        protected override void Validate(object arguments,EngineIntrinsics engineIntrinsics) {
            var year = (int)arguments;
            Helper.IsValidYear(year, "Year", "Year"); 
        }
    }

    class ValidateMonth:ValidateArgumentsAttribute {
        protected override void Validate(object arguments,EngineIntrinsics engineIntrinsics) {
            var month = (int)arguments;
            if (! Ranges.Month.InRange(month))
            {
                throw new ArgumentOutOfRangeException(Ranges.Month.Label,
                    ($"{Ranges.Month.Label} must be {Ranges.Month.Min} and {Ranges.Month.Max}"));
            }
            
        }
    }

    class ValidateDay:ValidateArgumentsAttribute {
        protected override void Validate(object arguments,EngineIntrinsics engineIntrinsics) {
            var day = (int)arguments;
            if (! Ranges.Day.InRange(day))
                {
                    throw new ArgumentOutOfRangeException(Ranges.Day.Label,
                        ($"{Ranges.Day.Label} must be {Ranges.Day.Min} and {Ranges.Day.Max}"));
                }
            
        }
    }
    
}

    

