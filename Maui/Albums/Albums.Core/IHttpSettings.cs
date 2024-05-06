namespace Albums.Core;

public interface IHttpSettings
{
  public bool RequiresAuthentication { get; set; }

  public string Url { get; }
  
  public string LoginUrl { get; }
}