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
using PlanHPP.Gestures;

namespace PlanHPP.ViewModels
{


    public class VMTurbineWorkshop : INotifyPropertyChanged
    {
        public string _ViewName;
        public string _ViewSwitch;
        public int _ViewIndicator = 0;
        public double _XTranslation;
        public double _YTranslation;
        public double _Scale = 0;
        public double DisplayX = (double)DeviceDisplay.MainDisplayInfo.Width / (double)DeviceDisplay.MainDisplayInfo.Density;
        public double DisplayY = (double)DeviceDisplay.MainDisplayInfo.Height / 2 / (double)DeviceDisplay.MainDisplayInfo.Density;
        public WorkshopGestureContainer _PTZCC = new WorkshopGestureContainer();
        public ICommand ChangeLableMethod { set; get; }
        public ICommand ChangeCoordinatesMethod { set; get; }
        public ICommand AppearCommand { set; get; }
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
        
        public WorkShopView RTLT = new WorkShopView();
        public WorkshopGestureContainer PTZCC
        {
            get
            {
                return _PTZCC;
            }
            set
            {
                _PTZCC = value;
                OnPropertyChanged(nameof(PTZCC));
            }
        }




        public VMTurbineWorkshop()
        {


            PTZCC.Content = RTLT;

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

                    RTLT.SmallMark.TranslationX = PTZCC.Width * motor.X;
                    RTLT.SmallMark.TranslationY = PTZCC.Height * motor.Y;

                    RTLT.MiddleMark.TranslationX = PTZCC.Width * motor.X;
                    RTLT.MiddleMark.TranslationY = PTZCC.Height * motor.Y;

                    RTLT.LargeMark.TranslationX = PTZCC.Width * motor.X;
                    RTLT.LargeMark.TranslationY = PTZCC.Height * motor.Y;
                  
                    if (motor.ID == 3)
                    {
                        RTLT.SmallMark.Scale = 0;
                        RTLT.MiddleMark.Scale = 0;
                        RTLT.LargeMark.Scale = 1;
                    }
                    else if (motor.ID == 10 || motor.ID == 11 || motor.ID == 12 || motor.ID == 13)
                    {
                        RTLT.SmallMark.Scale = 0;
                        RTLT.MiddleMark.Scale = 1;
                        RTLT.LargeMark.Scale = 0;
                    }
                    else
                    {
                        RTLT.SmallMark.Scale = 1;
                        RTLT.MiddleMark.Scale = 0;
                        RTLT.LargeMark.Scale = 0;
                    }


                }

            });
            List<Motor> Cmotors = new List<Motor>();
            Cmotors = MotorList.motors;

            ChangeCoordinatesMethod = new Command<string>((key) =>
            {

                Test.KKay = Int32.Parse(key);
                var selectedMotors = from motor in Cmotors
                                     where motor.ID == Test.KKay
                                     select motor;

                foreach (Motor motor in selectedMotors)
                {

                    ViewName = motor.Name;
                    ViewSwitch = motor.Switch;
                    ViewIndicator = motor.Indicator;
                    PTZCC.Content.Scale = 1;
                  
                  
                    if ((motor.X * PTZCC.Width) < DisplayX / 2)
                    {
                        PTZCC.Content.TranslationX = 0;
                        XTranslation = 0;
                  
                  
                    }
                    else if ((motor.X * PTZCC.Width) < (PTZCC.Width - DisplayX / 2))
                    {
                        PTZCC.Content.TranslationX = -((motor.X * PTZCC.Width) - DisplayX / 2);
                        XTranslation = -((motor.X * PTZCC.Width) - DisplayX / 2);
                    }
                    if ((motor.X * PTZCC.Width) > (PTZCC.Width - DisplayX / 2))
                    {
                        PTZCC.Content.TranslationX = -(PTZCC.Width - DisplayX);
                        XTranslation = -(PTZCC.Width - DisplayX);
                    }
                  
                  
                  
                  
                    if ((motor.Y * PTZCC.Height) < DisplayY / 2)
                    {
                        PTZCC.Content.TranslationY = 0;
                        YTranslation = 0;
                    }
                    else if ((motor.Y * PTZCC.Height) < (PTZCC.Height - DisplayY / 2))
                    {
                        PTZCC.Content.TranslationY = -((motor.Y * PTZCC.Height) - DisplayY / 2);
                        YTranslation = -((motor.Y * PTZCC.Height) - DisplayY / 2);
                    }
                    if ((motor.Y * PTZCC.Height) > (PTZCC.Height - DisplayY / 2))
                    {
                        PTZCC.Content.TranslationY = -(PTZCC.Height - DisplayY);
                        YTranslation = -(PTZCC.Height - DisplayY);
                    }

                    RTLT.SmallMark.TranslationX = PTZCC.Width * motor.X;
                    RTLT.SmallMark.TranslationY = PTZCC.Height * motor.Y;

                    RTLT.MiddleMark.TranslationX = PTZCC.Width * motor.X;
                    RTLT.MiddleMark.TranslationY = PTZCC.Height * motor.Y;

                    RTLT.LargeMark.TranslationX = PTZCC.Width * motor.X;
                    RTLT.LargeMark.TranslationY = PTZCC.Height * motor.Y;
                  
                    if (motor.ID == 3)
                    {
                        RTLT.SmallMark.Scale = 0;
                        RTLT.MiddleMark.Scale = 0;
                        RTLT.LargeMark.Scale = 1;
                    }
                    else if (motor.ID == 10 || motor.ID == 11 || motor.ID == 12 || motor.ID == 13)
                    {
                        RTLT.SmallMark.Scale = 0;
                        RTLT.MiddleMark.Scale = 1;
                        RTLT.LargeMark.Scale = 0;
                    }
                    else
                    {
                        RTLT.SmallMark.Scale = 1;
                        RTLT.MiddleMark.Scale = 0;
                        RTLT.LargeMark.Scale = 0;
                    }



                }

            });

        }
        public void AppearVoid()
        {
            
            ViewName = Convert.ToString(XTranslation);
            PTZCC.Content.TranslationX = -100;
            PTZCC.Content.TranslationY = -100;
            

        }

        void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }

    }
}

