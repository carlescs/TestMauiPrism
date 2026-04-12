using TestMauiPrism.Application.Abstractions;
using TestMauiPrism.Domain.Entities;

namespace TestMauiPrism.Infrastructure.Persistence;

public sealed class InMemoryCounterRepository : ICounterRepository
{
    private readonly Counter _counter = new();

    public int Increment()
    {
        return _counter.Increment();
    }
}
