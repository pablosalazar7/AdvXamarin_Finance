using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Finance
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new MainPage());
		}

		protected override async void OnStart()
		{
			string androidAppSecret = "1f5a6b30-b668-493e-be2d-bbde53e6d0dc";
			string iOSAppSecret = "1118fb4a-386a-4296-986e-8a06accfa536";
			AppCenter.Start($"android={androidAppSecret};ios={iOSAppSecret}", typeof(Crashes), typeof(Analytics));

			bool didAppCrash = await Crashes.HasCrashedInLastSessionAsync();
			if (didAppCrash)
			{
				var crashReport = await Crashes.GetLastSessionCrashReportAsync();
			}
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
