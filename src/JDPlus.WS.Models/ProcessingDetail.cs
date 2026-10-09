using OneOf;

namespace JDPlus.WS.Models;

public readonly record struct ProcessingDetail(
    OneOf<TsData, Doubles, Matrix, StatisticalTest, string, int, double> Data
);
