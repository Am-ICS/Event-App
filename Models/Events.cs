namespace EventsApp.Models;

public class Events
{
    public string Name { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
    public string Venue { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ImageUrl { get; set; }
    public string TicketUrl { get; set; }
    
    public bool IsFavorite { get; set; }
}