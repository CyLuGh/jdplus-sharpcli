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
var built = await communicationManager.BuildTsData(data, AggregationType.Sum);
Console.WriteLine(built.Values.Length);

var ySeq = Seq.create(500d, 510d, 525d, 520d);
var y = new TsData()
{
    Start = new()
    {
        Frequency = Frequency.Yearly,
        Position = 0,
        Year = 1977,
    },
    Values = ySeq,
};

var disagg = await communicationManager
    .ProcessTemporalDisaggregation(
        new()
        {
            Y = y,
            Constant = false,
            Trend = false,
            Model = "Rw",
            Frequency = 12,
            Average = false,
            Rho = 0,
            FixedRho = false,
            TruncatedRho = 0,
            ZeroInit = false,
            Algorithm = "SqrtDiffuse",
            DiffuserEgs = false,
            NBackcasts = 0,
            NForecasts = 6,
        }
    )
    .ConfigureAwait(false);

foreach (var t in disagg.DisaggregatedSeries.GetDateValues().OrderBy(x => x.Key))
    Console.WriteLine(t);

Console.ReadLine();
