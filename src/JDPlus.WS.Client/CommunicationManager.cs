using System.Security.Cryptography.X509Certificates;
using Grpc.Net.Client;
using JDPlus.Main.WS.V1;
using JDPlus.WS.Mapper;
using JDPlus.WS.Models;
using LanguageExt;

namespace JDPlus.WS.Client;

public class CommunicationManager
{
    private Option<X509Certificate2> _certificate;

    private TsFunctions.TsFunctionsClient GetClient()
    {
        var handler = new HttpClientHandler();
        var httpClient = new HttpClient(handler) { Timeout = TimeSpan.FromMinutes(10) };
        var channelOptions = new GrpcChannelOptions
        {
            HttpClient = httpClient,
            MaxReceiveMessageSize = 1024 * 1024 * 200,
            MaxSendMessageSize = 1024 * 1024 * 200,
        };
        var url = "http://localhost:4566";
        var channel = GrpcChannel.ForAddress(url, channelOptions);
        return new TsFunctions.TsFunctionsClient(channel);
    }

    public async Task<VersionInfo> GetVersion()
    {
        var dto = await GetClient().GetVersionAsync(new()).ConfigureAwait(false);
        return dto.ToModel();
    }
}
