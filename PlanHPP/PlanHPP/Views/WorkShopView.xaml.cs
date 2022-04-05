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
using System.Threading;

namespace PlanHPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkShopView : ContentView
    {
        public Image SmallMark = new Image();
        public Image MiddleMark = new Image();
        public Image LargeMark = new Image();
        public Image Shema = new Image();
        public List<Motor> motors;
        
        //public List<Rect> Rects;
        //public Rect CurrentRect;
        //TestLabel testLabel = new TestLabel();
        //object __lockObj = new Object();

        public WorkShopView(IDataWebService DataWebService)
        {
            //Rects = new List<Rect>();
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
            
            //motors = MotorList.motors;
            motors = await WebService.GetDataAsync();

            foreach (Motor motor in motors)
            {
                SmallMotorButton ImageIndicator = new SmallMotorButton();
                ImageButton SmallMotor = ImageIndicator.SmallMotor;
                SmallMotor.CommandParameter = Convert.ToString(motor.ID);

                Label NameLabel = new Label();
                NameLabel.Text = motor.Name;
                

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
                
                
                
                //testLabel.X = Shema.X + Shema.Width * motor.X;
                //testLabel.Y = Shema.Y + Shema.Height * motor.Y + SmallMotor.Height;
                //
                //
                //CurrentRect = new Rect(testLabel.X, testLabel.Y, NameLabel.Width, NameLabel.Height);
                //
                //Thread myThread3 = new Thread(() => MakeNameLabelPosition(Rects, NameLabel, CurrentRect));
                //myThread3.Start();
                //Rects.Add(CurrentRect);
                //
                //
                //WorkShopRelativeLayout.Children.Add(NameLabel,
                //
                //Constraint.RelativeToView(Shema, (parent, view) =>
                //{
                //    return CurrentRect.X;
                //}),
                //
                //Constraint.RelativeToView(Shema, (parent, view) =>
                //{
                //    return CurrentRect.Y;
                //}));

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
        //void MakeNameLabelPosition(List<Rect> Rects, Label name, Rect CurrentRect)
        //{
        //    lock (__lockObj)
        //    {
        //        Console.WriteLine("CurrentRectX:" + CurrentRect.X);
        //        Console.WriteLine("CurrentRectY:" + CurrentRect.Y);
        //        Console.WriteLine("NameLabelX:" + testLabel.X);
        //        Console.WriteLine("NameLabelY:" + testLabel.Y);
        //
        //        if (Rects.Count != 0)
        //        {
        //            foreach (Rect Oldrect in Rects)
        //            {
        //
        //                if (Oldrect.IntersectsWith(CurrentRect))
        //                {
        //
        //                    if (Oldrect.X < CurrentRect.X)
        //                    {
        //                        testLabel.X += Oldrect.Width;
        //                    }
        //                    else if (Oldrect.X > CurrentRect.X)
        //                    {
        //                        testLabel.X -= Oldrect.Width;
        //                    }
        //
        //                    if (Oldrect.Y < CurrentRect.Y)
        //                    {
        //                        testLabel.Y += Oldrect.Height;
        //                    }
        //                    else if (Oldrect.Y > CurrentRect.Y)
        //                    {
        //                        testLabel.Y -= Oldrect.Height;
        //                    }
        //                    CurrentRect = new Rect(testLabel.X, testLabel.Y, name.Width, name.Height);
        //
        //                    Console.WriteLine("NameLabelName:" + name.Text);
        //                    Console.WriteLine("NameLabelX:" + testLabel.X);
        //                    Console.WriteLine("NameLabelY:" + testLabel.Y);
        //                    Console.WriteLine("CurrentRectX:" + CurrentRect.X);
        //                    Console.WriteLine("CurrentRectY:" + CurrentRect.Y);
        //                    MakeNameLabelPosition(Rects, name, CurrentRect);
        //
        //
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Готов:" + name.Text);
        //                }
        //
        //            }
        //        }
        //    }
        //    
        //
        //}

        private void WorkShopRelativeLayout_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {

        }
    }
}