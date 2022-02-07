using PlanHPP.View;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PlanHPP
{
	public class App : Application
	{
		public static double ScreenWidth;
		public static double ScreenHeight;
		public App()
		{
			MainPage = new NavigationPage(new TurbineWorkshop());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}


