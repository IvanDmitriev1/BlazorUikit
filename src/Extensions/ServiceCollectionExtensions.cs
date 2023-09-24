using Microsoft.Extensions.DependencyInjection;
using UiKit.Abstractions.Dialog;
using UiKit.Components.Dialog;

namespace UiKit.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddUiKitServices(this IServiceCollection services)
	{
		services.AddScoped<IDialogService, DialogService>();

		return services;
	}
}