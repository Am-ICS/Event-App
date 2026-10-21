using CommunityToolkit.Mvvm.Input;
using EventsApp.Models;

namespace EventsApp.ViewModels;

public interface IMainPageViewModel
{
    Task LoadEvents();
    IAsyncRelayCommand FilterStateCommand { get; }
    // public IRelayCommand SearchCommand { get; } 
    public IRelayCommand<Events> EventSelectedCommand { get; } 
    event Action<Events>? OnEventSelected;
}