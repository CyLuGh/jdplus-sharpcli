// See https://aka.ms/new-console-template for more information

using ConsoleApp;
using JDPlus.WS.Client;
using JDPlus.WS.Models;
using LanguageExt;

CommunicationManager communicationManager = new();

var version = await communicationManager.GetVersion();
Console.WriteLine(version);

TsGenerator generator = new();
var ts = generator.GenerateTs(frequency: Frequency.Monthly, count: 240);
var statistics = await communicationManager.GetDescriptiveStatistics(ts.Data);
Console.WriteLine(statistics);

var data = Seq.create(
    (new DateOnly(2022, 1, 1), 1d),
    (new DateOnly(2022, 2, 1), 1d),
    (new DateOnly(2022, 3, 1), 1d),
    (new DateOnly(2023, 1, 1), 1d),
    (new DateOnly(2023, 2, 1), 1d),
    (new DateOnly(2023, 3, 1), 1d),
    (new DateOnly(2023, 4, 1), 1d)
);
var built = await communicationManager.BuildTsData(data, AggregationType.Sum, Frequency.Yearly);
Console.WriteLine(built.Values.Length);

Console.ReadLine();
