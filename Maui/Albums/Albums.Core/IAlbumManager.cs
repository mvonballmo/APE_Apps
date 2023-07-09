namespace Albums.Core;

public interface IAlbumManager : IDataItemManager<Part>
{
  Task<Part> Add(string partName, string supplier, string partType);
}