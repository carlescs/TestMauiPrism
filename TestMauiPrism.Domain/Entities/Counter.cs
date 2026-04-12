namespace TestMauiPrism.Domain.Entities;

public sealed class Counter
{
    public int Count { get; private set; }

    public int Increment()
    {
        Count++;
        return Count;
    }
}
