namespace Albums.Core;

public interface IDataItemManager<T, in TIdentifier>
{
  Task<IEnumerable<T>> GetAll();

  Task<T> Add(T item);

  Task Update(T part);

  Task Delete(TIdentifier id);
}