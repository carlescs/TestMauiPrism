using TestMauiPrism.Infrastructure.Persistence;

namespace TestMauiPrism.Infrastructure.Tests.Persistence;

public sealed class InMemoryCounterRepositoryTests
{
    private readonly InMemoryCounterRepository _sut = new();

    [Fact]
    public void Increment_WhenCalledOnce_ReturnsOne()
    {
        var result = _sut.Increment();

        Assert.Equal(1, result);
    }

    [Fact]
    public void Increment_WhenCalledMultipleTimes_ReturnsCumulativeCount()
    {
        _sut.Increment();
        var result = _sut.Increment();

        Assert.Equal(2, result);
    }

    [Fact]
    public void Increment_EachCallIncreasesByOne()
    {
        for (var i = 1; i <= 5; i++)
        {
            Assert.Equal(i, _sut.Increment());
        }
    }

    [Fact]
    public void Increment_StateIsIsolatedPerInstance()
    {
        var other = new InMemoryCounterRepository();
        _sut.Increment();

        var result = other.Increment();

        Assert.Equal(1, result);
    }
}
