namespace Albums.Core;

internal abstract class DataItemToolsBase<T> : IDataItemTools<T>
{
  private readonly IHttpSettings _httpSettings;

  protected DataItemToolsBase(IHttpSettings httpSettings)
  {
    _httpSettings = httpSettings;
  }

  public string GetAllUrl()
  {
    return GetBaseUrl();
  }

  public string GetAddUrl()
  {
    return GetBaseUrl();
  }

  public string GetUpdateUrl(T item)
  {
    return$"{GetBaseUrl()}/{GetItemId(item)}";
  }

  public string GetDeleteUrl(string id)
  {
    return $"{GetBaseUrl()}/{id}";
  }

  protected abstract string UrlSuffix { get; }

  protected abstract string GetItemId(T item);

  protected virtual string GetBaseUrl()
  {
    return $"{_httpSettings.Url}{UrlSuffix}";
  }
}