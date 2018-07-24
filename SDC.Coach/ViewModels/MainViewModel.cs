using System;
using System.Threading.Tasks;
using SDC.Coach.Models;
using Plugin.GoogleClient;
namespace SDC.Coach.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public UserProfile User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        public MainViewModel(IGoogleClientManager googleClientManager)
        {
            _googleClientManager = googleClientManager;
        }


        private UserProfile _user;
        private readonly IGoogleClientManager _googleClientManager;
    }
}
