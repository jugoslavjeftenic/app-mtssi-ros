using Ros.Maui.ViewModel;

namespace Ros.Maui.View;

public partial class MainPage : ContentPage
{
	public MainPage(AssetsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}