using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlanHPP.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MotorTable : ContentPage
    {
        public MotorTable()
        {
            InitializeComponent();
        }
        async void GoBack(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }
    }
}