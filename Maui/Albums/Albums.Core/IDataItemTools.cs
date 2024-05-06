namespace Albums.Core;

public interface IDataItemTools<in T, in TIdentifier>
{
  string GetAllUrl();

  string GetAddUrl();

  string GetUpdateUrl(T item);

  string GetDeleteUrl(TIdentifier id);
}