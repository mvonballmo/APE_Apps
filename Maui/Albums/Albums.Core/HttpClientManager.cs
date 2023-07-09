using Newtonsoft.Json;

namespace Albums.Core;

internal class HttpClientManager : IHttpClientManager
{
  private readonly IHttpSettings _httpSettings;
  private static string? _authorizationKey;
  private static HttpClient? _client;

  public HttpClientManager(IHttpSettings httpSettings)
  {
    _httpSettings = httpSettings;
  }

  public async Task<HttpClient> GetClient()
  {
    if (_client != null)
      return _client;

    _client = new HttpClient();

    if (string.IsNullOrEmpty(_authorizationKey))
    {
      _authorizationKey = await _client.GetStringAsync($"{_httpSettings.Url}login");
      _authorizationKey = JsonConvert.DeserializeObject<string>(_authorizationKey);
    }

    _client.DefaultRequestHeaders.Add("Authorization", _authorizationKey);
    _client.DefaultRequestHeaders.Add("Accept", "application/json");

    return _client;
  }
}