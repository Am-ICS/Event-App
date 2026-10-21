using System.Collections.ObjectModel;
using EventsApp.Models;
using EventsApp.Services;
using EventsApp.ViewModels;
using EventsApp.Views;
using Microsoft.Extensions.Logging;
using Weather.Services;

namespace EventsApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		
		builder.Services.AddSingleton<HttpClient>(_ =>
		{
			var httpClient = new HttpClient();

			httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(
				"WeatherApp/1.0");

			return httpClient;
		});
		builder.Services.AddSingleton<IStorageService>(_=>
			new StorageService(FileSystem.AppDataDirectory, ("zip.txt"))
		);
        
        
		builder.Services.AddSingleton<ObservableCollection<Events>>();
		builder.Services.AddSingleton<ITicketmasterService>(services =>
		{
			var client = services.GetRequiredService<HttpClient>();
			string apiKey = "DtP2uAuSqUgS92AjsKilfzQXoIdfhjF4";

			return new TicketmasterService(client, apiKey);
		});

		builder.Services.AddTransient<IMainPageViewModel, MainPageViewModel>();
		builder.Services.AddTransient<MainPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
	
}
