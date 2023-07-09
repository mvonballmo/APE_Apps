namespace Albums.Core;

public interface IHttpClientManager
{
  Task<HttpClient> GetClient();
}