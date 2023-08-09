using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Mopups.Hosting;
using Syncfusion.Maui.Core.Hosting;
using Treedle.Service;
using Treedle.View;
using Treedle.ViewModel;

namespace Treedle;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
            .ConfigureSyncfusionCore()
			.ConfigureMopups()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<WordService>();

		builder.Services.AddTransient<GameViewModel>();
		

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<GamePage>();
		builder.Services.AddTransient<PlayerStatsPage>();
		builder .Services.AddTransient<NotWordPage>();

		return builder.Build();
	}
}
