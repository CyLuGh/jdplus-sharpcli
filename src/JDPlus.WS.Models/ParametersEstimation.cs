using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct ParametersEstimation(
    Seq<double> Value,
    Seq<double> Score,
    Matrix Covariance,
    Option<string> Description
);
