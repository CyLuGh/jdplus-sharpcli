namespace JDPlus.WS.Models;

public readonly record struct VersionInfo(int Major, int Minor, int Revision)
{
    public override string ToString() => $"{Major}.{Minor}.{Revision}";
}
