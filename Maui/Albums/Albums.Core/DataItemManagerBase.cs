using System.Net.Http.Json;
using Newtonsoft.Json;

namespace Albums.Core;

internal class DataItemManagerBase<T>
{
  private readonly IHttpClientManager _httpClientManager;
  private readonly IDataItemTools<T> _dataItemTools;

  protected DataItemManagerBase(IHttpClientManager httpClientManager, IDataItemTools<T> dataItemTools)
  {
    _httpClientManager = httpClientManager;
    _dataItemTools = dataItemTools;
  }

  public async Task<IEnumerable<T>> GetAll()
  {
    var client = await _httpClientManager.GetClient();
    var result = await client.GetStringAsync(_dataItemTools.GetAllUrl());

    return JsonConvert.DeserializeObject<List<T>>(result);
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

  protected async Task<T> DoAdd(T value)
  {
    var client = await _httpClientManager.GetClient();

    var msg = new HttpRequestMessage(HttpMethod.Post, _dataItemTools.GetAddUrl());

    msg.Content = JsonContent.Create(value);

    var response = await client.SendAsync(msg);
    response.EnsureSuccessStatusCode();

    var returnedJson = await response.Content.ReadAsStringAsync();

    var insertedPart = JsonConvert.DeserializeObject<T>(returnedJson);

    return insertedPart;
  }
}