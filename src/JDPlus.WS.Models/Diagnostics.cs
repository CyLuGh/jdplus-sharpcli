using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct Diagnostics(HashMap<string, StatisticalTest> ResidualsTests);
