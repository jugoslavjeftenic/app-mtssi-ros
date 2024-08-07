using Ros.Maui.ViewModel;

namespace Ros.Maui.View;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(AssetDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
	}
}