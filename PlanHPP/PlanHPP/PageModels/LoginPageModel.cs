using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PlanHPP.PageModels
{
    public class LoginPageModel : FreshMvvm.FreshBasePageModel
    {
        public Command GoToWorkShopCommand { get; set; }
        public LoginPageModel()
        {
            GoToWorkShopCommand = new Command(() =>
            {
                CoreMethods.PushPageModel<WorkShopPageModel>();
            });
        }

    }
}
