using FluentValidationDemo;
using NUnit.Framework;
using FluentValidation.TestHelper;
using FluentValidationDemo.Validator;
using FluentValidationDemo.Model;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class TestDemo
{
    private WeatherForecastv2Validator validator;

    [SetUp]
    public void Setup()
    {
        validator = new WeatherForecastv2Validator();
    }

    [Test]
    public void Test_With_for_Annotation()
    {
        var weatherForecast_Annotation_model = new WeatherForecast_Annotation { Summary = "wrong summary" };
    
        Assert.IsTrue(ValidateModel(weatherForecast_Annotation_model).Any(
            v => v.MemberNames.Contains("Summary")));

    }

    private IList<System.ComponentModel.DataAnnotations.ValidationResult> ValidateModel(object model)
    {
        var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
        var ctx = new System.ComponentModel.DataAnnotations.ValidationContext(model, null, null);
        System.ComponentModel.DataAnnotations.Validator.TryValidateObject(model, ctx, validationResults, true);
        return validationResults;
    }


    [Test]
    public void Test1()
    {
        var model = new WeatherForecastv2 {  Summary = "wrong summary"};
        var result = validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(obj => obj.Summary);
        Assert.IsFalse(result.IsValid);

    }

    [Test]
    public void Test2()
    {
        var model = new WeatherForecastv2 { TemperatureC = -1 };
        var result = validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(obj => obj.TemperatureC);
    }

    [Test]
    public void Test3()
    {
        var model = new WeatherForecastv2 { TemperatureC = 50 };
        var result = validator.TestValidate(model);
        //result.ShouldHaveValidationErrorFor(obj => obj.TemperatureC);

        result.ShouldNotHaveValidationErrorFor(obj => obj.TemperatureC);

        result.ShouldNotHaveValidationErrorFor(obj => obj.TemperatureC);

    }
}