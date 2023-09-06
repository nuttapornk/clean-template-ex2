using Application.Common.Helpers;
using FluentValidation;

namespace Application.Process.Weather.Commands.CreateWeatherForecasts.v1;

public class CreateWeatherForecastCommandValidator : AbstractValidator<CreateWeatherForecastCommand>
{
    public CreateWeatherForecastCommandValidator()
    {
        RuleFor(v => v.Date)
            .GreaterThan(DateTime.MinValue).WithMessage("Date is required.")
            .MustAsync(BeUniqueDate).WithMessage("The specified date already exists.");

        RuleFor(v => v.TemperatureC)
            .LessThan(100).WithMessage("TemperatureC must les than 100.");

        RuleFor(v => v.Summaries)
            .NotEmpty().WithMessage("Summaries is required.")
            .Must(x => WeatherForecastHelper.Summaries.Contains(x))
            .WithMessage("Please only use: " + string.Join(",", WeatherForecastHelper.Summaries));
    }

    private Task<bool> BeUniqueDate(DateTime date, CancellationToken cancellation)
    {
        return Task.FromResult(true);
    }

}
