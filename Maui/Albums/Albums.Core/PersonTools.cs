namespace Albums.Core;

internal class PersonTools : UniqueItemToolsBase<Person>, IPersonTools
{
  public PersonTools(IHttpSettings httpSettings)
    : base(httpSettings)
  {
  }

  protected override string UrlSuffix { get; } = "people";
}