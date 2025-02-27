﻿
using Microsoft.Extensions.Logging;
using MudBlazor;
using MudBlazor.Services;
using PersonalFinanceTracker.Services;
//using PersonalFinanceTracker.Services;
//using PersonalFinanceTracker.Services;
namespace PersonalFinanceTracker
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
            // In Program.cs
          
            builder.Services.AddMudServices();

            builder.Logging.SetMinimumLevel(LogLevel.Debug);
            builder.Logging.AddDebug();

            // Configure MudBlazor with Snackbar
            builder.Services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;
                config.SnackbarConfiguration.PreventDuplicates = false;
                config.SnackbarConfiguration.NewestOnTop = true;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.VisibleStateDuration = 3000;
                config.SnackbarConfiguration.HideTransitionDuration = 200;
                config.SnackbarConfiguration.ShowTransitionDuration = 200;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
            });
            builder.Services.AddMudServices();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
            //Add here
            //builder.Services.AddSingleton<IReportTransaction, ReportTransaction>();
            builder.Services.AddSingleton<IAddTransactionServices, AddTransactionServices>();
#endif
            builder.Services.AddScoped<ILoginServices, LoginServices>();
            return builder.Build();
        }
    }
}