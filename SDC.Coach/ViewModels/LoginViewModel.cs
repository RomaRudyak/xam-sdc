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
    public class LoginViewModel : ViewModelBase
    {
        public ICommand LoginCommand { get; set; }

        public LoginViewModel(IGoogleClientManager googleClientManager)
        {
            LoginCommand = new MvxCommand(async () => await LoginAsync());
            _googleClientManager = googleClientManager;
        }

        public async Task LoginAsync()
        {
            try
            {
                var res = await _googleClientManager.LoginAsync();
                await OnLoginCompleted(res);
            }
            catch (GoogleClientBaseException e)
            {
                OnError(e.ToString());
            }

        }


        private async Task OnLoginCompleted(GoogleResponse<GoogleUser> loginEventArgs)
        {
            if (loginEventArgs.Data == null)
            {
                OnError(loginEventArgs.Message);
                return;
            }

            // Todo: find posibility to triger navigation after activity resumed after dilog hided
            await Task.Delay(1000);
            await NavigationService.Navigate<MainViewModel>();
        }

        private static void OnError(string message) => Debug.WriteLine(message);


        private readonly IGoogleClientManager _googleClientManager;

    }
}
