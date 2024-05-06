namespace Albums.Core;

internal class AlbumTools : UniqueItemToolsBase<Album>, IAlbumTools
{
  public AlbumTools(IHttpSettings httpSettings)
    : base(httpSettings)
  {
  }

  protected override string UrlSuffix { get; } = "albums";
}