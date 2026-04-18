using Prism.Ioc;
using TestMauiPrism.Application.Abstractions;
using TestMauiPrism.Infrastructure.Persistence;

namespace TestMauiPrism.Infrastructure;

public static class DependencyInjection
{
    public static IContainerRegistry AddInfrastructure(this IContainerRegistry container)
    {
        container.RegisterSingleton<ICounterRepository, InMemoryCounterRepository>();
        return container;
    }
}
