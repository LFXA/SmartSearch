using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using SmartSearch.Models;
using SmartSearch.Views;
using System.Collections.Generic;

namespace SmartSearch.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public Pesquisa Pesquisa { get; set; }
        public Command PesquisarClickedCommand { get; set; }
       
        public ItemsViewModel()
        {
            Title = "SmartSearch";
            Pesquisa = new Pesquisa();
            PesquisarClickedCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Global.Relatorios  = await Pesquisar.Search(Pesquisa);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }


    }
}