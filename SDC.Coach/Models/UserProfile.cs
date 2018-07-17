using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Plugin.GoogleClient.Shared;
using PropertyChanged;

namespace SDC.Coach.Models
{
    [AddINotifyPropertyChangedInterface]
    public class UserProfile
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Uri Picture { get; set; }
    }
}
