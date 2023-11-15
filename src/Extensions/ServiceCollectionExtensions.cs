using BlazorUiKit.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorUiKit.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUiKitServices(this IServiceCollection services)
    {
        services.AddCascadingValue<IDialogService>(static _ => new DialogService());
        services.AddCascadingValue<IBreadcrumbService>(static _ => new BreadcrumbService());

        return services;
    }
}