using EventsApp.Models;

namespace EventsApp.Services;

public interface ITicketmasterService
{
    Task<dynamic> GetEvents();
    List<Events> AddEvents(dynamic response);
    Task<dynamic> GetEventsByCity(string city);
    Task<dynamic> GetEventsByState(string state);
}