namespace Albums.Core;

public interface IAlbumManager : IDataItemManager<Album>
{
  Task<Album> Add(string name);
}