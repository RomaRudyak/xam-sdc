using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using SDC.Coach.IoC;
using Autofac;

namespace SDC.Coach.Droid
{
    public class SdcDroidSetup<TAapp> : MvxAppCompatSetup<TAapp>
        where TAapp : class, IMvxApplication, new()
    {
        protected override IMvxIoCProvider CreateIocProvider()
        {
            return new AutofacMvxIocProvider(new ContainerBuilder().Build());
        }
    }
}
