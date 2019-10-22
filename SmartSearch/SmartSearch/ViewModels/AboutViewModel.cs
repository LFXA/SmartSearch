using SmartSearch.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SmartSearch.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ObservableCollection<Relatorio> Relatorios { get; set; }
        public Command LoadItemsCommand { get; set; }
       
        public AboutViewModel()
        {
            Title = "SmartSearch";
            Relatorios = new ObservableCollection<Relatorio>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
          
        }

       
        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Relatorios.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Relatorios.Add(item);
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