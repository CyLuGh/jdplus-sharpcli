using LanguageExt;
using OneOf;

namespace JDPlus.WS.Models;

public readonly record struct TramoOutput
{
    public RegArimaModel Result { get; init; }
    public TramoSpec EstimationSpec { get; init; }
    public Option<TramoSpec> ResultSpec { get; init; }
    public Option<ProcessingLogs> Log { get; init; }
}

public readonly record struct RegArimaModel(
    Description Description,
    Estimation Estimation,
    Diagnostics Diagnostics
);

public readonly record struct Description
{
    public TsData Series { get; init; }
    public bool Log { get; init; }
    public LengthOfPeriod Preadjustment { get; init; }
    public Seq<RegressionVariable> Variables { get; init; }
    public SarimaSpec Arima { get; init; }
}

public readonly record struct RegressionVariable(
    string Name,
    VariableType VarType,
    HashMap<string, string> MetaData,
    Seq<Parameter> Coefficients
);

public readonly record struct Estimation
{
    public Seq<double> Y { get; init; }
    public Matrix X { get; init; }
    public Seq<double> B { get; init; }
    public Matrix BCovariance { get; init; }
    public ParametersEstimation Parameters { get; init; }
    public LikelihoodStatistics Likelihood { get; init; }
    public Seq<double> Residuals { get; init; }
    public Seq<MissingEstimation> Missings { get; init; }
}

public readonly record struct ParametersEstimation(
    Seq<double> Value,
    Seq<double> Score,
    Matrix Covariance,
    Option<string> Description
);

public readonly record struct MissingEstimation(int Position, double Value, double StDev);

public readonly record struct ProcessingLogs(Seq<ProcessingInformation> Log);

public readonly record struct Diagnostics(HashMap<string, StatisticalTest> ResidualsTests);

public enum InformationType
{
    Info = 0,
    Warning = 1,
    Error = 2
}

public enum VariableType
{
    Unspecified = 0,
    Mean = 1,
    Td = 10,
    Lp = 11,
    Easter = 12,
    Ao = 20,
    Ls = 21,
    Tc = 22,
    So = 23,
    Outlier = 29,
    Iv = 30,
    Ramp = 40
}

public readonly record struct ProcessingInformation
{
    public string Name { get; init; }
    public string Origin { get; init; }
    public string Message { get; init; }
    public InformationType Type { get; init; }
    public ProcessingDetail Details { get; init; }
}

public readonly record struct ProcessingDetail(
    OneOf<TsData, Doubles, Matrix, StatisticalTest, string, int, double> Data
);

public readonly record struct Doubles(string Name, Seq<double> Values);
