namespace Albums.Core;

internal class AlbumTools : DataItemToolsBase<Album>, IAlbumTools
{
  public AlbumTools(IHttpSettings httpSettings)
    : base(httpSettings)
  {
  }

  public Album CreateAlbum(string name)
  {
    return new Album
    {
      Name = name
    };
  }

  protected override string UrlSuffix { get; } = "albums";

  protected override string GetItemId(Album item)
  {
    return item.Id.ToString();
  }
}