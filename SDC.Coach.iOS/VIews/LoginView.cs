using System;
using Cirrious.FluentLayouts.Touch;
using Google.SignIn;
using UIKit;
using MvvmCross.Platforms.Ios.Views;
using SDC.Coach.ViewModels;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding;

namespace SDC.Coach.iOS
{
    [MvxRootPresentation]
    public partial class LoginView : MvxViewController<LoginViewModel>
    {
        public SignInButton SignInButton { get; private set; }
        public UILabel SignInStatusLabel { get; private set; }


        public LoginView() 
            : base(nameof(LoginView), null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SignInButton = new SignInButton();
            SignInStatusLabel = new UILabel();
            SignInStatusLabel.Text = "Status";

            View.AddSubviews(
                SignInButton
                , SignInStatusLabel
            );

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
                SignInButton.WithSameCenterY(View).Plus(30f)
                , SignInButton.WithSameCenterX(View)

                , SignInStatusLabel.WithSameCenterX(View)
                , SignInStatusLabel.Above(SignInButton)
            );

            var set = this.CreateBindingSet<LoginView, LoginViewModel>();

            set.Bind(SignInButton).To(vm => vm.LoginCommand).For(c => c.BindTouchUpInside());
            set.Bind(SignInStatusLabel).To(vm => vm.IsLoggedIn);

            set.Apply();

        }

    }
}

