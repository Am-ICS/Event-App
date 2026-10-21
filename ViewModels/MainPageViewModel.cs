using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EventsApp.Models;
using EventsApp.Services;

namespace EventsApp.ViewModels;

public partial class MainPageViewModel : ObservableObject, IMainPageViewModel
{
    private ITicketmasterService ticketmasterService;
    
    [ObservableProperty]
    private ObservableCollection<Events> events = new();
    [ObservableProperty]
    
    private string searchText = "";
    
    [ObservableProperty]
    private string stateSearchText = "";
    [ObservableProperty]
    private string citySearchText = "";
    
    public event Action<Events>? OnEventSelected;

    public MainPageViewModel(ITicketmasterService ticketmasterService)
    {
        this.ticketmasterService = ticketmasterService;
    }
    public async Task LoadEvents()
    {
        dynamic response = await ticketmasterService.GetEvents();

        var events = ticketmasterService.AddEvents(response);

        Events.Clear();

        foreach (var item in events)
        {
            Events.Add(item);
        }
    }
    [RelayCommand]
    private void EventSelected(Events selectedEvent)
    {
        OnEventSelected?.Invoke(selectedEvent);
    }
    [RelayCommand]
    private async Task Search()
    {
        dynamic response = await ticketmasterService.GetEvents();

        var events = ticketmasterService.AddEvents(response);

        Events.Clear();

        foreach (var item in events)
        {
            if (string.IsNullOrWhiteSpace(SearchText) ||
                item.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
            {
                Events.Add(item);
            }
        }
    }
    [RelayCommand]
    private async Task FilterState()
    {
        dynamic response =
            await ticketmasterService.GetEventsByState(StateSearchText);

        var events = ticketmasterService.AddEvents(response);

        Events.Clear();

        foreach (var item in events)
        {
            Events.Add(item);
        }
    }
    [RelayCommand]
    private async Task FilterCity()
    {
        dynamic response =
            await ticketmasterService.GetEventsByCity(CitySearchText);

        var events = ticketmasterService.AddEvents(response);

        Events.Clear();

        foreach (var item in events)
        {
            Events.Add(item);
        }
    }
    [RelayCommand]
    private void Favorite(Events selectedEvent)
    {
        selectedEvent.IsFavorite = !selectedEvent.IsFavorite;
    }
}