using SmartSearch.Models;
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


            viewModel.LoadItemsCommand.Execute(null);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Relatorio;
            if (item == null)
                return;

            await Navigation.PushAsync(new DetalheRelatorioPage(new DetalheRelatorioViewModel(item)));

            ItemsListView.SelectedItem = null;
        }

        async void DetailCliked(object sender, System.EventArgs e)
        {

            await Navigation.PushAsync(new DetalheRelatorioPage(new DetalheRelatorioViewModel(Global.Relatorio)));


        }
    }
}