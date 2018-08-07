using System;
using SDC.Coach.Auth;
using Plugin.GoogleClient;
namespace SDC.Coach.Google
{
    public class GoogleAuthTokenProvider : ITokenProvider
    {
        public String Token => _googleClientManager.ActiveToken;

        public Boolean HasToken => !String.IsNullOrWhiteSpace(Token);

        public GoogleAuthTokenProvider(IGoogleClientManager googleClientManager) => _googleClientManager = googleClientManager;

        private readonly IGoogleClientManager _googleClientManager;
    }
}
