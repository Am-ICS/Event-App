using EventsApp.Models;

namespace EventsApp.Views;

public partial class EventDetailPage : ContentPage
{
    private Events _selectedEvent;

    public EventDetailPage(Events selectedEvent)
    {
        InitializeComponent();

        _selectedEvent = selectedEvent;
        BindingContext = selectedEvent;
    }
    
}