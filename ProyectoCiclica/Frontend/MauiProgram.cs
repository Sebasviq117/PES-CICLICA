using Microsoft.Extensions.Logging;

namespace Frontend
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Verah___.ttf", "Verah");
                    fonts.AddFont("Verahb__.ttf", "Verahb");
                    fonts.AddFont("Verahbi_.ttf", "Verahbi");
                    fonts.AddFont("Verahi__.ttf", "Verahi");
                    fonts.AddFont("windows_command_prompt.ttf", "Prompt");
                    fonts.AddFont("fa-brands-400.ttf", "FontAwesome");
                    fonts.AddFont("fa-solid-900.ttf", "FontAwesome6");


                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}