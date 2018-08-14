using System;
using MvvmCross.Droid.Support.V7.AppCompat;
using SDC.Coach.ViewModels;
using Android.App;
using Android.OS;

namespace SDC.Coach.Droid.Views
{
    [Activity]
    public class GroupsView : MvxAppCompatActivity<GroupsViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.GroupsView);
        }
    }
}
