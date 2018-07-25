using System;
using Autofac;
using SDC.Coach.IoC;
using System.Net.Http;

namespace SDC.Coach.iOS
{
    public class IOSSdcIoCInitializer : SdcIoCInitializer
    {
        public override void Initialize(ContainerBuilder containerBuilder)
        {
            base.Initialize(containerBuilder);

            RegisterHttp(containerBuilder);
        }

        private static void RegisterHttp(ContainerBuilder containerBuilder)
        {
            containerBuilder.Register(c => new NSUrlSessionHandler())
                .Named<HttpMessageHandler>(IoCNamePlatformHandler);
        }
    }
}
