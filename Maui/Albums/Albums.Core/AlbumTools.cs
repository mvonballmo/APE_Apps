namespace Albums.Core;

internal class AlbumTools : DataItemToolsBase<Part>, IAlbumTools
{
  public AlbumTools(IHttpSettings httpSettings)
    : base(httpSettings)
  {
  }

  public Part CreateAlbum(string partName, string supplier, string partType)
  {
    return new Part
    {
      PartName = partName,
      Suppliers = new List<string>(new[]
      {
        supplier
      }),
      PartID = string.Empty,
      PartType = partType,
      PartAvailableDate = DateTime.Now.Date
    };
  }

  protected override string UrlSuffix { get; } = "parts";

  protected override string GetItemId(Part item)
  {
    return item.PartID;
  }
}