using Microsoft.Extensions.Logging;
using Prism;
using TestMauiPrism.Application;
using TestMauiPrism.Infrastructure;
using TestMauiPrism.ViewModels;
using TestMauiPrism.Views;

namespace TestMauiPrism
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UsePrism(prism =>
                {
                    prism.RegisterTypes(container =>
                    {
                        container.AddInfrastructure();
                        container.AddApplication();
                        container.RegisterForNavigation<NavigationPage>();
                        container.RegisterForNavigation<MainPage, MainPageViewModel>();
                        container.RegisterForNavigation<CounterDetailPage, CounterDetailPageViewModel>();
                    });

                    prism.CreateWindow("NavigationPage/MainPage");
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
