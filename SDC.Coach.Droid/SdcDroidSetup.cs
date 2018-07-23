using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.ViewModels;

namespace SDC.Coach.Droid
{
    public class SdcDroidSetup<TAapp> : MvxAppCompatSetup<TAapp>
        where TAapp : class, IMvxApplication, new()
    {

    }
}
