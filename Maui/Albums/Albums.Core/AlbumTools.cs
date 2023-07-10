namespace Albums.Core;

internal class AlbumTools : UniqueItemToolsBase<Album>, IAlbumTools
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
}