using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Caledonia;
using R5T.Dacia;

using R5T.Norsica.Configuration;


namespace R5T.Norsica.Default
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="DotnetOperator"/> implementation of <see cref="IDotnetOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddDefaultDotnetOperator(this IServiceCollection services,
            ServiceAction<ICommandLineInvocationOperator> addCommandLineInvocationOperator,
            ServiceAction<IDotnetExecutableFilePathProvider> addDotnetExecutableFilePathProvider)
        {
            services
                .AddSingleton<IDotnetOperator, DotnetOperator>()
                .RunServiceAction(addCommandLineInvocationOperator)
                .RunServiceAction(addDotnetExecutableFilePathProvider)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="DotnetOperator"/> implementation of <see cref="IDotnetOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static ServiceAction<IDotnetOperator> AddDefaultDotnetOperatorAction(this IServiceCollection services,
            ServiceAction<ICommandLineInvocationOperator> addCommandLineInvocationOperator,
            ServiceAction<IDotnetExecutableFilePathProvider> addDotnetExecutableFilePathProvider)
        {
            var serviceAction = new ServiceAction<IDotnetOperator>(() => services.AddDefaultDotnetOperator(
                addCommandLineInvocationOperator,
                addDotnetExecutableFilePathProvider));
            return serviceAction;
        }
    }
}
