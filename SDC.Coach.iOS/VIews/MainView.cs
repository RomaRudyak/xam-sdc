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
    public partial class MainView : MvxViewController<MainViewModel>
    {
        public SignInButton SignInButton { get; private set; }


        public MainView()
            : base(nameof(MainView), null)
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

            var set = this.CreateBindingSet<MainView, MainViewModel>();

            set.Bind(SignInButton)
               .For(c => c.BindTouchUpInside())
               .To(vm => vm.LoginCommand);
            set.Bind(SignInButton)
               .For(c => c.Hidden)
               .To(vm => vm.IsLoggedIn);

            set.Bind(LogoutButton)
               .For(c => c.BindVisible())
               .To(vm => vm.IsLoggedIn);
            set.Bind(LogoutButton)
               .For(c => c.BindTouchUpInside())
               .To(vm => vm.LogoutCommand);

            set.Bind(ViewGroupsButton)
               .For(c => c.BindVisible())
               .To(vm => vm.IsLoggedIn);
            set.Bind(ViewGroupsButton)
               .For(c => c.BindTouchUpInside())
               .To(vm => vm.GoToGroupsCommand);

            set.Apply();

        }

    }
}

