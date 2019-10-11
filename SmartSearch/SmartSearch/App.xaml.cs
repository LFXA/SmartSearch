using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SmartSearch.Views;
using SmartSearch.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SmartSearch
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();


            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
            MessagingCenter.Subscribe<LoginViewModel>(this, "LoginSucesso",
               (sender) =>
               {
                   MainPage = new MainPage();
               });
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        internal static void LoadGlobalVariables()
        {
            // Carregando a lista de Perfil para acesso Global
          
        }


        internal static void MensagemAlerta(string texto)
        {
            App.Current.MainPage.DisplayAlert("Título", texto, "Ok");
        }
    }
}
