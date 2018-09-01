using System;

using UIKit;
using MvvmCross.Platforms.Ios.Views;
using SDC.Coach.ViewModels;

namespace SDC.Coach.iOS.VIews
{
    public partial class GroupsView : MvxTableViewController<GroupsViewModel>
    {
        public GroupsView() : base(UITableViewStyle.Plain)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

