namespace Albums.Core;

public interface IAlbumTools : IDataItemTools<Album>
{
  Album CreateAlbum(string name);
}