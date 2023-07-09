namespace Albums.Core;

public interface IConnectivityChecker
{
  public bool Connected { get; }
}