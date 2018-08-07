using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SDC.Coach.Auth;

namespace SDC.Coach.Google
{
    public class GoogleAuthAwareHttpMessageHandler : DelegatingHandler
    {
        public GoogleAuthAwareHttpMessageHandler(
            HttpMessageHandler innerHandler,
            ITokenProvider tokenProvider
        ) : base(innerHandler)
        {
            _tokenProvider = tokenProvider;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_tokenProvider.HasToken)
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                    "Bearer",
                    _tokenProvider.Token
                );
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("No google auth token. Sign In.");   
            }

            return base.SendAsync(request, cancellationToken);
        }


        private readonly ITokenProvider _tokenProvider;
    }
}
