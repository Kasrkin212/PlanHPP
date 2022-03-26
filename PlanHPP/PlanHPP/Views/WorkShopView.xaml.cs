using PlanHPP.Models;
using PlanHPP.Models.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanHPP.Views.Marks;
using PlanHPP.Views.Motors;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PlanHPP.DataServices;

namespace PlanHPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkShopView : ContentView
    {
        public Image SmallMark = new Image();
        public Image MiddleMark = new Image();
        public Image LargeMark = new Image();
        Image Shema = new Image();
        
        public WorkShopView(IDataWebService DataWebService)
        {
            InitializeComponent();
            DownloadViews(DataWebService);
        }
        void DownloadViews(IDataWebService DataWebService)
        {
            MakeMap();
            MakeImageButton(DataWebService);
        }
        void MakeMap()
        {
            Shema = new Image { Source = "ShemaToTGOneTested.jpg" }; // сюда будет приходить изображение
            Shema.Aspect = Aspect.AspectFit;
            Shema.HorizontalOptions = LayoutOptions.Fill;
            Shema.VerticalOptions = LayoutOptions.Fill;


            WorkShopRelativeLayout.Children.Add(Shema,
            Constraint.RelativeToParent((parent) =>
            {
                return 0;
            }),
            Constraint.RelativeToParent((parent) =>
            {
                return 0;
            }),
            Constraint.RelativeToParent((parent) =>
            {
                return parent.Width * 1;  
            })
        );
        }
        async void MakeImageButton(IDataWebService WebService)
        {
            List<Motor> motors;
            //motors = MotorList.motors;
            motors = await WebService.GetDataAsync();

            var selectedMotors = from motor in motors
                                 select motor;
            foreach (Motor motor in selectedMotors)
            {

                SmallMotorButton ImageIndicator = new SmallMotorButton();
                ImageButton SmallMotor = ImageIndicator.SmallMotor;
                SmallMotor.CommandParameter = Convert.ToString(motor.ID);


                WorkShopRelativeLayout.Children.Add(SmallMotor,

                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return Shema.X + Shema.Width * motor.X; 
                }),

                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return Shema.Y + Shema.Height * motor.Y;  
                }),
                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return Shema.Width * 0.04;
                }),
                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return Shema.Height * 0.045;  
                }));
            }
            MakeMark();

        }
        void MakeMark()
        {
            SmallMotorButtonMark smallMotorButtonMark = new SmallMotorButtonMark();
            SmallMark = smallMotorButtonMark.SmallMark;

            MiddleMotorButtonMark MiddlMotorButtonMark = new MiddleMotorButtonMark();
            MiddleMark = MiddlMotorButtonMark.MiddleMark;

            LargeMotorButtonMark LargeMotorButtonMark = new LargeMotorButtonMark();
            LargeMark = LargeMotorButtonMark.LargeMark;

            WorkShopRelativeLayout.Children.Add(SmallMark,

                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return 0; 
                }),

                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return 0; 
                }),
                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return Shema.Width * 0.04;   
                }),
                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return Shema.Height * 0.045;  
                }));
            WorkShopRelativeLayout.Children.Add(MiddleMark,

                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return 0;   
                }),

                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return 0;   
                }),
                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return Shema.Width * 0.04;
                }),
                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return Shema.Height * 0.045;    
                }));
            WorkShopRelativeLayout.Children.Add(LargeMark,

                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return 0;    
                }),

                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return 0; 
                }),
                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return Shema.Width * 0.08;  
                }),
                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return Shema.Height * 0.10;   
                }));
        }
    }
}