using Microsoft.Extensions.Logging;
using Prism;
using TestMauiPrism.Application.Abstractions;
using TestMauiPrism.Application.UseCases;
using TestMauiPrism.Infrastructure.Persistence;
using TestMauiPrism.ViewModels;

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
                        container.RegisterSingleton<ICounterRepository, InMemoryCounterRepository>();
                        container.Register<IncrementCounterUseCase>();
                        container.RegisterForNavigation<NavigationPage>();
                        container.RegisterForNavigation<MainPage, MainPageViewModel>();
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
