namespace Albums.Core
{
  internal class AlbumManager : DataItemManagerBase<Part>, IAlbumManager
  {
    private readonly IAlbumTools _albumTools;

    public AlbumManager(IHttpClientManager httpClientManager, IAlbumTools albumTools)
      : base(httpClientManager, albumTools)
    {
      _albumTools = albumTools;
    }

    public async Task<Part> Add(string partName, string supplier, string partType)
    {
      return await DoAdd(_albumTools.CreateAlbum(partName, supplier, partType));
    }
  }
}