using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace TestMauiPrism.ViewModels;

public sealed class CounterDetailPageViewModel : BindableBase, INavigatedAware
{
    private readonly INavigationService _navigationService;
    private string _countSummary = "No clicks yet.";

    public CounterDetailPageViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        GoBackCommand = new DelegateCommand(OnGoBack);
    }

    public string CountSummary
    {
        get => _countSummary;
        private set => SetProperty(ref _countSummary, value);
    }

    public DelegateCommand GoBackCommand { get; }

    public void OnNavigatedTo(INavigationParameters parameters)
    {
        if (parameters.TryGetValue(NavigationKeys.Count, out int count))
        {
            CountSummary = count == 1 ? "You clicked 1 time." : $"You clicked {count} times.";
        }
    }

    public void OnNavigatedFrom(INavigationParameters parameters) { }

    private async void OnGoBack()
    {
        await _navigationService.GoBackAsync();
    }
}
