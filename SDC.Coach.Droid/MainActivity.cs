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

namespace SDC.Coach.Droid
{
    [Activity(Label = "Coach", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
        , View.IOnClickListener
        , GoogleApiClient.IOnConnectionFailedListener
    {
        const string TAG = "MainActivity";

        const int RC_SIGN_IN = 9001;

        GoogleApiClient mGoogleApiClient;
        TextView mStatusTextView;
        ProgressDialog mProgressDialog;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            GoogleClientManager.Initialize(this);

            // [START customize_button]
            // Set the dimensions of the sign-in button.
            var signInButton = FindViewById<SignInButton>(Resource.Id.sign_in_button);
            signInButton.SetSize(SignInButton.SizeStandard);
            // [END customize_button]
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            GoogleClientManager.OnAuthCompleted(requestCode, resultCode, data);
        }
    }
}

