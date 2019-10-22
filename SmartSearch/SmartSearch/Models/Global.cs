using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSearch.Models
{
    public class Global
    {
        public static Dictionary<string,string> Relatorios { get; set; }
        public static Relatorio Relatorio { get; internal set; }
    }
}
