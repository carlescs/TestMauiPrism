using Prism.Commands;
using Prism.Mvvm;
using TestMauiPrism.Application.UseCases;

namespace TestMauiPrism.ViewModels;

public sealed class MainPageViewModel : BindableBase
{
    private readonly IncrementCounterUseCase _incrementCounterUseCase;
    private string _counterButtonText = "Click me";

    public MainPageViewModel(IncrementCounterUseCase incrementCounterUseCase)
    {
        _incrementCounterUseCase = incrementCounterUseCase;
        IncrementCommand = new DelegateCommand(OnIncrement);
    }

    public string CounterButtonText
    {
        get => _counterButtonText;
        private set => SetProperty(ref _counterButtonText, value);
    }

    public DelegateCommand IncrementCommand { get; }

    private void OnIncrement()
    {
        var count = _incrementCounterUseCase.Execute();
        CounterButtonText = count == 1 ? "Clicked 1 time" : $"Clicked {count} times";
    }
}
