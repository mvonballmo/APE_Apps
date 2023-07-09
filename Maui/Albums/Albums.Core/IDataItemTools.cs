namespace Albums.Core;

public interface IDataItemTools<in T>
{
  string GetAllUrl();

  string GetAddUrl();

  string GetUpdateUrl(T item);

  string GetDeleteUrl(string id);
}