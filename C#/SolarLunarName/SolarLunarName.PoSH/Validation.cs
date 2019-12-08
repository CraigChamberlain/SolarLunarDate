using System.Management.Automation;
using System;


namespace SolarLunarName.PoSH
{
    static class Helper {
        internal static void IsValidYear(int Year, string Title, string VariableName){
            if( Year < 1700 || Year > 2083){
                throw new ArgumentOutOfRangeException(Title, VariableName+" must be between 1700 and 2083");
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
    

