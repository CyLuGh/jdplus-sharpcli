using LanguageExt;

namespace JDPlus.WS.Models;

public readonly record struct ProcessingLogs(Seq<ProcessingInformation> Log);
