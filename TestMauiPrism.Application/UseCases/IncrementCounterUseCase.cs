using TestMauiPrism.Application.Abstractions;

namespace TestMauiPrism.Application.UseCases;

public sealed class IncrementCounterUseCase
{
    private readonly ICounterRepository _counterRepository;

    public IncrementCounterUseCase(ICounterRepository counterRepository)
    {
        _counterRepository = counterRepository;
    }

    public int Execute()
    {
        return _counterRepository.Increment();
    }
}
