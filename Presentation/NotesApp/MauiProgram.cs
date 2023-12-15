using Microsoft.Extensions.Logging;
using Notes.ApiClient.IoC;
namespace NotesApp
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
                });
            builder.Services.AddNoteApiClientService(x => x.ApiBaseAddress = "http://10.0.2.2:5000/");
            builder.Services.AddTransient<MainPage>();
#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}