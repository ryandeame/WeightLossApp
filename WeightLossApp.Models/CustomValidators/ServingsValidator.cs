using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightLossApp.Models.CustomValidators
{
    internal class ServingsValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (value != null)
            {
                if(Convert.ToDouble(value) > 0.009)
                {
                    return null;
                }

                return new ValidationResult("Servings must be greater than 0.",
                    new[] { validationContext.MemberName });
            }
            return null;
        }
    }
}
