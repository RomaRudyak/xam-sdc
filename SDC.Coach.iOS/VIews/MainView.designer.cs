// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace SDC.Coach.iOS
{
    [Register ("LoginView")]
    partial class MainView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel AppNameLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AppNameLabel != null) {
                AppNameLabel.Dispose ();
                AppNameLabel = null;
            }
        }
    }
}