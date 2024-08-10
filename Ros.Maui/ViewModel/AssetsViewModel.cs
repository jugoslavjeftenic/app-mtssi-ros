using CommunityToolkit.Mvvm.Input;
using Ros.Maui.Models;
using Ros.Maui.Repositories;
using Ros.Maui.View;
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
	public async Task GoToDetailsAsync(Asset asset)
	{
		if (asset is null) return;

		await Shell
			.Current
			.GoToAsync($"{nameof(DetailsPage)}", true,
				new Dictionary<string, object>()
				{
					{"Asset", asset }
				});
	}

	[RelayCommand]
	public async Task GetAssetsAsync(string searchQuery)
	{
		if (IsBusy) return;

		try
		{
			IsBusy = true;

			// Fetch assets from repository ...
			var assets = await _assetRepository.GetAssetsAsync(searchQuery);

			// ... and clear Assets observable collection if any.
			if (assets.Count > 0) Assets.Clear();

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
