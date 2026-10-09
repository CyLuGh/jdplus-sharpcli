namespace JDPlus.WS.Models;

public readonly record struct ProcessingInformation
{
    public string Name { get; init; }
    public string Origin { get; init; }
    public string Message { get; init; }
    public InformationType Type { get; init; }
    public ProcessingDetail Details { get; init; }
}
