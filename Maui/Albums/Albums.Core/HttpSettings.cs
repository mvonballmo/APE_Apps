namespace Albums.Core;

internal class HttpSettings : IHttpSettings
{
  private const string BaseAddress = "http://localhost:3000";

  public bool RequiresAuthentication { get; set; }

  public string Url => $"{BaseAddress}/";

  public string LoginUrl => $"{Url}/login";
}