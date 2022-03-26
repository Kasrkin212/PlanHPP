using PlanHPP.DataServices;
using PlanHPP.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace PlanHPP.PageModels
{
    public class RegistrationPageModel : FreshMvvm.FreshBasePageModel
    {
        #region Fields
        public string _Name;
        public string _Surname;
        public string _Patronymic;
        public string _Password;
        public string _RepeatedPassword;
        public string _Position;
        public string _Email;
        public User user = new User();
        #endregion
        #region Properties
        public Command RegistrationCommand { get; set; }
        public Command GoToLoginPageCommand { set; get; }
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
        public string Surname
        {
            get
            {
                return _Surname;
            }

            set
            {
                _Surname = value;
                RaisePropertyChanged(nameof(Surname));
            }
        }
        public string Patronymic
        {
            get
            {
                return _Patronymic;
            }

            set
            {
                _Patronymic = value;
                RaisePropertyChanged(nameof(Patronymic));
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
        public string RepeatedPassword
        {
            get
            {
                return _RepeatedPassword;
            }

            set
            {
                _RepeatedPassword = value;
                RaisePropertyChanged(nameof(RepeatedPassword));
            }
        }
        public string Position
        {
            get
            {
                return _Position;
            }

            set
            {
                _Position = value;
                RaisePropertyChanged(nameof(Position));
            }
        }
        public string Email
        {
            get
            {
                return _Email;
            }

            set
            {
                _Email = value;
                RaisePropertyChanged(nameof(Email));
            }
        }
        #endregion

        public RegistrationPageModel(IUserWebService UserWebService)
        {
            GoToLoginPageCommand = new Command(() =>
            {
                CoreMethods.PopPageModel();
            });
            RegistrationCommand = new Command( async () =>
            {
                if(RepeatedPassword == Password)
                {
                    user.Name = Name;
                    user.Email = Email;
                    user.Password = Password;
                    user.Position = Position;
                    user.Surname = Surname;
                    user.Patronymic = Patronymic;
                    await UserWebService.SendUser(user);
                    CoreMethods.PopPageModel();
                }
                else
                {
                    Debug.WriteLine(@"\tERROR {0}");
                }
                
            });
        }
    }
}
