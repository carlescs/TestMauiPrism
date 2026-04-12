using TestMauiPrism.Domain.Entities;

namespace TestMauiPrism.Domain.Tests.Entities;

public sealed class CounterTests
{
    [Fact]
    public void Increment_WhenCalledOnce_ReturnsOne()
    {
        var counter = new Counter();

        var result = counter.Increment();

        Assert.Equal(1, result);
    }

    [Fact]
    public void Increment_WhenCalledMultipleTimes_ReturnsAccumulatedCount()
    {
        var counter = new Counter();

        counter.Increment();
        var result = counter.Increment();

        Assert.Equal(2, result);
    }

    [Fact]
    public void Count_BeforeAnyIncrement_IsZero()
    {
        var counter = new Counter();

        Assert.Equal(0, counter.Count);
    }

    [Fact]
    public void Count_AfterIncrement_ReflectsReturnedValue()
    {
        var counter = new Counter();

        var returned = counter.Increment();

        Assert.Equal(returned, counter.Count);
    }
}
