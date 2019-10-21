using SmartSearch.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace SmartSearch.Business
{
    public class Pesquisar
    {
        public async Task<Dictionary<string, string>> Search(Pesquisa pesquisa)
        {
            Dictionary<string, string> RespostaApi = new Dictionary<string, string>();
               
            var endPoints = new string[] { "arisp", "arpenp", "caged", "censec", "detran", "infocrim", "jucesp", "siel", "sivec" };
            var uri = String.Format("https://smartsearchfiap.ddns.net/api/");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("x-api-key", "QfatjqNAFBkAA40zON5z");
            foreach (var endPoint in endPoints)
            {
                var contentPost = bodyRequestEndPoint(pesquisa, endPoint);

                var resposta = await client.PostAsync(uri + endPoint, contentPost);

                if (resposta.IsSuccessStatusCode)
                {
                    RespostaApi[endPoint] = await resposta.Content.ReadAsStringAsync();
                }
            }
            return RespostaApi;
        }

        private static StringContent bodyRequestEndPoint(Pesquisa pesquisa, string endPoint)
        {
            string conteudoJson = string.Empty;
            switch (endPoint)
            {
                case "arisp":
                    conteudoJson = JsonConvert.SerializeObject(new
                    {
                        cpf = pesquisa.CPF,
                        cnpj = pesquisa.CPF
                    });
                    break;
                case "caged":
                case "detran":
                case "censec":
                case "infocrim":
                    conteudoJson = JsonConvert.SerializeObject(new
                    {
                        cpf = pesquisa.CPF,
                        cnpj = pesquisa.CPF
                    });
                    break;
                case "arpenp":
                    conteudoJson = JsonConvert.SerializeObject(new
                    {
                        cpf = pesquisa.CPF
                    });
                    break;
                case "cadesp":
                    conteudoJson = JsonConvert.SerializeObject(new
                    {
                        cnpj = pesquisa.CPF
                    });
                    break;
                case "siel":
                case "sivec":
                    conteudoJson = JsonConvert.SerializeObject(new
                    {
                        nome_completo = pesquisa.Nome
                    });
                    break;
                case "jucesp":
                    conteudoJson = JsonConvert.SerializeObject(new
                    {
                        nome_empresa = pesquisa.Nome,
                        cnpj = pesquisa.CPF
                    });
                    break;
            }
            var contentPost = new StringContent(conteudoJson, Encoding.UTF8, "application/json");
            return contentPost;
        }
    }
}