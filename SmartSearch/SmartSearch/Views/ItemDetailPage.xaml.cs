
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SmartSearch.ViewModels;

namespace SmartSearch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage()
        {
            InitializeComponent();
            
            BindingContext = viewModel = new ItemDetailViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Acessos.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}