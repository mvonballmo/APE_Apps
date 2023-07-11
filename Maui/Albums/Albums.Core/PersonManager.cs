namespace Albums.Core;

internal class PersonManager : DataItemManagerBase<Person>, IPersonManager
{
  protected PersonManager(IHttpClientManager httpClientManager, IDataItemTools<Person> dataItemTools)
    : base(httpClientManager, dataItemTools)
  {
  }
}