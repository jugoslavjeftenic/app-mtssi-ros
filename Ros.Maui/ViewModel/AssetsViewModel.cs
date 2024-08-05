using CommunityToolkit.Mvvm.Input;
using Ros.Maui.Models;
using Ros.Maui.Repositories;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Ros.Maui.ViewModel;

public partial class AssetsViewModel : BaseViewModel
{
	private readonly IAssetRepository _assetRepository;

	public ObservableCollection<Asset> Assets { get; } = [];

	public AssetsViewModel(IAssetRepository assetRepository)
	{
		Title = "Registar osnovnih sredstava";
		_assetRepository = assetRepository;
	}

	[RelayCommand]
	public async Task GetAssetsAsync()
	{
		if (IsBusy) return;

		try
		{
			IsBusy = true;

			// Fetch assets from repository ...
			var assets = await _assetRepository.GetAssetsAsync();

			// ... and clear Assets observable collection if any.
			if (assets.Count.Equals(0) is false) Assets.Clear();

			// Populate Assets observable collection with fetched assets.
			foreach (var asset in assets) Assets.Add(asset); // TODO: AddRange
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell
				.Current
				.DisplayAlert("Error!", $"Unable to get assets: {ex.Message}", "OK");
		}
		finally
		{
			IsBusy = false;
		}
	}
}
