using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finhub.Core.Attributes
{
    public class MinDateAttribute : ValidationAttribute
    {
        private DateTime _minTime = DateTime.Parse("2000-01-01");
        private readonly string DEFAULT_ERROR_MESSAGE = "{0} should not be older than {1}";

        public MinDateAttribute(string date, string? errorMessage) {
            DateTime dt = _minTime;
            _minTime = DateTime.TryParse(date, out dt) ? dt : _minTime;
            ErrorMessage = errorMessage ?? DEFAULT_ERROR_MESSAGE;
        }

        public MinDateAttribute(string errorMessage) : base(errorMessage)
        {
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessage ?? DEFAULT_ERROR_MESSAGE; //redundant but removes that annoying warning
            if (value == null) {
                return new ValidationResult(
                    String.Format(ErrorMessage, validationContext.DisplayName, _minTime.ToString() )
                );
            }
            DateTime time = (DateTime) value;
            if ( time < _minTime )
            {
                return new ValidationResult(
                    String.Format(ErrorMessage, validationContext.DisplayName, _minTime.ToString() )
                );
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
