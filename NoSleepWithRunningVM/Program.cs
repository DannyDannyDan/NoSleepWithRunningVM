using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NoSleepWithRunningVM.Services;
using System.Windows.Forms;

namespace NoSleepWithRunningVM
{
    internal static class Program
    {
        static NotifyIcon? notifyIcon;
        static bool lastStatusNoSleep;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();

            notifyIcon = new NotifyIcon();
            notifyIcon.ContextMenuStrip = Helpers.SystemTrayHelper.GetContextMenu();
            notifyIcon.Icon = Properties.Resources.Sleep;
            notifyIcon.Visible = true;

            var noSleepService = new NoSleepService();
            noSleepService.PreventingSleep += NoSleepService_PreventingSleep;
            noSleepService.PreventSleep();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddGrpc();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<HookedKeyService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
            var url = $"https://0.0.0.0:50443";
            app.RunAsync(url);

            Application.Run();

            // remove icon from system tray
            notifyIcon.Visible = false;
        }
        private static void NoSleepService_PreventingSleep(object? sender, bool e)
        {
            if (notifyIcon==null) 
                return;

            if (e)
            {
                notifyIcon.Icon = Properties.Resources.NoSleep;
                notifyIcon.Text = "Virtual Machine(s) running.  Sleep mode disabled until all are stopped.";
                if (lastStatusNoSleep == false)
                {
                    notifyIcon.BalloonTipText = notifyIcon.Text;
                    notifyIcon.ShowBalloonTip(1000);
                }

                lastStatusNoSleep = true;
            }
            else
            {
                notifyIcon.Icon = Properties.Resources.Sleep;
                notifyIcon.Text = "No Virtual Machines running.  Sleep mode enabled.";
                if (lastStatusNoSleep == true)
                {
                    notifyIcon.BalloonTipText = notifyIcon.Text;
                    notifyIcon.ShowBalloonTip(1000);
                }
                lastStatusNoSleep = false;
            }
        }


    }
}