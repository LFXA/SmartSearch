using SmartSearch.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartSearch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{

        protected LoginViewModel loginViewModel;

        public LoginPage ()
		{
			InitializeComponent ();
		}
	}
}