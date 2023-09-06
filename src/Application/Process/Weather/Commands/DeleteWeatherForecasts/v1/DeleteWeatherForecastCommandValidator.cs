using FluentValidation;

namespace Application.Process.Weather.Commands.DeleteWeatherForecasts.v1;

public class DeleteWeatherForecastCommandValidator : AbstractValidator<DeleteWeatherForecastCommand>
{
    public DeleteWeatherForecastCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotNull().WithMessage("Id is reuired");
    }
}