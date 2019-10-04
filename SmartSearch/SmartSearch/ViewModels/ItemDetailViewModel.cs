using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using SmartSearch.Models;
using Xamarin.Forms;

namespace SmartSearch.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {

        public ObservableCollection<Acesso> Acessos { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemDetailViewModel()
        {
            Title = "SmartSearch";
            Acessos = new ObservableCollection<Acesso>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Acessos.Clear();
                var items = await DataStoreAcesso.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Acessos.Add(item);
                }
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
