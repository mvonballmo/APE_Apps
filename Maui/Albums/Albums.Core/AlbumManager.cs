namespace Albums.Core
{
  internal class AlbumManager : DataItemManagerBase<Album>, IAlbumManager
  {
    public AlbumManager(IHttpClientManager httpClientManager, IAlbumTools tools)
      : base(httpClientManager, tools)
    {
    }
  }
}