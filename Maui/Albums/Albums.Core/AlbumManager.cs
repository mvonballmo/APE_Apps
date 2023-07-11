namespace Albums.Core
{
  internal class AlbumManager : DataItemManager<Album>, IAlbumManager
  {
    public AlbumManager(IHttpClientManager httpClientManager, IAlbumTools tools)
      : base(httpClientManager, tools)
    {
    }
  }
}