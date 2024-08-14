using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Ros.Maui.Repositories;
using Ros.Maui.View;
using Ros.Maui.ViewModel;

namespace Ros.Maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		// Repository
		// builder.Services.AddSingleton<IAssetRepository, AssetInMemoryRepository>();
		builder.Services.AddSingleton<IAssetRepository, AssetSQLiteRepository>();

		// ViewModel
		builder.Services.AddSingleton<AssetsViewModel>();
		builder.Services.AddTransient<AssetDetailsViewModel>();
		builder.Services.AddTransient<SettingsViewModel>();

		// View
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<DetailsPage>();
		builder.Services.AddTransient<SettingsPage>();

		return builder.Build();
	}
}
