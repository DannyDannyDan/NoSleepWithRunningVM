using System.Diagnostics;
using System.Windows.Forms;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcGreeter;
//using GuestKeyHooker;

namespace GuestKeyHooker
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // setup keyboard hook
            var kh = new KeyboardHook(true);
            kh.KeyDown += Kh_KeyDown;

            //await ConnectGreater();

            Application.Run(new Form1());
        }

        private static async void Kh_KeyDown(Keys key, bool Shift, bool Ctrl, bool Alt)
        {
            Debug.WriteLine($"KeyDown {key} ({(int)key})", "KeyHooker");

            using var channel = GrpcChannel.ForAddress("https://localhost:7184");
            var client = new GrpcGreeter.HookedKey.HookedKeyClient(channel);
            var reply = await client.SendHookedKeyAsync(new HookedKeySendModel { KeyCode = (int)key });
            Debug.WriteLine($"Greeting: {reply}");
            Debug.WriteLine("Press any key to exit...");
        }

        private static async Task ConnectGreater()
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7184");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "GuestKeyHooker" });
            Debug.WriteLine("Greeting: " + reply.Message);
            Debug.WriteLine("Press any key to exit...");
        }

    }
}