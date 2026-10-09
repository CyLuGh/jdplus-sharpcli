using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct RegressionVariable(
    string Name,
    VariableType VarType,
    HashMap<string, string> MetaData,
    Seq<Parameter> Coefficients
);
