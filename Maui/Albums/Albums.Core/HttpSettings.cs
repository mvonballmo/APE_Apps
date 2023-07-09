namespace Albums.Core;

internal class HttpSettings : IHttpSettings
{
  private const string BaseAddress = "https://localhost:3000";

  public string Url { get; } = $"{BaseAddress}/api/";
}