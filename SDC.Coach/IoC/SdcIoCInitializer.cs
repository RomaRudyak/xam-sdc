using System;
using Autofac;
using System.Net.Http;

namespace SDC.Coach.IoC
{
    public class SdcIoCInitializer : AppIoCInitializer
    {
        public override void Initialize(ContainerBuilder containerBuilder)
        {
            // Note: place here container specific initialization 
            // dependent on Autofact specific features.
            // To override or extend IoC with platform specifics types
            // inherit from SdcIoCInitializer on platform project
            // override Initialize add specific types after base.Initialize
            // shanged initialization type in plaform specific MvxSetup
            RegisterNetworkStructure(containerBuilder);
        }

        protected static String IoCNamePlatformHandler { get; } = nameof(IoCNamePlatformHandler);

        private static void RegisterNetworkStructure(ContainerBuilder containerBuilder)
        {
            containerBuilder.Register(c =>
            {
                HttpMessageHandler handler;

                handler = c.ResolveNamed<HttpMessageHandler>(IoCNamePlatformHandler);

                return handler;
            })
            .As<HttpMessageHandler>();
        }
    }
}
