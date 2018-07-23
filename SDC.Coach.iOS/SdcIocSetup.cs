using System;
using Autofac;
using MvvmCross.IoC;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.ViewModels;
using SDC.Coach.IoC;

namespace SDC.Coach.iOS
{
    public class SdcIocSetup<TApp> : MvxIosSetup<TApp>
        where TApp : class, IMvxApplication, new()
    {
        protected override IMvxIoCProvider CreateIocProvider()
        {
            return new AutofacMvxIocProvider(new ContainerBuilder().Build());
        }
    }
}
