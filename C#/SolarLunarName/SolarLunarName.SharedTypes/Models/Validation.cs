using System.ComponentModel.DataAnnotations;
using System;
using SolarLunarName.SharedTypes.Constants;

namespace SolarLunarName.SharedTypes.Models
{
    class ValidateDateTime:ValidationAttribute {

        protected override ValidationResult
                    IsValid(object value, ValidationContext validationContext)
            {   
                DateTime _gregorianDate = Convert.ToDateTime(value); 
                if (! Ranges.Year.InRange(_gregorianDate.Year))
                {
                    return new ValidationResult
                        ($"Datetime must be between {Ranges.Year.Min} and {Ranges.Year.Max}");}
                else
                {
                    return ValidationResult.Success;
               
                }
            }   
    }

    class ValidateYear:ValidationAttribute {

        protected override ValidationResult
                    IsValid(object value, ValidationContext validationContext)
            {   
                int _year = Convert.ToInt16(value); 
                if (! Ranges.Year.InRange(_year))
                {
                    return new ValidationResult
                        ($"{Ranges.Year.Label} must be {Ranges.Year.Min} and {Ranges.Year.Max}");}
                else
                {
                    return ValidationResult.Success;
               
                }
            }   
    }
    class ValidateMonth:ValidationAttribute {

        protected override ValidationResult
                    IsValid(object value, ValidationContext validationContext)
            {   
                int _month = Convert.ToInt16(value); 
                if (! Ranges.Month.InRange(_month))
                {
                    return new ValidationResult
                        ($"{Ranges.Month.Label} must be {Ranges.Month.Min} and {Ranges.Month.Max}");}
                else
                {
                    return ValidationResult.Success;
               
                }
            }   
    }
     class ValidateDay:ValidationAttribute {

        protected override ValidationResult
                    IsValid(object value, ValidationContext validationContext)
            {   
                int _day = Convert.ToInt16(value); 
                if (! Ranges.Day.InRange(_day))
                {
                    return new ValidationResult
                        ($"{Ranges.Day.Label} must be {Ranges.Day.Min} and {Ranges.Day.Max}");}
                else
                {
                    return ValidationResult.Success;
               
                }
            }   
    }

    
}
    

