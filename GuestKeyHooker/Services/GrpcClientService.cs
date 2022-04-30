using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestKeyHooker.Services
{
    internal static class GrpcClientService
    {
        private static HookedKey.HookedKeyClient? _client;
        public static string ServerIp { get; set; } = Properties.Settings.Default.ServiceIp;
        public static string ServerPort { get; set; } = Properties.Settings.Default.ServicePort;
        private static string Url { get => $"https://{ServerIp}:{ServerPort}"; }
        public static async Task<bool> CanConnectAsync(string serverIpHost = "", string serverPort = "")
        {
            if (serverIpHost != "" && serverPort != "")
            {
                ServerIp = serverIpHost;
                ServerPort = serverPort;

                // set _client to null, this will make it reconnect with new url
                _client = null;
            }
            return await Task.FromResult(Client.SendHookedKeyAsync(new HookedKeySendModel()).ResponseAsync.Result.IsReceived);
        }

        public static HookedKey.HookedKeyClient Client
        {
            get
            {
                if (_client == null)
                {
                    var handler = new HttpClientHandler();
                    
                    handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

                    var httpClient = new HttpClient(handler);                    
                    var channel = GrpcChannel.ForAddress(Url, new GrpcChannelOptions
                    {
                        HttpClient = httpClient
                    });

                    _client = new HookedKey.HookedKeyClient(channel);
                }
                return _client;
            }
        }

    }
}
