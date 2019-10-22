using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSearch.Models
{
    public class Relatorio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public String CPF { get; set; }
        public DateTime Data { get; set; }
        public string Telefone { get;  set; }
        public string RazaoSocial { get; internal set; }
        public string CNPJ { get; internal set; }
        public string Logradouro { get; internal set; }
        public string CEP { get; internal set; }
    }
}
