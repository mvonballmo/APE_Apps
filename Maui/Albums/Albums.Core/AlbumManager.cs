using System.Net.Http.Json;
using Newtonsoft.Json;

namespace Albums.Core
{
  internal class AlbumManager : IAlbumManager
  {
    private readonly IHttpClientManager _httpClientManager;
    private readonly IAlbumTools _albumTools;

    public AlbumManager(IHttpClientManager httpClientManager, IAlbumTools albumTools)
    {
      _httpClientManager = httpClientManager;
      _albumTools = albumTools;
    }

    public async Task<IEnumerable<Part>> GetAll()
    {
      var client = await _httpClientManager.GetClient();
      var result = await client.GetStringAsync(_albumTools.GetAllUrl());

      return JsonConvert.DeserializeObject<List<Part>>(result);
    }

    public async Task<Part> Add(string partName, string supplier, string partType)
    {
      var client = await _httpClientManager.GetClient();

      var value = _albumTools.CreateAlbum(partName, supplier, partType);
      var msg = new HttpRequestMessage(HttpMethod.Post, _albumTools.GetAddUrl());

      msg.Content = JsonContent.Create(value);

      var response = await client.SendAsync(msg);
      response.EnsureSuccessStatusCode();

      var returnedJson = await response.Content.ReadAsStringAsync();

      var insertedPart = JsonConvert.DeserializeObject<Part>(returnedJson);

      return insertedPart;
    }

    public async Task Update(Part part)
    {
      var client = await _httpClientManager.GetClient();

      HttpRequestMessage msg = new(HttpMethod.Put, _albumTools.GetUpdateUrl(part));
      msg.Content = JsonContent.Create(part);

      var response = await client.SendAsync(msg);
      response.EnsureSuccessStatusCode();
    }

    public async Task Delete(string id)
    {
      var client = await _httpClientManager.GetClient();

      HttpRequestMessage msg = new(HttpMethod.Delete, _albumTools.GetDeleteUrl(id));
      var response = await client.SendAsync(msg);
      response.EnsureSuccessStatusCode();
    }
  }
}