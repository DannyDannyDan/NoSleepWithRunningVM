using Grpc.Core;
using System.Diagnostics;

namespace GrpcGreeter.Services
{
    public class HookedKeyService : HookedKey.HookedKeyBase
    {
        private readonly ILogger<HookedKeyService> _logger;

        public HookedKeyService(ILogger<HookedKeyService> logger)
        {
            _logger = logger;
        }

        public override Task<HookedKeyResponseModel> SendHookedKey(HookedKeySendModel request, ServerCallContext context)
        {
            Console.WriteLine($"SendKey Requested: {request.KeyCode}");
            Debug.WriteLine($"SendKey Requested: {request.KeyCode}");
            return Task.FromResult(new HookedKeyResponseModel() { IsReceived = true });
        }
    }
}
