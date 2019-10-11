using SmartSearch.Business;
using SmartSearch.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartSearch.ViewModels
{
    public class LoginViewModel
    {
        public ICommand EntrarClickedCommand { get; private set; }

        public Usuario Usuario { get; set; }

        public LoginViewModel()
        {

            Usuario = new Usuario();
            Usuario.Email = "admin@fiap.com.br";
            Usuario.Senha = "123456";


            EntrarClickedCommand = new Command(() => {
                try
                {
                    var usuario =
                        new BusinessUsuario().Login(Usuario.Email, Usuario.Senha);

                    App.LoadGlobalVariables();

                    MessagingCenter.Send<LoginViewModel>(this, "LoginSucesso");
                }
                catch (Exception ex)
                {
                    App.MensagemAlerta("Login ou senha inválida. Detalhe: " + ex.Message);
                }
            });
        }
    }
}
