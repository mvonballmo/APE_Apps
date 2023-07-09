namespace Albums.Core;

internal class AlbumTools : IAlbumTools
{
  private readonly IHttpSettings _httpSettings;

  public AlbumTools(IHttpSettings httpSettings)
  {
    _httpSettings = httpSettings;
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

  public string GetAllUrl()
  {
    return $"{_httpSettings.Url}parts";
  }

  public string GetAddUrl()
  {
    return $"{_httpSettings.Url}parts";
  }

  public string GetUpdateUrl(Part item)
  {
    return$"{_httpSettings.Url}parts/{item.PartID}";
  }

  public string GetDeleteUrl(string id)
  {
    return $"{_httpSettings.Url}parts/{id}";
  }
}