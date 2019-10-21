using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using SmartSearch.Models;
using SmartSearch.Services;
using SmartSearch.Business;

namespace SmartSearch.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public Dictionary<String, String> Relatorios = Global.Relatorios;
        public IDataStore<Relatorio> DataStore => DependencyService.Get<IDataStore<Relatorio>>() ?? new MockDataStore(Relatorios);
        public IDataStore<Acesso> DataStoreAcesso => DependencyService.Get<IDataStore<Acesso>>() ?? new MockDataStoreAcesso();
        public Pesquisar Pesquisar = new Pesquisar();
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
