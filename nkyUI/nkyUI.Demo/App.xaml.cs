using Avalonia;
using Avalonia.Controls;
using Avalonia.Diagnostics;
using Avalonia.Logging.Serilog;
using Avalonia.Markup.Xaml;
using Serilog;
using System;

namespace nkyUI.Demo
{
    internal class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
            base.Initialize();
        }

        private static void Main(string[] args)
        {
            InitializeLogging();
            var builder = AppBuilder.Configure<App>();
#if !AnyCPU
            if (args.Length >= 1 && args[0] == "--skia")
            {
                builder.UseSkia();

                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                {
                    builder.UseWin32();
                }
                else
                {
                    builder.UseGtk();
                }
            }
#endif
            else
            {
                builder.UsePlatformDetect();
            }
            builder.Start<MainWindow>();
        }

        public static void AttachDevTools(Window window)
        {
#if DEBUG
            DevTools.Attach(window);
#endif
        }

        private static void InitializeLogging()
        {
#if DEBUG
            SerilogLogger.Initialize(new LoggerConfiguration()
                .MinimumLevel.Warning()
                .WriteTo.Trace(outputTemplate: "{Area}: {Message}")
                .CreateLogger());
#endif
        }
    }
}