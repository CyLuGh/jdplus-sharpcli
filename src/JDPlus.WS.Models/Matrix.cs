using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct Matrix
{
    public int NRows { get; init; }
    public int NColumns { get; init; }

    /// <summary>
    /// The number of values should be nrows*ncols. Values are organized by columns (1st column, 2nd column...)
    /// </summary>
    public Seq<double> Values { get; init; }
}
