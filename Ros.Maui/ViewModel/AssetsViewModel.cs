﻿using CommunityToolkit.Maui.Alerts;
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
		Title = "ROS";
		_assetRepository = assetRepository;
	}

	[RelayCommand]
	public async Task GoToSettingsAsync()
	{
		await Shell
			.Current
			.GoToAsync($"{nameof(SettingsPage)}", true);
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
		if (searchQuery is null || searchQuery.Length < 3)
		{
			await Toast.Make("Tekst pretrage mora da bude najmanje 3 karaktera.").Show();
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
				await Toast.Make("Nema rezultata pretrage.").Show();
				return;
			}
			else if (assets.Count >= 5)
			{
				await Toast.Make("Prikazuje se samo prvih 5 rezultata pretrage.").Show();
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
