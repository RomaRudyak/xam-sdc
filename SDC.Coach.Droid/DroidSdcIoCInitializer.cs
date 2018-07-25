using System;
using System.Net.Http;
using Autofac;
using SDC.Coach.IoC;
using Xamarin.Android.Net;

namespace SDC.Coach.Droid
{
    public class DroidSdcIoCInitializer : SdcIoCInitializer
    {
        public override void Initialize(ContainerBuilder containerBuilder)
        {
            base.Initialize(containerBuilder);

            RegisterHttp(containerBuilder);
        }

        private static void RegisterHttp(ContainerBuilder containerBuilder)
        {
            containerBuilder.Register(c => new AndroidClientHandler())
                .Named<HttpMessageHandler>(IoCNamePlatformHandler);
        }
    }
}
