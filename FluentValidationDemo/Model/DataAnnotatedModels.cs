using System.ComponentModel.DataAnnotations;

namespace FluentValidationDemo.Model
{
    public class WeatherForecast_Annotation
    {
        [Required]
        public DateTime? Date { get; set; }

        [Range(18, 60)]
        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        [CustomAttribute("Summary must start with 'Requested Weather is' sentence.")]
        public string? Summary { get; set; }
    }

    internal class CustomAttribute : ValidationAttribute
    {
        private string _message;

        public CustomAttribute(string message)
        {
            this._message = message;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value != null)
            {
         
                    var valueAsString = value.ToString();
                    if (!valueAsString.StartsWith("Requested Weather is"))
                    {
                        var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                        return new ValidationResult(errorMessage, new List<string> { validationContext.MemberName } );
                    }
             
            }
            return ValidationResult.Success;
        }
    }












    public class WeatherForecast_ValidatableObject : IValidatableObject
    {
        public DateTime? Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        public string? Summary { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Date == null)
            {
                yield return new ValidationResult("Date is null", new[] { nameof(Date) });
            }
            if (TemperatureC < 18 || TemperatureC > 60)
            {
                yield return new ValidationResult("TemperatureC is out of range", new[] { nameof(TemperatureC) });
            }
            if (Summary?.Trim()?
                .StartsWith("Requested Weather is ") ?? false)
            {
                yield return new ValidationResult("Summary must start with 'Requested Weather is' sentence.", new[] { nameof(Summary) });
            }
        }
    }
}
