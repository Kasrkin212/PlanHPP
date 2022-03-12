using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace PlanHPP
{
    public static class Constants
    {
        public static string RestUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000/api/Motor/" : "http://localhost:5000/api/Motor/";
    }
}
