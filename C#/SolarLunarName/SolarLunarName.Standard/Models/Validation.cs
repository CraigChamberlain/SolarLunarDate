using System.ComponentModel.DataAnnotations;
using System;


namespace SolarLunarName.Standard.Models
{
    class ValidateDateTime:ValidationAttribute {

        protected override ValidationResult
                    IsValid(object value, ValidationContext validationContext)
            {   
                DateTime _gregorianDate = Convert.ToDateTime(value); 
                if (_gregorianDate.Year < 1700 || _gregorianDate.Year > 2082)
                {
                    return new ValidationResult
                        ("Datetime must be between 1700 and 2082");}
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
                if (_year < 1700 || _year > 2081)
                {
                    return new ValidationResult
                        ("Year must be between 1700 and 2081");}
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
                if (_month < 0 || _month > 13)
                {
                    return new ValidationResult
                        ("Month must be between 0 and 13");}
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
                if ( _day < 1 || _day > 31)
                {
                    return new ValidationResult
                        ("Day must be between 1 and 31");}
                else
                {
                    return ValidationResult.Success;
               
                }
            }   
    }

    
}
    

