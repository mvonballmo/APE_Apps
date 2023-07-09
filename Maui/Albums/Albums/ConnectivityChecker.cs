using Albums.Core;

namespace Albums;

internal class ConnectivityChecker : IConnectivityChecker
{
  public bool Connected => Connectivity.Current.NetworkAccess != NetworkAccess.Internet;
}