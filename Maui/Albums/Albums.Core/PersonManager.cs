namespace Albums.Core;

internal class PersonManager : UniqueItemManager<Person>, IPersonManager
{
  public PersonManager(IHttpClientManager httpClientManager, IPersonTools tools)
    : base(httpClientManager, tools)
  {
  }
}