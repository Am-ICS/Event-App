using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using EventsApp.Models;
using Newtonsoft.Json;

namespace EventsApp.Services;

public partial class TicketmasterService : ObservableObject, ITicketmasterService
{
    private HttpClient client;
    [ObservableProperty] private ObservableCollection<Events> events = new();

    private readonly string TICKETMASTER_BASE_URL =
        "https://app.ticketmaster.com/discovery/v2/";

    private string apiKey;

    public TicketmasterService(HttpClient client, string apiKey)
    {
        this.client = client;
        this.apiKey = apiKey;
    }

    private async Task<dynamic> GetAsync(string url)
    {
        Uri uri = new Uri(url);
        HttpResponseMessage response = await client.GetAsync(uri);
        String responseContent = await response.Content.ReadAsStringAsync();
        dynamic json = JsonConvert.DeserializeObject<dynamic>(responseContent);
        return json;
    }

    public async Task<dynamic> GetEvents()
    {
        string url =
            $"{TICKETMASTER_BASE_URL}events.json" +
            $"?apikey={apiKey}" +
            $"&countryCode=US" +
            $"&size=200";

        return await GetAsync(url);
    }

    public List<Events> AddEvents(dynamic response)
    {
        List<Events> events = new List<Events>();

        if (response?._embedded?.events == null)
        {
            return events;
        }

        foreach (var item in response._embedded.events)
        {
            events.Add(new Events
            {
                Name = item.name,
                Date = item.dates?.start?.localDate,
                Time = item.dates?.start?.localTime,
                Venue = item._embedded?.venues?[0]?.name,
                City = item._embedded?.venues?[0]?.city?.name,
                State = item._embedded?.venues?[0]?.state?.stateCode,
                ImageUrl = item.images?[0]?.url,
                TicketUrl = item.url
            });
        }

        return events;
    }
    public async Task<dynamic> GetEventsByState(string state)
    {
        string url =
            $"{TICKETMASTER_BASE_URL}events.json" +
            $"?apikey={apiKey}" +
            $"&countryCode=US" +
            $"&stateCode={state}";

        return await GetAsync(url);
    }
    public async Task<dynamic> GetEventsByCity(string city)
    {
        string url =
            $"{TICKETMASTER_BASE_URL}events.json" +
            $"?apikey={apiKey}" +
            $"&countryCode=US" +
            $"&city={Uri.EscapeDataString(city)}";

        return await GetAsync(url);
    }
}