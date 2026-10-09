using JDPlus.Main.WS.V1;
using JDPlus.WS.Models;
using LanguageExt;
using InformationType = JDPlus.WS.Models.InformationType;
using LengthOfPeriod = JDPlus.WS.Models.LengthOfPeriod;
using VariableType = JDPlus.WS.Models.VariableType;

namespace JDPlus.WS.Mapper;

public static class TramoOutputMapper
{
    public static TramoOutput ToModel(this TramoOutputDto dto)
    {
        var model = new TramoOutput
        {
            Result = dto.Result.ToModel(),
            EstimationSpec = dto.EstimationSpec.ToModel(),
            ResultSpec = dto.ResultSpec?.ToModel() ?? Option<TramoSpec>.None,
            Log = dto.Log?.ToModel() ?? Option<ProcessingLogs>.None
        };

        return model;
    }
}

public static class RegArimaModelMapper
{
    public static RegArimaModel ToModel(this RegArimaModelDto dto) =>
        new()
        {
            Description = dto.Description.ToModel(),
            Estimation = dto.Estimation.ToModel(),
            Diagnostics = dto.Diagnostics.ToModel()
        };
}

public static class DescriptionMapper
{
    public static Description ToModel(this RegArimaModelDto.Types.DescriptionDto dto) =>
        new()
        {
            Series = dto.Series.ToModel(),
            Log = dto.Log,
            Preadjustment = (LengthOfPeriod)dto.Preadjustment,
            Variables = dto.Variables.Select(x => x.ToModel()).ToSeq(),
            Arima = dto.Arima.ToModel()
        };
}

public static class RegressionVariableMapper
{
    public static RegressionVariable ToModel(this RegressionVariableDto dto) =>
        new(
            dto.Name,
            (VariableType)dto.VarType,
            dto.Metadata.Select(x => (x.Key, x.Value)).ToHashMap(),
            dto.Coefficients.Select(x => x.ToModel()).ToSeq()
        );
}

public static class EstimationMapper
{
    public static Estimation ToModel(this RegArimaModelDto.Types.EstimationDto dto) =>
        new()
        {
            Y = dto.Y.ToSeq(),
            X = dto.X.ToModel(),
            B = dto.B.ToSeq(),
            BCovariance = dto.Bcovariance.ToModel(),
            Parameters = dto.Parameters.ToModel(),
            Likelihood = dto.Likelihood.ToModel(),
            Residuals = dto.Residuals.ToSeq(),
            Missings = dto.Missings.Select(x => x.ToModel()).ToSeq()
        };
}

public static class ParametersEstimationMapper
{
    public static ParametersEstimation ToModel(this ParametersEstimationDto dto) =>
        new(
            dto.Value.ToSeq(),
            dto.Score.ToSeq(),
            dto.Covariance.ToModel(),
            dto.HasDescription ? dto.Description : Option<string>.None
        );
}

public static class MissingEstimationMapper
{
    public static MissingEstimation ToModel(this RegArimaModelDto.Types.MissingEstimationDto dto) =>
        new(dto.Position, dto.Value, dto.Stde);
}

public static class ProcessingLogsMapper
{
    public static ProcessingLogs ToModel(this ProcessingLogsDto dto) =>
        new(dto.Log.Select(x => x.ToModel()).ToSeq());
}

public static class DiagnosticsMapper
{
    public static Diagnostics ToModel(this DiagnosticsDto dto) =>
        new(dto.ResidualsTests.Select(x => (x.Key, x.Value.ToModel())).ToHashMap());
}

public static class ProcessingInformationMapper
{
    public static ProcessingInformation ToModel(this ProcessingInformationDto dto) =>
        new()
        {
            Name = dto.Name,
            Origin = dto.Origin,
            Message = dto.Msg,
            Type = (InformationType)dto.Type,
            Details = dto.Details.ToModel()
        };
}

public static class ProcessingDetailMapper
{
    public static ProcessingDetail ToModel(this ProcessingDetailDto dto) =>
        dto.DataCase switch
        {
            ProcessingDetailDto.DataOneofCase.Array => new(dto.Array.ToModel()),
            ProcessingDetailDto.DataOneofCase.Matrix => new(dto.Matrix.ToModel()),
            ProcessingDetailDto.DataOneofCase.Ts => new(dto.Ts.ToModel()),
            ProcessingDetailDto.DataOneofCase.Test => new(dto.Test.ToModel()),
            ProcessingDetailDto.DataOneofCase.Dvalue => new(dto.Dvalue),
            ProcessingDetailDto.DataOneofCase.Ivalue => new(dto.Ivalue),
            ProcessingDetailDto.DataOneofCase.Message => new(dto.Message),
            _ => throw new ArgumentException("Invalid data case"),
        };
}

public static class DoublesMapper
{
    public static Doubles ToModel(this DoublesDto dto) =>
        new(dto.Name, dto.Values.ToSeq().Strict());
}
