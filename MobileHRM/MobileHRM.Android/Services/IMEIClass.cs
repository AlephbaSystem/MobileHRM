using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MobileHRM.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MobileHRM.Droid.Services
{
    public class IMEIClass : IMEIInterface
    {

        Android.Telephony.TelephonyManager mTelephonyMgr;
        public string GetPhoneIMEI()
        {
            try
            {
                mTelephonyMgr = (Android.Telephony.TelephonyManager)Application.Context.GetSystemService(Context.TelephonyService);
                return mTelephonyMgr.Imei;
            }
            catch (Exception e)
            {

                throw;
            }
        }

    }
}