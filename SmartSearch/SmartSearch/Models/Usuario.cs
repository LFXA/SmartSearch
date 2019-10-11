using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSearch.Models
{
   public class Usuario
    {
        private string v1;
        private string v2;

        public Usuario()
        {
        }

        public Usuario(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
