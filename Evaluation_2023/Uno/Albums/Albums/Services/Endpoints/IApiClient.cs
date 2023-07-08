using System.Collections.Immutable;
using Albums.DataContracts;

namespace Albums.Services.Endpoints;

[Headers("Content-Type: application/json")]
public interface IApiClient
{
	[Get("/api/weatherforecast")]
	Task<ApiResponse<IImmutableList<WeatherForecast>>> GetWeather(CancellationToken cancellationToken = default);
}
