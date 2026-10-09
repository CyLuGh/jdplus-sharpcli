using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;
using LanguageExt;
using AutomaticTradingDays = JDPlus.Main.WS.V1.AutomaticTradingDays;
using LengthOfPeriod = JDPlus.Main.WS.V1.LengthOfPeriod;
using TradingDays = JDPlus.Main.WS.V1.TradingDays;
using TradingDaysTest = JDPlus.Main.WS.V1.TradingDaysTest;

namespace JDPlus.WS.Mapper;

public static class TradingDaysSpecMapper
{
    public static TradingDaysSpecDto ToDto(this TradingDaysSpec model)
    {
        var dto = new TradingDaysSpecDto
        {
            Td = (TradingDays)model.TD,
            Lp = (LengthOfPeriod)model.LP,
            Holidays = model.Holidays,
            W = model.W,
            Test = (TradingDaysTest)model.Test,
            Auto = (AutomaticTradingDays)model.Auto,
            Ptest = model.PTest,
            AutoAdjust = model.AutoAdjust,
        };
        model.LPCoefficient.IfSome(coefficient => dto.Lpcoefficient = coefficient.ToDto());
        dto.Users.AddRange(model.Users);
        dto.Tdcoefficients.AddRange(model.TDCoefficients.ToDto());

        return dto;
    }

    public static TradingDaysSpec ToModel(this TradingDaysSpecDto dto) =>
        new()
        {
            TD = (Models.TradingDays)dto.Td,
            LP = (Models.LengthOfPeriod)dto.Lp,
            Holidays = dto.Holidays,
            W = dto.W,
            Test = (Models.TradingDaysTest)dto.Test,
            Auto = (Models.AutomaticTradingDays)dto.Auto,
            PTest = dto.Ptest,
            AutoAdjust = dto.AutoAdjust,
            LPCoefficient = dto.Lpcoefficient?.ToModel() ?? Option<Parameter>.None,
            TDCoefficients = dto.Tdcoefficients.ToModel(),
            Users = dto.Users.ToSeq()
        };
}
