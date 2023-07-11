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

internal class PersonTools : UniqueItemToolsBase<Person>, IPersonTools
{
  public PersonTools(IHttpSettings httpSettings)
    : base(httpSettings)
  {
  }

  public Person CreatePerson(string firstName, string lastName)
  {
    return new Person
    {
      FirstName = firstName,
      LastName = lastName
    };
  }

  protected override string UrlSuffix { get; } = "people";
}