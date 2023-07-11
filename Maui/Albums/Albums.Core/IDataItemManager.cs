namespace Albums.Core;

public interface IDataItemManager<T>
{
  Task<IEnumerable<T>> GetAll();

  Task<T> Add(T item);

  Task Update(T part);

  // TODO Make id type generic

  Task Delete(string id);
}