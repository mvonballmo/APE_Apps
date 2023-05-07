using Albums.DataContracts;
using System.Collections.Immutable;

namespace Albums.Services.Caching;

public interface IWeatherCache
{
    ValueTask<IImmutableList<WeatherForecast>> GetForecast(CancellationToken token);
}
