using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartSearch.Models;

namespace SmartSearch.Services
{
    public class MockDataStore : IDataStore<Relatorio>
    {
        List<Relatorio> items;

        public MockDataStore(Dictionary<string, string> relatorios)
        {
            items = new List<Relatorio>();

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
                items.Add(item);
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