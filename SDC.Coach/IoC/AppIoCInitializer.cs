using System;
using Autofac;

namespace SDC.Coach.IoC
{
    public abstract class AppIoCInitializer
    {
        public abstract void Initialize(ContainerBuilder containerBuilder);
    }
}
