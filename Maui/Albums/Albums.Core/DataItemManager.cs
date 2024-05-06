using System.Net.Http.Json;
using Newtonsoft.Json;

namespace Albums.Core;

internal class DataItemManager<T, TIdentifier> : IDataItemManager<T, TIdentifier>
{
  private readonly IHttpClientManager _httpClientManager;
  private readonly IDataItemTools<T, TIdentifier> _tools;

  protected DataItemManager(IHttpClientManager httpClientManager, IDataItemTools<T, TIdentifier> tools)
  {
    _httpClientManager = httpClientManager;
    _tools = tools;
  }

  public async Task<IEnumerable<T>> GetAll()
  {
    var client = await _httpClientManager.GetClient();
    var result = await client.GetStringAsync(_tools.GetAllUrl());

    return DeserializeObject<IEnumerable<T>>(result);
  }

  private static TTarget DeserializeObject<TTarget>(string data)
  {
    return JsonConvert.DeserializeObject<TTarget>(data) ?? throw new InvalidOperationException("Deserializing JSON returned null.");
  }

  public async Task<T> Add(T item)
  {
    var client = await _httpClientManager.GetClient();

    var msg = new HttpRequestMessage(HttpMethod.Post, _tools.GetAddUrl());

    msg.Content = JsonContent.Create(item);

    var response = await client.SendAsync(msg);
    response.EnsureSuccessStatusCode();

    var returnedJson = await response.Content.ReadAsStringAsync();

    return DeserializeObject<T>(returnedJson);
  }

  public async Task Update(T part)
  {
    var client = await _httpClientManager.GetClient();

    HttpRequestMessage msg = new(HttpMethod.Put, _tools.GetUpdateUrl(part));
    msg.Content = JsonContent.Create(part);

    var response = await client.SendAsync(msg);
    response.EnsureSuccessStatusCode();
  }

  public async Task Delete(TIdentifier id)
  {
    var client = await _httpClientManager.GetClient();

    HttpRequestMessage msg = new(HttpMethod.Delete, _tools.GetDeleteUrl(id));
    var response = await client.SendAsync(msg);
    response.EnsureSuccessStatusCode();
  }
}