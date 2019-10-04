using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSearch.Models
{
    public enum MenuItemType
    {
        Pesquisa,
        Relatorio,
        ControleAcesso
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
