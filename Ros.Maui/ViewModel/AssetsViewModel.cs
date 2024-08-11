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

		// Check if search query is less then 3 characters
		// TODO: Minimal length is magic number
		if (searchQuery.Length < 3)
		{
			await Shell
				.Current
				.DisplayAlert("Obaveštenje", "Tekst pretrage mora da bude najmanje 3 karaktera.", "Uredu");
			return;
		}

		try
		{
			IsBusy = true;

			// Fetch assets from repository and clear Assets observable collection if any.
			var assets = await _assetRepository.GetAssetsAsync(searchQuery);
			if (assets.Count > 0) Assets.Clear();

			// Show a message if the search result is empty or exceeds the limit. 
			// TODO: Assets count limit is magic number
			if (assets.Count == 0)
			{
				await Shell
					.Current
					.DisplayAlert("Obaveštenje", "Nema rezultata pretrage.", "Uredu");
				return;
			}
			else if (assets.Count >= 5)
			{
				await Shell
					.Current
					.DisplayAlert("Obaveštenje", "Prikazuje se samo prvih 5 rezultata pretrage.", "OK");
			}

			// Populate Assets observable collection with fetched assets.
			// TODO: Assets.AddRange
			foreach (var asset in assets) Assets.Add(asset);
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
