using System.Net.Http.Json;
using Newtonsoft.Json;
using PartsClient.Data;

namespace Albums.Core
{
  public class AlbumManager : IAlbumManager
  {
    private readonly IHttpClientManager _httpClientManager;
    private readonly IHttpSettings _httpSettings;
    private readonly IConnectivityChecker _connectivityChecker;
    private readonly IAlbumFactory _albumFactory;

    public AlbumManager(IHttpClientManager httpClientManager, IHttpSettings httpSettings, IConnectivityChecker connectivityChecker, IAlbumFactory albumFactory)
    {
      _httpClientManager = httpClientManager;
      _httpSettings = httpSettings;
      _connectivityChecker = connectivityChecker;
      _albumFactory = albumFactory;
    }

    public async Task<IEnumerable<Part>> GetAll()
    {
      if (!IsConnected())
        return new List<Part>();

      var client = await _httpClientManager.GetClient();
      var result = await client.GetStringAsync($"{_httpSettings.Url}parts");

      return JsonConvert.DeserializeObject<List<Part>>(result);
    }

    public async Task<Part> Add(string partName, string supplier, string partType)
    {
      if (!IsConnected())
        return new Part();

      var part = _albumFactory.CreateAlbum(partName, supplier, partType);
      var msg = new HttpRequestMessage(HttpMethod.Post, $"{_httpSettings.Url}parts");

      msg.Content = JsonContent.Create<Part>(part);

      var client = await _httpClientManager.GetClient();
      var response = await client.SendAsync(msg);
      response.EnsureSuccessStatusCode();

      var returnedJson = await response.Content.ReadAsStringAsync();

      var insertedPart = JsonConvert.DeserializeObject<Part>(returnedJson);

      return insertedPart;
    }

    public async Task Update(Part part)
    {
      if (!IsConnected())
        return;

      HttpRequestMessage msg = new(HttpMethod.Put, $"{_httpSettings.Url}parts/{part.PartID}");
      msg.Content = JsonContent.Create<Part>(part);
      var client = await _httpClientManager.GetClient();
      var response = await client.SendAsync(msg);
      response.EnsureSuccessStatusCode();
    }

    public async Task Delete(string partId)
    {
      if (!IsConnected())
        return;
      HttpRequestMessage msg = new(HttpMethod.Delete, $"{_httpSettings.Url}parts/{partId}");
      var client = await _httpClientManager.GetClient();
      var response = await client.SendAsync(msg);
      response.EnsureSuccessStatusCode();
    }

    private bool IsConnected()
    {
      return _connectivityChecker.Connected;
    }
  }
}