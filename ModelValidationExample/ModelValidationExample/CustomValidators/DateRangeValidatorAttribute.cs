﻿using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelValidationExample.CustomValidators
{
    public class DateRangeValidatorAttribute : ValidationAttribute
    {
        public string OtherPropertyName { get; set; }
        public DateRangeValidatorAttribute(string otherPropertyName)
        {
            OtherPropertyName = otherPropertyName;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            
            if (value != null)
            {
                DateTime toDate = Convert.ToDateTime(value);
                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);

                if (otherProperty != null)
                {
                    DateTime fromDate = Convert.ToDateTime(otherProperty.GetValue(validationContext.ObjectInstance));

                    if (fromDate > toDate)
                    {
                        return new ValidationResult(ErrorMessage, new string[] { OtherPropertyName, validationContext.MemberName });
                    }
                    return ValidationResult.Success;
                }

                
            }
            return null;
        }
    }
}
