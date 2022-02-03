using FluentValidation;

namespace FluentValidationDemo.Validator
{
    public class WeatherForecastv2Validator
         : AbstractValidator<WeatherForecastv2>
    {
        public WeatherForecastv2Validator()
        {
            RuleFor(x => x.Date).NotNull();

            RuleFor(x => x.TemperatureC).InclusiveBetween(18, 60);

            RuleFor(x => x.Summary).Must((summary) => summary?.Trim()?
                .StartsWith("Requested Weather is ") ?? false)
                .WithMessage("Summary must start with 'Requested Weather is' sentence.");

            RuleFor(s => s.SomeExtraFileds).SetValidator(new SomeExtraFiledsValidator());
            //RuleFor(s => s.SomeExtraFileds).SetValidator(new SomeExtraFileds_Verion2_Validator());

        }
    }
}
