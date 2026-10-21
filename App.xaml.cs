using EventsApp.ViewModels;
using EventsApp.Views;

namespace EventsApp;

public partial class App : Application
{
	private IMainPageViewModel mainPage;
	public App(IMainPageViewModel mainPage)
	{
		this.mainPage = mainPage;
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new NavigationPage(new MainPage(mainPage)));
	}
}