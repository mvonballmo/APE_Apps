namespace Albums.Core;

public interface IAlbumTools : IDataItemTools<Part>
{
  Part CreateAlbum(string partName, string supplier, string partType);

  string GetAllUrl();

  string GetAddUrl();

  string GetUpdateUrl(Part item);

  string GetDeleteUrl(string id);
}