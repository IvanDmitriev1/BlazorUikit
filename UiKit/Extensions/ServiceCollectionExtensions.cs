using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using UiKit.Abstractions.Dialog;
using UiKit.Components.Dialog;

namespace UiKit.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddService<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this IServiceCollection services, ServiceLifetime serviceLifetime)
		where TService : class
		where TImplementation : class, TService
	{
		return serviceLifetime switch
		{
			ServiceLifetime.Singleton => services.AddSingleton<TService, TImplementation>(),
			ServiceLifetime.Scoped => services.AddScoped<TService, TImplementation>(),
			ServiceLifetime.Transient => services.AddTransient<TService, TImplementation>(),
			_ => throw new ArgumentOutOfRangeException(nameof(serviceLifetime), serviceLifetime, null)
		};
	}

	public static IServiceCollection AddService<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this IServiceCollection services, ServiceLifetime serviceLifetime)
		where TService : class
	{
		return serviceLifetime switch
		{
			ServiceLifetime.Singleton => services.AddSingleton<TService>(),
			ServiceLifetime.Scoped => services.AddScoped<TService>(),
			ServiceLifetime.Transient => services.AddTransient<TService>(),
			_ => throw new ArgumentOutOfRangeException(nameof(serviceLifetime), serviceLifetime, null)
		};
	}


	public static IServiceCollection AddUiKitServices(this IServiceCollection services)
	{
		var serviceLifeTime = RuntimeLocation.IsClientSide ? ServiceLifetime.Singleton : ServiceLifetime.Scoped;

		services.AddService<IDialogService, DialogService>(serviceLifeTime);

		return services;
	}
}