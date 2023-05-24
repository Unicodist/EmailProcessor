
using EmailProcessor.Helpers;
using EmailProcessor.Models;

using Microsoft.Extensions.DependencyInjection;

namespace EmailProcessor;

public static class Configure
{
    public static IServiceCollection AddEmailContext<T>(this IServiceCollection services, AwsConfigureModel model) where T : EmailService
    {
        if (!Check.ValidateAwsConfigureModel(model))
        {
            throw new Exception("Cannot configure the Aws email provider");
        }

        EmailService.Model = model;
        services.AddSingleton<T>();
        return services;

    }
}