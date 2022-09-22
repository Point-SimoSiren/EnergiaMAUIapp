namespace EnergiaMAUIapp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new EnergyPage();
	}
}
