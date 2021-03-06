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
using PlanHPP.Views;
using PlanHPP.DataServices;
using System.Threading.Tasks;
using System.Threading;

namespace PlanHPP.PageModels
{


    public class WorkShopPageModel : FreshMvvm.FreshBasePageModel
    {
        #region Fields
        public int stop = 0;
        public double i = 0;
        public string _CommentText;
        public string _ViewName;
        public string _ViewSwitch;
        public int _ViewIndicator = 0;
        public double _XTranslation;
        public double _YTranslation;
        public double _YAnimation;
        public double _Scale = 0;
        public double DisplayX = (double)DeviceDisplay.MainDisplayInfo.Width / (double)DeviceDisplay.MainDisplayInfo.Density;
        public double DisplayY = (double)DeviceDisplay.MainDisplayInfo.Height / 2 / (double)DeviceDisplay.MainDisplayInfo.Density;
        public bool _IsAvailableTouchEffect;
        public WorkshopGestureContainer _FirstWorkshopGestureContainer = new WorkshopGestureContainer();
        public WorkShopView FirstWorkShopView;
        public Comment _Comment = new Comment();
        List<Motor> motors = new List<Motor>();

        #endregion

        #region Properties
        public Command ChangeLableMethod { set; get; }
        public Command ChangeCoordinatesMethod { set; get; }
        public Command AppearCommand { set; get; }
        public Command GoToTableCommand { set; get; }
        public Command RefreshWorkShopPageCommand { set; get; }
        public Command SaveCommentCommand { set; get; }
        public Command StopAnimationCommand { set; get; }
        
        public Motor SelectedMotor { set; get; }
        



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
        public string CommentText
        {
            get 
            { 
                return _CommentText; 
            }
            set 
            { 
                _CommentText = value;
                RaisePropertyChanged(nameof(CommentText));
            }
        }
        public Comment Comment
        {
            get
            {
                return _Comment;
            }

            set
            {
                _Comment = value;
                RaisePropertyChanged(nameof(Comment));
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
        public double YAnimation
        {
            get
            {
                return _YAnimation;
            }

            set
            {
                _YAnimation = value;
                RaisePropertyChanged(nameof(YAnimation));
            }
        }
        public bool IsAvailableTouchEffect
        {
            get
            {
                return _IsAvailableTouchEffect;
            }

            set
            {
                _IsAvailableTouchEffect = value;
                RaisePropertyChanged(nameof(IsAvailableTouchEffect));
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
        #endregion



        public WorkShopPageModel(IDataWebService DataWebService)
        {
            Thread myThread3 = new Thread(() => StopAnim());
            FirstWorkShopView = new WorkShopView(DataWebService);
            FirstWorkshopGestureContainer.Content = FirstWorkShopView;

            StopAnimationCommand = new Command( async () =>
            {
                if(YAnimation == -App.ScreenHeight * 0.3)
                {
                    if(stop == 0)
                    {
                        await StopAnimAsync();
                        stop = 1;
                    }
                }
                
            });

            GoToTableCommand = new Command(() =>
            {
                CoreMethods.PushPageModel<TablePageModel>();
            });
            
            RefreshWorkShopPageCommand = new Command(() =>
            {
                FirstWorkShopView = new WorkShopView(DataWebService);
                FirstWorkshopGestureContainer.Content = FirstWorkShopView;
                AppearVoid(DataWebService);
            });
            
            SaveCommentCommand = new Command(() =>
            {

                //SelectedMotor.Comments.Add(Comment);
                //DataWebService.ChangeMotor(SelectedMotor);
            });

            AppearCommand = new Command(() =>
            {
                AppearVoid(DataWebService);
            });


            ChangeLableMethod = new Command<string>((key) =>
            {
                YAnimation = - App.ScreenHeight * 0.3;
                int Key = Int32.Parse(key);
                var selectedMotors = from motor in motors
                                     where motor.ID == Key
                                     select motor;
                
                foreach (Motor motor in selectedMotors)
                {
                    ViewName = motor.Name;
                    ViewSwitch = motor.Switch;
                    ViewIndicator = motor.Indicator;
                    //Comment = motor.Comment;
                    SelectedMotor = motor;

                    FirstWorkShopView.SmallMark.TranslationX = FirstWorkShopView.Shema.Width * motor.X;
                    FirstWorkShopView.SmallMark.TranslationY = FirstWorkShopView.Shema.Height * motor.Y;

                    FirstWorkShopView.MiddleMark.TranslationX = FirstWorkShopView.Shema.Width * motor.X;
                    FirstWorkShopView.MiddleMark.TranslationY = FirstWorkShopView.Shema.Height * motor.Y;

                    FirstWorkShopView.LargeMark.TranslationX = FirstWorkShopView.Shema.Width * motor.X;
                    FirstWorkShopView.LargeMark.TranslationY = FirstWorkShopView.Shema.Height * motor.Y;
                  
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
                stop = 0;
            });
        }
        async public void AppearVoid(IDataWebService DataWebService)
        {
            motors = await DataWebService.GetDataAsync();

            if (SelectedMotor == null)
            {
                XTranslation = 0;
                YTranslation = 0;
            }
            else
            {
                var selectedMotors = from motor in motors
                                     where motor.ID == SelectedMotor.ID
                                     select motor;

                foreach (Motor motor in selectedMotors)
                {

                    ViewName = motor.Name;
                    ViewSwitch = motor.Switch;
                    ViewIndicator = motor.Indicator;
                    //Comment = motor.Comment;
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
            YAnimation = 0;
        }
        public override void ReverseInit(object returnedtdata)
        {
            SelectedMotor = returnedtdata as Motor;
        }
        public void StopAnim()
        {
            if (YAnimation != 0)
            {
                i = - App.ScreenHeight * 0.3;
                while (i < 0)
                {
                    YAnimation = i;
                    Thread.Sleep(10);
                    i += 10;
                }
                YAnimation = 0;
            }
            
        }
        public async Task StopAnimAsync()
        {
            Task task = Task.Factory.StartNew(() => StopAnim());
            
        }

    }
}

