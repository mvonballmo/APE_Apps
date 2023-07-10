namespace Albums.Core;

internal abstract class UniqueItemToolsBase<T> : DataItemToolsBase<T>
  where T : UniqueItem
{
  protected UniqueItemToolsBase(IHttpSettings httpSettings)
    : base(httpSettings)
  {
  }

  protected override string GetItemId(T item)
  {
    return item.Id.ToString();
  }
}