using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using PlanHPP.Models;
using PlanHPP.Models.Lists;
using Xamarin.Forms;
using PlanHPP.View;
using Xamarin.Essentials;
using System.Runtime.CompilerServices;

namespace PlanHPP.ViewModels
{


    public class VMTurbineWorkshop : INotifyPropertyChanged
    {
        public string _ViewName = "";
        public string _ViewSwitch = "";
        public int _ViewIndicator = 0;
        public double _XTranslation = 0;
        public double _YTranslation = 0;
        public double _Scale = 0;
        public double DisplayX = (double)DeviceDisplay.MainDisplayInfo.Width / (double)DeviceDisplay.MainDisplayInfo.Density;
        public double DisplayY = (double)DeviceDisplay.MainDisplayInfo.Height / 2 / (double)DeviceDisplay.MainDisplayInfo.Density;






        public ICommand ChangeLableMethod { set; get; }
        public ICommand ChangeCoordinatesMethod { set; get; }
        public Motor Motor { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public string ViewName
        {
            get
            {
                return _ViewName;
            }

            set
            {
                _ViewName = value;
                OnPropertyChanged(nameof(ViewName));
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
                OnPropertyChanged(nameof(ViewSwitch));
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
                OnPropertyChanged(nameof(ViewIndicator));
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
                OnPropertyChanged(nameof(XTranslation));
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
                OnPropertyChanged(nameof(YTranslation));
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
                OnPropertyChanged(nameof(Scale));
            }
        }

        public VMTurbineWorkshop()
        {



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
                    TurbineWorkshop.LableName.Text = motor.Name;
                    TurbineWorkshop.LableSwitch.Text = motor.Switch;
                    TurbineWorkshop.Indicator.Scale = motor.Indicator;

                    TurbineWorkshop.ButtonPressedLittle.TranslationX = TurbineWorkshop.PTZC.Width * motor.X;
                    TurbineWorkshop.ButtonPressedLittle.TranslationY = TurbineWorkshop.PTZC.Height * motor.Y;

                    TurbineWorkshop.ButtonPressedMiddle.TranslationX = TurbineWorkshop.PTZC.Width * motor.X;
                    TurbineWorkshop.ButtonPressedMiddle.TranslationY = TurbineWorkshop.PTZC.Height * motor.Y;

                    TurbineWorkshop.ButtonPressedLarge.TranslationX = TurbineWorkshop.PTZC.Width * motor.X;
                    TurbineWorkshop.ButtonPressedLarge.TranslationY = TurbineWorkshop.PTZC.Height * motor.Y;

                    if (motor.ID == 3)
                    {
                        TurbineWorkshop.ButtonPressedLittle.Scale = 0;
                        TurbineWorkshop.ButtonPressedMiddle.Scale = 0;
                        TurbineWorkshop.ButtonPressedLarge.Scale = 1;
                    }
                    else if (motor.ID == 10 || motor.ID == 11 || motor.ID == 12 || motor.ID == 13)
                    {
                        TurbineWorkshop.ButtonPressedLittle.Scale = 0;
                        TurbineWorkshop.ButtonPressedMiddle.Scale = 1;
                        TurbineWorkshop.ButtonPressedLarge.Scale = 0;
                    }
                    else
                    {
                        TurbineWorkshop.ButtonPressedLittle.Scale = 1;
                        TurbineWorkshop.ButtonPressedMiddle.Scale = 0;
                        TurbineWorkshop.ButtonPressedLarge.Scale = 0;
                    }


                }

            });
            List<Motor> Cmotors = new List<Motor>();
            Cmotors = MotorList.motors;

