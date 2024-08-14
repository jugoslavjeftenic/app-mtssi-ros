using CommunityToolkit.Mvvm.Input;
using Ros.Maui.Repositories;

namespace Ros.Maui.ViewModel;

public partial class SettingsViewModel : BaseViewModel
{
	private readonly IAssetRepository _assetRepository;

	public SettingsViewModel(IAssetRepository assetRepository)
	{
		Title = "Podešavanja";
		_assetRepository = assetRepository;
	}

	[RelayCommand]
	private async Task DropAndRecreateTableAsync()
	{
		await _assetRepository.DropAndRecreateTableAsync();
		await Shell
			.Current
			.DisplayAlert("Obaveštenje", "DB je uspešno ispražnjen", "Uredu");
	}
}
