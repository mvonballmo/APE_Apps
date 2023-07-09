namespace Albums.Core;

internal class ConnectivityChecker : IConnectivityChecker
{
  public bool Connected => Connectivity.Current.NetworkAccess != NetworkAccess.Internet;
}