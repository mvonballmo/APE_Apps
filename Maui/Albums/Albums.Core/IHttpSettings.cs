namespace Albums.Core;

public interface IHttpSettings
{
  public bool RequiresAuthentication { get; }

  public string Url { get; }
}