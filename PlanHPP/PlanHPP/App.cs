using FreshMvvm;
using PlanHPP.DataServices;
using PlanHPP.PageModels;
using PlanHPP.Pages;
using Xamarin.Forms;

namespace PlanHPP
{
	public class App : Application
	{
		public static double ScreenWidth;
		public static double ScreenHeight;
		public App()
		{
			FreshIOC.Container.Register<IDataWebService, DataWebService>();
			FreshIOC.Container.Register<IUserWebService, UserWebService>();
			var Page = FreshMvvm.FreshPageModelResolver.ResolvePageModel<LoginPageModel>();
			var NavigationPage = new FreshNavigationContainer(Page);
			MainPage = NavigationPage;
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


