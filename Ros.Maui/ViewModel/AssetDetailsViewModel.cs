using CommunityToolkit.Mvvm.ComponentModel;
using Ros.Maui.Models;

namespace Ros.Maui.ViewModel;

[QueryProperty("Asset", "Asset")]
public partial class AssetDetailsViewModel : BaseViewModel
{
	public AssetDetailsViewModel()
	{
	}

	[ObservableProperty]
	private Asset? _asset;
}
