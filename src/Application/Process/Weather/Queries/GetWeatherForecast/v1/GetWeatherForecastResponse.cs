namespace Application.Process.Weather.Queries.GetWeatherForecast.v1;
public class GetWeatherForecastResponse
{
    public DateTime Date { get; set; }
    public int TemperatureC { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    public string? Sumrry { get; set; }
}