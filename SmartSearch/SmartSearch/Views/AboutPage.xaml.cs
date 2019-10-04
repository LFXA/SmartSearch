using SmartSearch.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartSearch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        AboutViewModel viewModel;
        public AboutPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AboutViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Relatorios.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}