using System;
using Autofac.Core;
using MvvmCross.IoC;

namespace SDC.Coach.IoC.Autofac
{
    /// <summary>
    /// Autofac property injection options.
    /// </summary>
    /// <seealso cref="IAutofacPropertyInjectorOptions" />
    public class AutofacPropertyInjectorOptions : MvxPropertyInjectorOptions, IAutofacPropertyInjectorOptions
    {
        /// <summary>
        /// Gets or sets the mechanism that determines properties to inject.
        /// </summary>
        /// <value>
        /// An <see cref="IPropertySelector" /> that allows for custom determination of
        /// which properties to inject when property injection is enabled.
        /// </value>
        public IPropertySelector PropertyInjectionSelector { get; set; }
    }
}
