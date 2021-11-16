using Xamarin.Forms;
using Xamarin.Essentials;
using System;
namespace PlanHPP.View
{


    public partial class TurbineWorkshop : ContentPage

    {

        public delegate void AccountHandler();

        public static double PTZCWidth;
        public static double PTZCHeight;

        public static double XO1;
        public static double YO1;



        double DisplayX = (double)DeviceDisplay.MainDisplayInfo.Width / (double)DeviceDisplay.MainDisplayInfo.Density;
        double DisplayY = (double)DeviceDisplay.MainDisplayInfo.Height / 2 / (double)DeviceDisplay.MainDisplayInfo.Density;

        public TurbineWorkshop()
        {

            InitializeComponent();

        }

        private async void GoNext(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new MotorTable());
        }




    }

}
