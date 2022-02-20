using PlanHPP.Models;
using PlanHPP.Models.Lists;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PlanHPP.PageModels
{
    public class TablePageModel : FreshMvvm.FreshBasePageModel
    {
        public List<Motor> AllTableMotors { get; set; } = MotorList.motors;
        public Motor SelectedMotor { get; set; }
        public Command GoToWorkShopCommand { set; get; }
        public TablePageModel()
        {
            GoToWorkShopCommand = new Command(() =>
            {
                CoreMethods.PopPageModel(SelectedMotor, modal: false);
            });
        }

    }
}
