using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace PlanHPP
{
    public static class Constants
    {
        //10.0.2.2:5000
        //a5540-1dc5.b.d-f.pw
        public static string DataRestUrl = DeviceInfo.Platform == DevicePlatform.Android ? "https://a5540-1dc5.b.d-f.pw/api/Motor/" : "https://a5540-1dc5.b.d-f.pw/api/Motor/";
        public static string UserRegistrationRestUrl = DeviceInfo.Platform == DevicePlatform.Android ? "https://a5540-1dc5.b.d-f.pw/api/User/register/" : "https://a5540-1dc5.b.d-f.pw/api/User/register/";
        public static string UserAuthicationRestUrl = DeviceInfo.Platform == DevicePlatform.Android ? "https://a5540-1dc5.b.d-f.pw/api/User/login/" : "https://a5540-1dc5.b.d-f.pw/api/User/login/";
    }
}
