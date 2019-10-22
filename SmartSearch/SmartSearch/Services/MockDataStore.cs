using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartSearch.Models;

namespace SmartSearch.Services
{
    public class MockDataStore : IDataStore<Relatorio>
    {
        List<Relatorio> items;
        private Relatorio RelatorioPesquisado { get; set; }

        public MockDataStore(Dictionary<string, string> relatorios)
        {
            items = new List<Relatorio>();
            RelatorioPesquisado = new Relatorio();
            FazerObjeto(relatorios);
            Global.Relatorio = RelatorioPesquisado;
            if (RelatorioPesquisado.Nome == null)
            {
                var mockItems = new List<Relatorio>
            {
                new Relatorio { Id = 1, Nome="Fulano de tal", CPF="232.232.354-69", Data = new DateTime() },
                new Relatorio { Id = 2, Nome="Fulano de tal",  CPF="232.232.354-69", Data= new DateTime(2019,7,23,18,5,50,70) },
                new Relatorio { Id = 3, Nome="Fulano de tal",  CPF="232.232.354-69", Data= new DateTime(2019,7,8,19,5,50,70)},
                new Relatorio { Id = 4, Nome="Fulano de tal", CPF="232.232.354-69", Data= new DateTime(2019,8,23,18,5,50,70)  },
                new Relatorio { Id = 5, Nome="Fulano de tal", CPF="232.232.354-69" , Data= new DateTime(2019,9,23,18,5,50,70) },
                new Relatorio { Id = 6, Nome="Fulano de tal",  CPF="232.232.354-69", Data= new DateTime(2019,7,20,18,5,50,70) },
            };

                foreach (var item in mockItems)
                {
                    if (Global.Relatorio == null)
                        Global.Relatorio = item;
                    items.Add(item);
                }
            }
            else
                items.Add(RelatorioPesquisado);
        }

        private void FazerObjeto(Dictionary<string, string> relatorios)
        {
            RelatorioPesquisado.Id = 1;
            foreach (var item in relatorios)
            {
                var obj = JsonConvert.DeserializeObject<JObject>(item.Value);
                switch (item.Key)
                {
                    case "arisp":

                        break;
                    case "caged":
                        RelatorioPesquisado.RazaoSocial = obj.GetValue("autorizado_responsavel").ToObject<JObject>().GetValue("identificacao").ToObject<JObject>().GetValue("razao_social").ToString();
                        RelatorioPesquisado.CNPJ = obj.GetValue("autorizado_responsavel").ToObject<JObject>().GetValue("identificacao").ToObject<JObject>().GetValue("cnpj").ToString();
                        RelatorioPesquisado.Logradouro = obj.GetValue("autorizado_responsavel").ToObject<JObject>().GetValue("dados_cadastrais_atualizados").ToObject<JObject>().GetValue("logradouro").ToString();
                        RelatorioPesquisado.CEP = obj.GetValue("autorizado_responsavel").ToObject<JObject>().GetValue("dados_cadastrais_atualizados").ToObject<JObject>().GetValue("cep").ToString();
                        RelatorioPesquisado.Nome = obj.GetValue("autorizado_responsavel").ToObject<JObject>().GetValue("contato").ToObject<JObject>().GetValue("nome").ToString();
                        RelatorioPesquisado.CPF = obj.GetValue("autorizado_responsavel").ToObject<JObject>().GetValue("contato").ToObject<JObject>().GetValue("cpf").ToString();
                        RelatorioPesquisado.Telefone = obj.GetValue("autorizado_responsavel").ToObject<JObject>().GetValue("contato").ToObject<JObject>().GetValue("telefone").ToString();
                        break;
                    case "detran":
                    case "censec":
                    case "infocrim":

                        break;
                    case "arpenp":

                        RelatorioPesquisado.Data = DateTime.ParseExact(obj.GetValue("data_ocorrido").ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        RelatorioPesquisado.Telefone = obj.GetValue("telefone_requerente").ToString();
                        break;
                    case "cadesp":

                        break;
                    case "siel":
                    case "sivec":

                        break;
                    case "jucesp":

                        break;
                }

            }
        }

        public async Task<bool> AddItemAsync(Relatorio item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Relatorio item)
        {
            var oldItem = items.Where((Relatorio arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((Relatorio arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Relatorio> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Relatorio>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}