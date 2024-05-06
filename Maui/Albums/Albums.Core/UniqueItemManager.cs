namespace Albums.Core;

internal class UniqueItemManager<T> : DataItemManager<T, int>
{
  protected UniqueItemManager(IHttpClientManager httpClientManager, IDataItemTools<T, int> tools)
    : base(httpClientManager, tools)
  {
  }
}