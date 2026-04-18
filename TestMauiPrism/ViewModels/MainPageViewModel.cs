using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using TestMauiPrism.Application.UseCases;

namespace TestMauiPrism.ViewModels;

public sealed class MainPageViewModel : BindableBase
{
    private readonly IncrementCounterUseCase _incrementCounterUseCase;
    private readonly INavigationService _navigationService;
    private string _counterButtonText = "Click me";
    private int _currentCount;

    public MainPageViewModel(
        IncrementCounterUseCase incrementCounterUseCase,
        INavigationService navigationService)
    {
        _incrementCounterUseCase = incrementCounterUseCase;
        _navigationService = navigationService;
        IncrementCommand = new DelegateCommand(OnIncrement);
        NavigateToDetailCommand = new DelegateCommand(OnNavigateToDetail);
    }

    public string CounterButtonText
    {
        get => _counterButtonText;
        private set => SetProperty(ref _counterButtonText, value);
    }

    public DelegateCommand IncrementCommand { get; }
    public DelegateCommand NavigateToDetailCommand { get; }

    private void OnIncrement()
    {
        _currentCount = _incrementCounterUseCase.Execute();
        CounterButtonText = _currentCount == 1 ? "Clicked 1 time" : $"Clicked {_currentCount} times";
    }

    private async void OnNavigateToDetail()
    {
        var parameters = new NavigationParameters { { NavigationKeys.Count, _currentCount } };
        await _navigationService.NavigateAsync("CounterDetailPage", parameters);
    }
}
