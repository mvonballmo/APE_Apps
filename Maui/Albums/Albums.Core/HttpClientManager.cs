using Newtonsoft.Json;

namespace Albums.Core;

internal class HttpClientManager : IHttpClientManager
{
  private readonly IHttpSettings _httpSettings;
  private readonly IConnectivityChecker _connectivityChecker;
  private static string? _authorizationKey;
  private static HttpClient? _client;

  public HttpClientManager(IHttpSettings httpSettings, IConnectivityChecker connectivityChecker)
  {
    _httpSettings = httpSettings;
    _connectivityChecker = connectivityChecker;
  }

  public async Task<HttpClient> GetClient()
  {
    if (!_connectivityChecker.Connected)
    {
      throw new InvalidOperationException("Network is unavailable.");
    }

    if (_client != null)
    {
      return _client;
    }

    _client = new HttpClient();
    _client.DefaultRequestHeaders.Add("Accept", "application/json");

    if (_httpSettings.RequiresAuthentication)
    {
      if (string.IsNullOrEmpty(_authorizationKey))
      {
        _authorizationKey = await _client.GetStringAsync($"{_httpSettings.LoginUrl}");
        _authorizationKey = JsonConvert.DeserializeObject<string>(_authorizationKey);
      }

      _client.DefaultRequestHeaders.Add("Authorization", _authorizationKey);
    }

    return _client;
  }
}