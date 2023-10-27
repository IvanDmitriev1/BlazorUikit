using BlazorUiKit.Abstractions.Dialog;
using BlazorUiKit.JsInterop;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorUiKit.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddUiKitServices(this IServiceCollection services)
	{
		services.AddScoped<IDialogService, DialogService>();

		services.AddScoped<VisibilityJsInterop>();

		return services;
	}
}