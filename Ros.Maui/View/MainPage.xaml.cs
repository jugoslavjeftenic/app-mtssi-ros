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

		if (sender is Entry entry)
		{
			// Unfocus to close the keyboard
			// TODO: Not always working as intended, needs testing
			entry.Unfocus();

			if (viewModel is not null)
			{
				await viewModel.GetAssetsCommand.ExecuteAsync(entry.Text);
			}
		}
	}
}