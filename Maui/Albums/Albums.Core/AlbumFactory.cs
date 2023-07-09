using PartsClient.Data;

namespace Albums.Core;

internal class AlbumFactory : IAlbumFactory
{
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
}