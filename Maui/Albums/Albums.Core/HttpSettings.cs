namespace Albums.Core;

internal class HttpSettings : IHttpSettings
{
  private const string BaseAddress = "http://localhost:3000";

  public bool RequiresAuthentication => false;

  public string Url => $"{BaseAddress}/";
}