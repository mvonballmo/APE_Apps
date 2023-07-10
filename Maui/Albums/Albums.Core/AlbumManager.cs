namespace Albums.Core
{
  internal class AlbumManager : DataItemManagerBase<Album>, IAlbumManager
  {
    private readonly IAlbumTools _albumTools;

    public AlbumManager(IHttpClientManager httpClientManager, IAlbumTools albumTools)
      : base(httpClientManager, albumTools)
    {
      _albumTools = albumTools;
    }

    public async Task<Album> Add(string name)
    {
      return await DoAdd(_albumTools.CreateAlbum(name));
    }
  }
}