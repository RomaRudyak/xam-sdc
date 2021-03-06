﻿using System;
using Autofac;
using SDC.Coach.Google.Drive;
using Refit;
using System.Net.Http;
using SDC.Coach.Google.Sheets;
using SDC.Coach.Google;
using Plugin.GoogleClient;

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
            RegisterGoogleRestIntegration(containerBuilder);
            RegisterPlugins(containerBuilder);
        }

        protected static String IoCNamePlatformHandler { get; } = nameof(IoCNamePlatformHandler);
        protected static String IoCNameHttpClientDrive { get; } = "DriveRest";
        protected static String IoCNameHttpClientSheets { get; } = "SheetsRest";

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

        private static void RegisterGoogleRestIntegration(ContainerBuilder containerBuilder)
        {
            const string urlRestDrive = "https://www.googleapis.com/drive/v3/";
            const string urlRestSheets = "https://sheets.googleapis.com/v4/";


            containerBuilder
                .Register(c => new GoogleAuthAwareHttpMessageHandler(
                            c.Resolve<HttpMessageHandler>(),
                            new GoogleAuthTokenProvider(c.Resolve<IGoogleClientManager>())
                        ))
                .As<GoogleAuthAwareHttpMessageHandler>()
                .SingleInstance();

            containerBuilder
                .Register(c => new HttpClient(c.Resolve<GoogleAuthAwareHttpMessageHandler>()) 
                {
                    BaseAddress = new Uri(urlRestDrive) 
                })
                .Named<HttpClient>(IoCNameHttpClientDrive)
                .SingleInstance();
            
            containerBuilder
                .Register(c => new HttpClient(c.Resolve<GoogleAuthAwareHttpMessageHandler>())
                {
                    BaseAddress = new Uri(urlRestSheets)
                })
                .Named<HttpClient>(IoCNameHttpClientSheets)
                .SingleInstance();

            containerBuilder
                .Register(c => RestService.For<IDrive>(c.ResolveNamed<HttpClient>(IoCNameHttpClientDrive)))
                .As<IDrive>();

            containerBuilder
                .Register(c => RestService.For<ISheets>(c.ResolveNamed<HttpClient>(IoCNameHttpClientSheets)))
                .As<ISheets>();
        }

        private static void RegisterPlugins(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .Register(c => Plugin.GoogleClient.CrossGoogleClient.Current)
                .AsSelf()
                .ExternallyOwned();
        }

    }
}
