using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct Doubles(string Name, Seq<double> Values);
