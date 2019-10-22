using SmartSearch.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSearch.ViewModels
{
   public class DetalheRelatorioViewModel:BaseViewModel
    {
        public Relatorio Item { get; set; }
        public DetalheRelatorioViewModel(Relatorio item = null)
        {
            
            Item = item;
        }
    }
}
