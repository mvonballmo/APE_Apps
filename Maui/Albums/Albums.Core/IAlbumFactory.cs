using PartsClient.Data;

namespace Albums.Core;

public interface IAlbumFactory
{
  Part CreateAlbum(string partName, string supplier, string partType);
}