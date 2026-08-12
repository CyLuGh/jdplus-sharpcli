namespace JDPlus.WS.Models;

public readonly record struct ResultStatus
{
    public required ResultStatusType Type { get; init; }
    public required string Message { get; init; }
}
