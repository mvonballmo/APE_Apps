using System.Net.Http.Json;
using Newtonsoft.Json;
using PartsClient.Data;

namespace Albums.Core
{
  public static class AlbumManager
  {
    private const string BaseAddress = "https://localhost:3000";
    private const string Url = $"{BaseAddress}/api/";
    private static string? _authorizationKey;

    static HttpClient? _client;

    private static async Task<HttpClient> GetClient()
    {
      if (_client != null)
        return _client;

      _client = new HttpClient();

      if (string.IsNullOrEmpty(_authorizationKey))
      {
        _authorizationKey = await _client.GetStringAsync($"{Url}login");
        _authorizationKey = JsonConvert.DeserializeObject<string>(_authorizationKey);
      }

      _client.DefaultRequestHeaders.Add("Authorization", _authorizationKey);
      _client.DefaultRequestHeaders.Add("Accept", "application/json");

      return _client;
    }

    public static async Task<IEnumerable<Part>> GetAll()
    {
      if (!IsConnected())
        return new List<Part>();

      var client = await GetClient();
      var result = await client.GetStringAsync($"{Url}parts");

      return JsonConvert.DeserializeObject<List<Part>>(result);
    }

    public static async Task<Part> Add(string partName, string supplier, string partType)
    {
      if (!IsConnected())
        return new Part();

      var part = new Part()
      {
        PartName = partName,
        Suppliers = new List<string>(new[]
        {
          supplier
        }),
        PartID = string.Empty,
        PartType = partType,
        PartAvailableDate = DateTime.Now.Date
      };

      var msg = new HttpRequestMessage(HttpMethod.Post, $"{Url}parts");

      msg.Content = JsonContent.Create<Part>(part);

      var response = await _client.SendAsync(msg);
      response.EnsureSuccessStatusCode();

      var returnedJson = await response.Content.ReadAsStringAsync();

      var insertedPart = JsonConvert.DeserializeObject<Part>(returnedJson);

      return insertedPart;
    }

    public static async Task Update(Part part)
    {
      if (!IsConnected())
        return;

      HttpRequestMessage msg = new(HttpMethod.Put, $"{Url}parts/{part.PartID}");
      msg.Content = JsonContent.Create<Part>(part);
      var client = await GetClient();
      var response = await client.SendAsync(msg);
      response.EnsureSuccessStatusCode();
    }

    public static async Task Delete(string partId)
    {
      if (!IsConnected())
        return;
      HttpRequestMessage msg = new(HttpMethod.Delete, $"{Url}parts/{partId}");
      var client = await GetClient();
      var response = await client.SendAsync(msg);
      response.EnsureSuccessStatusCode();
    }

    private static bool IsConnected()
    {
      return Connectivity.Current.NetworkAccess != NetworkAccess.Internet;
    }
  }
}