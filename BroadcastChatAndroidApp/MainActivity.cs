using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content.PM;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace BroadcastChatAndroidApp
{
    [Activity(Label = "BroadcastChatAndroidApp",
              MainLauncher = true,
              Icon = "@drawable/icon",
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
              Theme = "@style/BroadcastChatAppLightTheme")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            
            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.SignInButton);

            button.Click += SignInButtonOnClick;
        }

        public async void SignInButtonOnClick(object obj, EventArgs eventArgs)
        {
            Button button = FindViewById<Button>(Resource.Id.SignInButton);
            EditText mobileTextbox = FindViewById<EditText>(Resource.Id.MobileTextbox);
            EditText passwordTextbox = FindViewById<EditText>(Resource.Id.PasswordTextbox);

            UserLoginRequest request = new UserLoginRequest()
            {
                Mobile = mobileTextbox.Text,
                Password = passwordTextbox.Text
            };
            UserLoginResponse response = await (new UserLoginService()).RunAsync(request);

            if (response.UserLogin.IsError == false)
            {
                StartActivity(typeof(UserInboxActivity));
                Finish();
            }
            else
            {
                button.Text = response.UserLogin.Message;
            }
            
        }
    }
}