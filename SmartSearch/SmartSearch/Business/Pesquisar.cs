using SmartSearch.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace SmartSearch.Business
{
    public class Pesquisar
    {
        public async Task<Dictionary<string, string>> Search(Pesquisa pesquisa)
        {
            Dictionary<string, string> RespostaApi = new Dictionary<string, string>();
            var conteudoJson = JsonConvert.SerializeObject(new { cpf= pesquisa.CPF,
            cnpj = pesquisa.CPF});
            var contentPost = new StringContent(conteudoJson,Encoding.UTF8,"application/json");
            var endPoints = new string[] { "arisp", "arpenp", "caged", "censec", "detran", "infocrim", "jucesp", "siel", "sivec" };
            var uri = String.Format("https://smartsearchfiap.ddns.net/api/");
            HttpClient client = new HttpClient();
            foreach (var endPoint in endPoints)
            {
                var resposta = await client.PostAsync(uri + endPoint,contentPost);
                if (resposta.IsSuccessStatusCode)
                {
                    RespostaApi[endPoint] = await resposta.Content.ReadAsStringAsync();
                }
            }
            return RespostaApi;
        }
    }
}