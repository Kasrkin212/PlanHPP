using PlanHPP.Models;
using PlanHPP.Models.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlanHPP.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkShopView : ContentView
    {
        public Image SmallMark = new Image();
        public Image MiddleMark = new Image();
        public Image LargeMark = new Image();
        int Go = 0;
        Image Shema = new Image();
        
        public WorkShopView()
        {
            InitializeComponent();
            DownloadViews();
        }
        void DownloadViews()
        {
            MakeMap();
            MakeImageButton();
            MakeMark();
        }
        void MakeMap()
        {
            Shema = new Image { Source = "ShemaToTGOneTested.jpg" }; // сюда будет приходить изображение
            Shema.Aspect = Aspect.AspectFit;
            Shema.HorizontalOptions = LayoutOptions.Fill;
            Shema.VerticalOptions = LayoutOptions.Fill;
            
            RTLT.Children.Add(Shema,
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
        void MakeImageButton()
        {
            List<Motor> motors;
            //motors = await App.TodoManager.GetTasksAsync();
            motors = MotorList.motors;
            
            var selectedMotors = from motor in motors
                                 select motor;
            foreach (Motor motor in selectedMotors)
            {

                SmallEngineButton ImageIndicator = new SmallEngineButton();
                ImageButton SmallEngine = ImageIndicator.SmallEngine;
                SmallEngine.CommandParameter = Convert.ToString(motor.ID);


                RTLT.Children.Add(SmallEngine,

                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return Shema.X + Shema.Width * motor.X;    // установка координаты X
                }),

                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return Shema.Y + Shema.Height * motor.Y;    // установка координаты Y
                }),
                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return Shema.Width * 0.04;    // установка координаты X
                }),
                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return Shema.Height * 0.045;    // установка координаты Y
                }));

                

            }

        }
        void MakeMark()
        {
            SmallEngineButtonMark smallEngineButtonMark = new SmallEngineButtonMark();
            SmallMark = smallEngineButtonMark.SmallMark;

            MiddleEngineButtonMark MiddlEngineButtonMark = new MiddleEngineButtonMark();
            MiddleMark = MiddlEngineButtonMark.MiddleMark;

            LargeEngineButtonMark LargeEngineButtonMark = new LargeEngineButtonMark();
            LargeMark = LargeEngineButtonMark.LargeMark;

            RTLT.Children.Add(SmallMark,

                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return 0;    // установка координаты X
                }),

                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return 0;    // установка координаты Y
                }),
                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return Shema.Width * 0.04;    // установка координаты X
                }),
                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return Shema.Height * 0.045;    // установка координаты Y
                }));
            RTLT.Children.Add(MiddleMark,

                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return 0;    // установка координаты X
                }),

                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return 0;    // установка координаты Y
                }),
                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return Shema.Width * 0.04;    // установка координаты X
                }),
                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return Shema.Height * 0.045;    // установка координаты Y
                }));
            RTLT.Children.Add(LargeMark,

                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return 0;    // установка координаты X
                }),

                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return 0;    // установка координаты Y
                }),
                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return Shema.Width * 0.08;    // установка координаты X
                }),
                Constraint.RelativeToView(Shema, (parent, view) =>
                {
                    return Shema.Height * 0.10;    // установка координаты Y
                }));
        }
    }
}