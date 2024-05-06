namespace Albums.Core
{
  internal class AlbumManager : UniqueItemManager<Album>, IAlbumManager
  {
    public AlbumManager(IHttpClientManager httpClientManager, IAlbumTools tools)
      : base(httpClientManager, tools)
    {
    }
  }
}