using PlanHPP.Models.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlanHPP.Pages
{
    public partial class TablePage : ContentPage
    {
        public TablePage()
        {
            InitializeComponent();
            TableOfMotor.ItemsSource = MotorList.motors;
        }
    }
}