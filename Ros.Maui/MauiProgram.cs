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
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		// Repository
		builder.Services.AddSingleton<IAssetRepository, AssetInMemoryRepository>();

		// ViewModel
		builder.Services.AddSingleton<AssetsViewModel>();

		// View
		builder.Services.AddSingleton<MainPage>();

		return builder.Build();
	}
}
