using Ros.Maui.ViewModel;

namespace Ros.Maui.View;

public partial class MainPage : ContentPage
{
	public MainPage(AssetsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	private async void OnSearchCompleted(object sender, EventArgs e)
	{
		var viewModel = BindingContext as AssetsViewModel;

		if (sender is Entry entry && viewModel is not null && entry.Text?.Length > 2)
		{
			await viewModel.GetAssetsCommand.ExecuteAsync(entry.Text);
		}
		else
		{
			await DisplayAlert("Pažnja", "Pojam za pretragu mora da bude najmanje 3 karaktera.", "Uredu");
		}
	}
}