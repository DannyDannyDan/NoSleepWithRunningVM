using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static System.Runtime.CompilerServices.RuntimeHelpers;


namespace NoSleepWithRunningVM.Services
{
    public class HookedKeyService : HookedKey.HookedKeyBase
    {
        private readonly ILogger<HookedKeyService> _logger;
        private Forms.DummySendKeysForm sendKeyForm = new Forms.DummySendKeysForm();

        public HookedKeyService(ILogger<HookedKeyService> logger)
        {
            _logger = logger;
        }

        public override async Task<HookedKeyResponseModel> SendHookedKey(HookedKeySendModel request, ServerCallContext context)
        {
            if (request.KeyCode < (int)Keys.VolumeMute || request.KeyCode > (int)Keys.MediaPlayPause)
                return await Task.FromResult(new HookedKeyResponseModel() { IsReceived = true });

            Console.WriteLine($"SendKey Requested: {request.KeyCode}");
            Debug.WriteLine($"SendKey Requested: {request.KeyCode}");
                       
            Task.Run(() => sendKeyForm.SendKey((Keys)request.KeyCode));

            return await Task.FromResult(new HookedKeyResponseModel() { IsReceived = true });
        }

    }
}
