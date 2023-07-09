using PartsClient.Data;

namespace Albums.Core;

public interface IAlbumManager
{
  Task<IEnumerable<Part>> GetAll();

  Task<Part> Add(string partName, string supplier, string partType);

  Task Update(Part part);

  Task Delete(string partId);
}