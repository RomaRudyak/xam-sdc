using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Common.Apis;
using Android.Support.V7.App;
using Android.Gms.Common;
using Android.Util;
using Android.Gms.Auth.Api.SignIn;
using Android.Gms.Auth.Api;
using Plugin.GoogleClient;
using MvvmCross.Platforms.Android.Binding.Views;
using MvvmCross.Droid.Support.V7.AppCompat;
using SDC.Coach.ViewModels;
using Android.Gms.Drive;

namespace SDC.Coach.Droid.Views
{
    [Activity(
        Label = "Coach"
        , MainLauncher = true
        , NoHistory = true
        )]
    public class LoginView : MvxAppCompatActivity<LoginViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.LoginView);

            //GoogleClientManager.Initialize(this);
            GoogleClientManager.Initialize(this
                , Configuration.GoogleClientIdDroid
                , new[] { DriveClass.API }
                , new[] { Scopes.DriveFile }
            );

            // [START customize_button]
            // Set the dimensions of the sign-in button.
            var signInButton = FindViewById<SignInButton>(Resource.Id.sign_in_button);
            signInButton.SetSize(SignInButton.SizeWide);
            // [END customize_button]
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            GoogleClientManager.OnAuthCompleted(requestCode, resultCode, data);
        }
    }
}

