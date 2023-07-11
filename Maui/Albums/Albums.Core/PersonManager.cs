namespace Albums.Core;

internal class PersonManager : DataItemManager<Person>, IPersonManager
{
  protected PersonManager(IHttpClientManager httpClientManager, IDataItemTools<Person> dataItemTools)
    : base(httpClientManager, dataItemTools)
  {
  }
}