using geekplace_adm.Services;
using geekplace_adm.State;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using MudBlazor.Services;
using System.Reflection;


namespace geekplace_adm
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
                });
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMudServices();
            // Charger la configuration à partir du fichier appsettings.Development.json (localhost), appsettings.json (production)
            using var stream = FileSystem.OpenAppPackageFileAsync("appsettings.json").Result;

            var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();

            builder.Configuration.AddConfiguration(config);

            var apiBaseUrl = builder.Configuration["Api:BaseUrl"];

            if (string.IsNullOrWhiteSpace(apiBaseUrl))
                throw new InvalidOperationException("La clé 'Api:BaseUrl' est manquante dans appsettings.json.");

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<AuthState>();
            builder.Services.AddSingleton<AuthState>();
            builder.Services.AddScoped<AuthService>();
            builder.Services.AddScoped<ArticleService>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<StatsService>();
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(apiBaseUrl)
            });

            return builder.Build();
        }
    }
}