            ChangeCoordinatesMethod = new Command<string>((key) =>
            {

                int Key = Int32.Parse(key);
                var selectedMotors = from motor in Cmotors
                                     where motor.ID == Key
                                     select motor;

                foreach (Motor motor in selectedMotors)
                {

                    TurbineWorkshop.LableName.Text = motor.Name;
                    TurbineWorkshop.LableSwitch.Text = motor.Switch;
                    TurbineWorkshop.Indicator.Scale = motor.Indicator;
                    TurbineWorkshop.PTZC.Content.Scale = 1;


                    if ((motor.X * TurbineWorkshop.PTZC.Width) < DisplayX / 2)
                    {
                        TurbineWorkshop.PTZC.Content.TranslationX = 0;
                        XTranslation = 0;


                    }
                    else if ((motor.X * TurbineWorkshop.PTZC.Width) < (TurbineWorkshop.PTZC.Width - DisplayX / 2))
                    {
                        TurbineWorkshop.PTZC.Content.TranslationX = -((motor.X * TurbineWorkshop.PTZC.Width) - DisplayX / 2);
                        XTranslation = -((motor.X * TurbineWorkshop.PTZC.Width) - DisplayX / 2);
                    }
                    if ((motor.X * TurbineWorkshop.PTZC.Width) > (TurbineWorkshop.PTZC.Width - DisplayX / 2))
                    {
                        TurbineWorkshop.PTZC.Content.TranslationX = -(TurbineWorkshop.PTZC.Width - DisplayX);
                        XTranslation = -(TurbineWorkshop.PTZC.Width - DisplayX);
                    }




                    if ((motor.Y * TurbineWorkshop.PTZC.Height) < DisplayY / 2)
                    {
                        TurbineWorkshop.PTZC.Content.TranslationY = 0;
                        YTranslation = 0;
                    }
                    else if ((motor.Y * TurbineWorkshop.PTZC.Height) < (TurbineWorkshop.PTZC.Height - DisplayY / 2))
                    {
                        TurbineWorkshop.PTZC.Content.TranslationY = -((motor.Y * TurbineWorkshop.PTZC.Height) - DisplayY / 2);
                        YTranslation = -((motor.Y * TurbineWorkshop.PTZC.Height) - DisplayY / 2);
                    }
                    if ((motor.Y * TurbineWorkshop.PTZC.Height) > (TurbineWorkshop.PTZC.Height - DisplayY / 2))
                    {
                        TurbineWorkshop.PTZC.Content.TranslationY = -(TurbineWorkshop.PTZC.Height - DisplayY);
                        YTranslation = -(TurbineWorkshop.PTZC.Height - DisplayY);
                    }

                    TurbineWorkshop.ButtonPressedLittle.TranslationX = TurbineWorkshop.PTZC.Width * motor.X;
                    TurbineWorkshop.ButtonPressedLittle.TranslationY = TurbineWorkshop.PTZC.Height * motor.Y;

                    TurbineWorkshop.ButtonPressedMiddle.TranslationX = TurbineWorkshop.PTZC.Width * motor.X;
                    TurbineWorkshop.ButtonPressedMiddle.TranslationY = TurbineWorkshop.PTZC.Height * motor.Y;

                    TurbineWorkshop.ButtonPressedLarge.TranslationX = TurbineWorkshop.PTZC.Width * motor.X;
                    TurbineWorkshop.ButtonPressedLarge.TranslationY = TurbineWorkshop.PTZC.Height * motor.Y;

                    if (motor.ID == 3)
                    {
                        TurbineWorkshop.ButtonPressedLittle.Scale = 0;
                        TurbineWorkshop.ButtonPressedMiddle.Scale = 0;
                        TurbineWorkshop.ButtonPressedLarge.Scale = 1;
                    }
                    else if (motor.ID == 10 || motor.ID == 11 || motor.ID == 12 || motor.ID == 13)
                    {
                        TurbineWorkshop.ButtonPressedLittle.Scale = 0;
                        TurbineWorkshop.ButtonPressedMiddle.Scale = 1;
                        TurbineWorkshop.ButtonPressedLarge.Scale = 0;
                    }
                    else
                    {
                        TurbineWorkshop.ButtonPressedLittle.Scale = 1;
                        TurbineWorkshop.ButtonPressedMiddle.Scale = 0;
                        TurbineWorkshop.ButtonPressedLarge.Scale = 0;
                    }



                }

            });

        }

        void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }

    }
}

