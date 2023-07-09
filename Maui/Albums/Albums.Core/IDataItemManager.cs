namespace Albums.Core;

public interface IDataItemManager<T>
{
  Task<IEnumerable<T>> GetAll();

  Task Update(T part);

  Task Delete(string id);
}