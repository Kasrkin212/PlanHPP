using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using PlanHPP.Models;
using PlanHPP.Models.Lists;
using Xamarin.Forms;
using PlanHPP.Pages;
using Xamarin.Essentials;
using System.Runtime.CompilerServices;
using PlanHPP.Gestures;

namespace PlanHPP.PageModels
{


    public class WorkShopPageModel : FreshMvvm.FreshBasePageModel
    {
        public string _ViewName;
        public string _ViewSwitch;
        public int _ViewIndicator = 0;
        public double _XTranslation;
        public double _YTranslation;
        public double _Scale = 0;
        public double DisplayX = (double)DeviceDisplay.MainDisplayInfo.Width / (double)DeviceDisplay.MainDisplayInfo.Density;
        public double DisplayY = (double)DeviceDisplay.MainDisplayInfo.Height / 2 / (double)DeviceDisplay.MainDisplayInfo.Density;
        public WorkshopGestureContainer _FirstWorkshopGestureContainer = new WorkshopGestureContainer();
        public WorkShopView FirstWorkShopView = new WorkShopView();
        public int ID;
        
        public ICommand ChangeLableMethod { set; get; }
        public ICommand ChangeCoordinatesMethod { set; get; }
        public ICommand AppearCommand { set; get; }
        public Command GoToTableCommand { set; get; }
        public Motor SelectedMotor { set; get; }
        public Motor Motor { get; set; }

        
        public string ViewName
        {
            get
            {
                return _ViewName;
            }

            set
            {
                _ViewName = value;
                RaisePropertyChanged(nameof(ViewName));
            }
        }
        public string ViewSwitch
        {
            get
            {
                return _ViewSwitch;
            }

            set
            {
                _ViewSwitch = value;
                RaisePropertyChanged(nameof(ViewSwitch));
            }
        }
        public int ViewIndicator
        {
            get
            {
                return _ViewIndicator;
            }

            set
            {
                _ViewIndicator = value;
                RaisePropertyChanged(nameof(ViewIndicator));
            }
        }
        public double XTranslation
        {
            get
            {
                return _XTranslation;
            }

            set
            {
                _XTranslation = value;
                RaisePropertyChanged(nameof(XTranslation));
            }
        }
        public double YTranslation
        {
            get
            {
                return _YTranslation;
            }

            set
            {
                _YTranslation = value;
                RaisePropertyChanged(nameof(YTranslation));
            }
        }
        public double Scale
        {
            get
            {
                return _Scale;
            }

            set
            {
                _YTranslation = value;
                RaisePropertyChanged(nameof(Scale));
            }
        }
        public WorkshopGestureContainer FirstWorkshopGestureContainer
        {
            get
            {
                return _FirstWorkshopGestureContainer;
            }
            set
            {
                _FirstWorkshopGestureContainer = value;
                RaisePropertyChanged(nameof(FirstWorkshopGestureContainer));
            }
        }




