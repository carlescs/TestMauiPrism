using NSubstitute;
using TestMauiPrism.Application.Abstractions;
using TestMauiPrism.Application.UseCases;

namespace TestMauiPrism.Application.Tests.UseCases;

public sealed class IncrementCounterUseCaseTests
{
    private readonly ICounterRepository _counterRepository = Substitute.For<ICounterRepository>();
    private readonly IncrementCounterUseCase _sut;

    public IncrementCounterUseCaseTests()
    {
        _sut = new IncrementCounterUseCase(_counterRepository);
    }

    [Fact]
    public void Execute_DelegatesToRepository_AndReturnsItsValue()
    {
        _counterRepository.Increment().Returns(3);

        var result = _sut.Execute();

        Assert.Equal(3, result);
    }

    [Fact]
    public void Execute_CallsRepositoryIncrementExactlyOnce()
    {
        _sut.Execute();

        _counterRepository.Received(1).Increment();
    }
}
