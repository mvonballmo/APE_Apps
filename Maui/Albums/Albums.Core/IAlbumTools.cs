namespace Albums.Core;

public interface IAlbumTools : IDataItemTools<Part>
{
  Part CreateAlbum(string partName, string supplier, string partType);
}