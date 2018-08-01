using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using SDC.Coach.Models;
using Plugin.GoogleClient;
using Plugin.GoogleClient.Shared;
using MvvmCross.Commands;
using System.Threading.Tasks;

namespace SDC.Coach.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public Boolean IsLoggedIn => User != null;

        public UserProfile User
        {
            get => _user;
            set => SetProperty(
                ref _user,
                value,
                onChanged: () => RaisePropertyChanged(nameof(IsLoggedIn))
                );
        }

        public ICommand LoginCommand { get; set; }
        public ICommand LogoutCommand { get; set; }

        public MainViewModel(IGoogleClientManager googleClientManager)
        {
            LoginCommand = new MvxCommand(async () => await LoginAsync());
            LogoutCommand = new MvxCommand(Logout);
            _googleClientManager = googleClientManager;
        }

        private async Task LoginAsync()
        {
            try
            {
                var res = await _googleClientManager.LoginAsync();
                OnLoginCompleted(res);
            }
            catch (GoogleClientBaseException e)
            {
                OnError(e.ToString());
            }

        }


        private void OnLoginCompleted(GoogleResponse<GoogleUser> loginEventArgs)
        {
            if (loginEventArgs.Data == null)
            {
                OnError(loginEventArgs.Message);
                return;
            }

            var guser = loginEventArgs.Data;

            User = new UserProfile
            {
                Name = guser.Name,
                Email = guser.Email,
                Picture = guser.Picture
            };
        }

        private static void OnError(string message) => Debug.WriteLine(message);

        private void Logout()
        {
            _googleClientManager.Logout();
            User = null;
        }


        private readonly IGoogleClientManager _googleClientManager;
        private UserProfile _user;
    }
}
