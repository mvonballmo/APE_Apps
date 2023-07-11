using System.Net.Http.Json;
using Newtonsoft.Json;

namespace Albums.Core;

internal class DataItemManager<T> : IDataItemManager<T>
{
  private readonly IHttpClientManager _httpClientManager;
  private readonly IDataItemTools<T> _dataItemTools;

  protected DataItemManager(IHttpClientManager httpClientManager, IDataItemTools<T> dataItemTools)
  {
    _httpClientManager = httpClientManager;
    _dataItemTools = dataItemTools;
  }

  public async Task<IEnumerable<T>> GetAll()
  {
    var client = await _httpClientManager.GetClient();
    var result = await client.GetStringAsync(_dataItemTools.GetAllUrl());

    return DeserializeObject<IEnumerable<T>>(result);
  }

  private static TTarget DeserializeObject<TTarget>(string data)
  {
    return JsonConvert.DeserializeObject<TTarget>(data) ?? throw new InvalidOperationException("Deserializing JSON returned null.");
  }

  public async Task<T> Add(T item)
  {
    var client = await _httpClientManager.GetClient();

    var msg = new HttpRequestMessage(HttpMethod.Post, _dataItemTools.GetAddUrl());

    msg.Content = JsonContent.Create(item);

    var response = await client.SendAsync(msg);
    response.EnsureSuccessStatusCode();

    var returnedJson = await response.Content.ReadAsStringAsync();

    return DeserializeObject<T>(returnedJson);
  }

  public async Task Update(T part)
  {
    var client = await _httpClientManager.GetClient();

    HttpRequestMessage msg = new(HttpMethod.Put, _dataItemTools.GetUpdateUrl(part));
    msg.Content = JsonContent.Create(part);

    var response = await client.SendAsync(msg);
    response.EnsureSuccessStatusCode();
  }

  public async Task Delete(string id)
  {
    var client = await _httpClientManager.GetClient();

    HttpRequestMessage msg = new(HttpMethod.Delete, _dataItemTools.GetDeleteUrl(id));
    var response = await client.SendAsync(msg);
    response.EnsureSuccessStatusCode();
  }
}