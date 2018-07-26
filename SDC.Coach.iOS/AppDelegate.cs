using Foundation;
using Google.SignIn;
using MvvmCross.Platforms.Ios.Core;
using Plugin.GoogleClient;
using UIKit;

namespace SDC.Coach.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate<SdcIocSetup<App>, App>
    {

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            GoogleClientManager.Initialize(
                Configuration.GoogleClientIdiOS
            // , "https://www.googleapis.com/auth/drive"

            );

            // SignIn.SharedInstance.CurrentUser

            return base.FinishedLaunching(application, launchOptions);
        }

        // For iOS 9 or newer
        public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {
            return GoogleClientManager.OnOpenUrl(app, url, options);
        }
    }
}

