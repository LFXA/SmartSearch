using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using SmartSearch.Models;
using SmartSearch.Views;

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
           // LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            
        }

        
    }
}