        public WorkShopPageModel()
        {


            FirstWorkshopGestureContainer.Content = FirstWorkShopView;

            GoToTableCommand = new Command(() =>
            {
                CoreMethods.PushPageModel<TablePageModel>();
            });

            AppearCommand = new Command(AppearVoid);


            List<Motor> motors = new List<Motor>();
            motors = MotorList.motors;


            ChangeLableMethod = new Command<string>((key) =>
            {
                int Key = Int32.Parse(key);
                var selectedMotors = from motor in motors
                                     where motor.ID == Key
                                     select motor;
                
                foreach (Motor motor in selectedMotors)
                {
                    ViewName = motor.Name;
                    ViewSwitch = motor.Switch;
                    ViewIndicator = motor.Indicator;

                    FirstWorkShopView.SmallMark.TranslationX = FirstWorkshopGestureContainer.Width * motor.X;
                    FirstWorkShopView.SmallMark.TranslationY = FirstWorkshopGestureContainer.Height * motor.Y;

                    FirstWorkShopView.MiddleMark.TranslationX = FirstWorkshopGestureContainer.Width * motor.X;
                    FirstWorkShopView.MiddleMark.TranslationY = FirstWorkshopGestureContainer.Height * motor.Y;

                    FirstWorkShopView.LargeMark.TranslationX = FirstWorkshopGestureContainer.Width * motor.X;
                    FirstWorkShopView.LargeMark.TranslationY = FirstWorkshopGestureContainer.Height * motor.Y;
                  
                    if (motor.ID == 3)
                    {
                        FirstWorkShopView.SmallMark.Scale = 0;
                        FirstWorkShopView.MiddleMark.Scale = 0;
                        FirstWorkShopView.LargeMark.Scale = 1;
                    }
                    else if (motor.ID == 10 || motor.ID == 11 || motor.ID == 12 || motor.ID == 13)
                    {
                        FirstWorkShopView.SmallMark.Scale = 0;
                        FirstWorkShopView.MiddleMark.Scale = 1;
                        FirstWorkShopView.LargeMark.Scale = 0;
                    }
                    else
                    {
                        FirstWorkShopView.SmallMark.Scale = 1;
                        FirstWorkShopView.MiddleMark.Scale = 0;
                        FirstWorkShopView.LargeMark.Scale = 0;
                    }


                }

            });
        }
        public void AppearVoid()
        {
            List<Motor> Cmotors = new List<Motor>();
            Cmotors = MotorList.motors;

            if (SelectedMotor == null)
            {
                XTranslation = 0;
                YTranslation = 0;
            }
            else
            {
                ID = SelectedMotor.ID;
                var selectedMotors = from motor in Cmotors
                                     where motor.ID == ID
                                     select motor;

                foreach (Motor motor in selectedMotors)
                {

                    ViewName = motor.Name;
                    ViewSwitch = motor.Switch;
                    ViewIndicator = motor.Indicator;
                    FirstWorkshopGestureContainer.Content.Scale = 1;


                    if ((motor.X * FirstWorkshopGestureContainer.Width) < DisplayX / 2)
                    {
                        FirstWorkshopGestureContainer.Content.TranslationX = 0;
                        XTranslation = 0;


                    }
                    else if ((motor.X * FirstWorkshopGestureContainer.Width) < (FirstWorkshopGestureContainer.Width - DisplayX / 2))
                    {
                        FirstWorkshopGestureContainer.Content.TranslationX = -((motor.X * FirstWorkshopGestureContainer.Width) - DisplayX / 2);
                        XTranslation = -((motor.X * FirstWorkshopGestureContainer.Width) - DisplayX / 2);
                    }
                    if ((motor.X * FirstWorkshopGestureContainer.Width) > (FirstWorkshopGestureContainer.Width - DisplayX / 2))
                    {
                        FirstWorkshopGestureContainer.Content.TranslationX = -(FirstWorkshopGestureContainer.Width - DisplayX);
                        XTranslation = -(FirstWorkshopGestureContainer.Width - DisplayX);
                    }




                    if ((motor.Y * FirstWorkshopGestureContainer.Height) < DisplayY / 2)
                    {
                        FirstWorkshopGestureContainer.Content.TranslationY = 0;
                        YTranslation = 0;
                    }
                    else if ((motor.Y * FirstWorkshopGestureContainer.Height) < (FirstWorkshopGestureContainer.Height - DisplayY / 2))
                    {
                        FirstWorkshopGestureContainer.Content.TranslationY = -((motor.Y * FirstWorkshopGestureContainer.Height) - DisplayY / 2);
                        YTranslation = -((motor.Y * FirstWorkshopGestureContainer.Height) - DisplayY / 2);
                    }
                    if ((motor.Y * FirstWorkshopGestureContainer.Height) > (FirstWorkshopGestureContainer.Height - DisplayY / 2))
                    {
                        FirstWorkshopGestureContainer.Content.TranslationY = -(FirstWorkshopGestureContainer.Height - DisplayY);
                        YTranslation = -(FirstWorkshopGestureContainer.Height - DisplayY);
                    }

                    FirstWorkShopView.SmallMark.TranslationX = FirstWorkshopGestureContainer.Width * motor.X;
                    FirstWorkShopView.SmallMark.TranslationY = FirstWorkshopGestureContainer.Height * motor.Y;

                    FirstWorkShopView.MiddleMark.TranslationX = FirstWorkshopGestureContainer.Width * motor.X;
                    FirstWorkShopView.MiddleMark.TranslationY = FirstWorkshopGestureContainer.Height * motor.Y;

                    FirstWorkShopView.LargeMark.TranslationX = FirstWorkshopGestureContainer.Width * motor.X;
                    FirstWorkShopView.LargeMark.TranslationY = FirstWorkshopGestureContainer.Height * motor.Y;

                    if (motor.ID == 3)
                    {
                        FirstWorkShopView.SmallMark.Scale = 0;
                        FirstWorkShopView.MiddleMark.Scale = 0;
                        FirstWorkShopView.LargeMark.Scale = 1;
                    }
                    else if (motor.ID == 10 || motor.ID == 11 || motor.ID == 12 || motor.ID == 13)
                    {
                        FirstWorkShopView.SmallMark.Scale = 0;
                        FirstWorkShopView.MiddleMark.Scale = 1;
                        FirstWorkShopView.LargeMark.Scale = 0;
                    }
                    else
                    {
                        FirstWorkShopView.SmallMark.Scale = 1;
                        FirstWorkShopView.MiddleMark.Scale = 0;
                        FirstWorkShopView.LargeMark.Scale = 0;
                    }



                }
            }

        }
        public override void ReverseInit(object returnedtdata)
        {
            SelectedMotor = returnedtdata as Motor;
        }

    }
}

