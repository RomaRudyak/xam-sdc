using System;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using SDC.Coach.ViewModels;
namespace SDC.Coach
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<MainViewModel>();
        }
    }
}
