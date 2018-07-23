using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using SDC.Coach.IoC.Autofac;
using Autofac;
using SDC.Coach.IoC;

namespace SDC.Coach.Droid
{
    public class SdcDroidSetup<TAapp> : MvxAppCompatSetup<TAapp>
        where TAapp : class, IMvxApplication, new()
    {
        protected override IMvxIoCProvider CreateIocProvider()
        {
            return this.CretateAndInitializeAutofacProvider<SdcIoCInitializer>();
        }
    }
}
