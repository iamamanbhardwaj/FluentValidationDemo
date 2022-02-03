using FluentValidation;

namespace FluentValidationDemo.Validator
{
    public class SomeExtraFiledsValidator : AbstractValidator<SomeExtraFileds>
    {
        public SomeExtraFiledsValidator()
        {
            RuleFor(x => x.Pivot).GreaterThan(0);
            RuleFor(x => x.Country).Must(s => Constants.CountryNames.Contains(s ?? string.Empty));
        }
    }

    public class SomeExtraFileds_Verion2_Validator : AbstractValidator<SomeExtraFileds>
    {
        public SomeExtraFileds_Verion2_Validator()
        {
            RuleFor(x => x.Pivot).LessThan(0);
            RuleFor(x => x.Country).Must(s => Constants.CountryNames.Any( cn=> (s?.ToUpper() ?? string.Empty) == cn.ToUpper() ));
        }
    }
}
