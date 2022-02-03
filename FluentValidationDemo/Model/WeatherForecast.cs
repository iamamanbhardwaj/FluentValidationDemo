using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace FluentValidationDemo
{
    public class WeatherForecastBase
    {   
        public DateTime? Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        public string? Summary { get; set; }
    }
  
    
    public class WeatherForecastv2 : WeatherForecastBase
    {
        public SomeExtraFileds SomeExtraFileds { get; set; }
    }


    public class SomeExtraFileds
    {
        public int Pivot { get; set; }
        public string? Country { get; set; }

    }


   
}