using System.Net.Http.Json;
using Newtonsoft.Json;

namespace Albums.Core
{
  internal class AlbumManager : IAlbumManager
  {
    private readonly IHttpClientManager _httpClientManager;
    private readonly IHttpSettings _httpSettings;
    private readonly IAlbumFactory _albumFactory;

    public AlbumManager(IHttpClientManager httpClientManager, IHttpSettings httpSettings, IAlbumFactory albumFactory)
    {
      _httpClientManager = httpClientManager;
      _httpSettings = httpSettings;
      _albumFactory = albumFactory;
    }

    public async Task<IEnumerable<Part>> GetAll()
    {
      var client = await _httpClientManager.GetClient();
      var result = await client.GetStringAsync($"{_httpSettings.Url}parts");

      return JsonConvert.DeserializeObject<List<Part>>(result);
    }

    public async Task<Part> Add(string partName, string supplier, string partType)
    {
      var client = await _httpClientManager.GetClient();

      var part = _albumFactory.CreateAlbum(partName, supplier, partType);
      var msg = new HttpRequestMessage(HttpMethod.Post, $"{_httpSettings.Url}parts");

      msg.Content = JsonContent.Create(part);

      var response = await client.SendAsync(msg);
      response.EnsureSuccessStatusCode();

      var returnedJson = await response.Content.ReadAsStringAsync();

      var insertedPart = JsonConvert.DeserializeObject<Part>(returnedJson);

      return insertedPart;
    }

    public async Task Update(Part part)
    {
      var client = await _httpClientManager.GetClient();

      HttpRequestMessage msg = new(HttpMethod.Put, $"{_httpSettings.Url}parts/{part.PartID}");
      msg.Content = JsonContent.Create(part);

      var response = await client.SendAsync(msg);
      response.EnsureSuccessStatusCode();
    }

    public async Task Delete(string id)
    {
      var client = await _httpClientManager.GetClient();

      HttpRequestMessage msg = new(HttpMethod.Delete, $"{_httpSettings.Url}parts/{id}");
      var response = await client.SendAsync(msg);
      response.EnsureSuccessStatusCode();
    }
  }
}