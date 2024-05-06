namespace Albums.Core;

internal abstract class DataItemToolsBase<T, TIdentifier> : IDataItemTools<T, TIdentifier>
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

  public string GetDeleteUrl(TIdentifier id)
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