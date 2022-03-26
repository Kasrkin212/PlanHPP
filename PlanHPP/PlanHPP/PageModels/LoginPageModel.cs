using PlanHPP.DataServices;
using PlanHPP.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace PlanHPP.PageModels
{
    public class LoginPageModel : FreshMvvm.FreshBasePageModel
    {
        public Command GoToWorkShopCommand { get; set; }
        public Command GoToRegistrationPageCommand { get; set; }
        public string _Name;
        public string _Password;
        public User RecivedUser;
        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                _Name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }
        public string Password
        {
            get
            {
                return _Password;
            }

            set
            {
                _Password = value;
                RaisePropertyChanged(nameof(Password));
            }
        }
        public LoginPageModel(IUserWebService UserWebService)
        {
            RecivedUser = new User();

            
            GoToWorkShopCommand = new Command( async () =>
            {
                User user = new User
                {
                    Name = Name,
                    Password = Password,
                    Email = "q",
                    Patronymic = "q",
                    Position = "q",
                    Surname = "q",
                    ID = 10
                };
                //CoreMethods.PushPageModel<WorkShopPageModel>();
                RecivedUser = await UserWebService.LoginUserAsync(Constants.UserAuthicationRestUrl, user);
                Name = RecivedUser.Name;
                if (Password == RecivedUser.Password)
                {
                    
                    CoreMethods.PushPageModel<WorkShopPageModel>();
                }
                else
                {
                    CoreMethods.PushPageModel<RegistrationPageModel>();
                }    

            });
            GoToRegistrationPageCommand = new Command(() =>
            {
                CoreMethods.PushPageModel<RegistrationPageModel>();
            });
        }

    }
}
