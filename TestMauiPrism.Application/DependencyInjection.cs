using Prism.Ioc;
using TestMauiPrism.Application.UseCases;

namespace TestMauiPrism.Application;

public static class DependencyInjection
{
    public static IContainerRegistry AddApplication(this IContainerRegistry container)
    {
        container.Register<IncrementCounterUseCase>();
        return container;
    }
}
