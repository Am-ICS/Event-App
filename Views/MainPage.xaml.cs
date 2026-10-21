using System.Collections.ObjectModel;
using EventsApp.Models;
using EventsApp.ViewModels;

namespace EventsApp.Views;

public partial class MainPage : ContentPage
{
    private IMainPageViewModel _viewModel;
    public ObservableCollection<Events> Events { get; set; } = new();
    
    public MainPage(IMainPageViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;
        BindingContext = viewModel;
        _viewModel.OnEventSelected += (selectedEvent) =>
            NavigateToEventDetailsPage(selectedEvent);
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await _viewModel.LoadEvents();
        });
    }
    private async void NavigateToEventDetailsPage(Events selectedEvent)
    {
        await Navigation.PushAsync(new EventDetailPage(selectedEvent));
    }
}