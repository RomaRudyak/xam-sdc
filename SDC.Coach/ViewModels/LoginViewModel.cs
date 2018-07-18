using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using SDC.Coach.Models;
using Plugin.GoogleClient;
using Plugin.GoogleClient.Shared;
using MvvmCross.Commands;

namespace SDC.Coach.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public UserProfile User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        public bool IsLoggedIn
        {
            get => _isLoggedIn;
            set => SetProperty(ref _isLoggedIn, value);
        }

        public ICommand LoginCommand { get; set; }
        public ICommand LogoutCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new MvxCommand(LoginAsync);
            LogoutCommand = new MvxCommand(Logout);
            _googleClientManager = CrossGoogleClient.Current;
            IsLoggedIn = false;
        }

        public async void LoginAsync()
        {
            try
            {
                var res = await _googleClientManager.LoginAsync();
                OnLoginCompleted(res);
            }
            //catch (GoogleClientSignInNetworkErrorException e)
            //{
            //	await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            //}
            //catch (GoogleClientSignInCanceledErrorException e)
            //         {
            //             await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            //         }
            //catch (GoogleClientSignInInvalidAccountErrorException e)
            //         {
            //             await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            //         }
            //catch (GoogleClientSignInInternalErrorException e)
            //{
            //    await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            //}
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
                User = null;
                return;
            }

            GoogleUser googleUser = loginEventArgs.Data;

            var user = new UserProfile
            {
                Name = googleUser.Name,
                Email = googleUser.Email,
                Picture = googleUser.Picture,
            };

            User = user;

            // Log the current User email
            Debug.WriteLine(User.Email);
            IsLoggedIn = true;
        }


        public void Logout()
        {
            _googleClientManager.OnLogout += OnLogoutCompleted;
            _googleClientManager.Logout();
        }

        private void OnLogoutCompleted(object sender, EventArgs loginEventArgs)
        {
            IsLoggedIn = false;
            User.Email = "Offline";
            _googleClientManager.OnLogout -= OnLogoutCompleted;
        }
        private static void OnError(string message) => Debug.WriteLine(message);


        private readonly IGoogleClientManager _googleClientManager;
        private UserProfile _user;
        private bool _isLoggedIn;

    }
}
