using System;
using CoreGraphics;
using Foundation;
using Google.SignIn;
using UIKit;

namespace SDC.Coach.iOS
{
    public partial class ViewController : UIViewController, ISignInUIDelegate, ISignInDelegate
    {
        public SignInButton SignInButton { get; private set; }

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            SignInButton = new SignInButton();
            SignInButton.Frame = new CGRect(20, 100, 150, 44);
            View.AddSubview(SignInButton);

            // Assign the SignIn Delegates to receive callbacks
            SignIn.SharedInstance.UIDelegate = this;
            SignIn.SharedInstance.Delegate = this;

            // Sign the user in automatically
            SignIn.SharedInstance.SignInUserSilently();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public void DidSignIn(SignIn signIn, GoogleUser user, NSError error)
        {
            if (user != null && error == null)
            {
                // Disable the SignInButton
                SignInButton.Enabled = false;
            }
        }
    }
}
