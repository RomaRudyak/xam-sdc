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


        public LoginView()
            : base(nameof(LoginView), null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SignInButton = new SignInButton();

            View.AddSubview(SignInButton);

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
                SignInButton.Below(AppNameLabel, 70f)
                , SignInButton.WithSameCenterX(AppNameLabel)
            );

            var set = this.CreateBindingSet<LoginView, LoginViewModel>();

            set.Bind(SignInButton)
               .For(c => c.BindTouchUpInside())
               .To(vm => vm.LoginCommand);
            //set.Bind(SignInStatusLabel)
            //.For(c => c.BindText())
            //.To(vm => vm.IsLoggedIn);

            set.Apply();

        }

    }
}

