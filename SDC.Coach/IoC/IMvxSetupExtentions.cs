using System;
using Autofac;
using MvvmCross.Core;
using MvvmCross.IoC;
using SDC.Coach.IoC.Autofac;

namespace SDC.Coach.IoC
{
    public static class IMvxSetupExtentions
    {
        public static IMvxIoCProvider CretateAndInitializeAutofacProvider<TInitializer>(this IMvxSetup setup)
            where TInitializer : AppIoCInitializer, new()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            AppIoCInitializer appIoCInitializer = new TInitializer();
            appIoCInitializer.Initialize(containerBuilder);
            IContainer container = containerBuilder.Build();
            return new AutofacMvxIocProvider(container);
        }
    }
}
