using FluentValidation;

namespace Application.Process.Weather.Commands.CreateWeatherForcasts.v1;

public class CreateWeatherForecastCommandValidator : AbstractValidator<CreateWeatherForcastCommand>
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


    public CreateWeatherForecastCommandValidator()
    {
        RuleFor(v => v.Date)
            .GreaterThan(DateTime.MinValue).WithMessage("Date is required.")
        .MustAsync(BeUniqueDate).WithMessage("The specified date already exists.");

        RuleFor(v => v.TemperatureC).LessThan(100).WithMessage("TemperatureC must les than 100.");

        RuleFor(v => v.Summaries)
            .NotEmpty().WithMessage("Summaries is required.")
            .Must(x => Summaries.Contains(x)).WithMessage("Please only use: " + string.Join(",", Summaries));
    }

    private Task<bool> BeUniqueDate(DateTime date, CancellationToken cancellation)
    {
        return Task.FromResult(true);
    }

}
