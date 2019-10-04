using SmartSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSearch.Services
{
    public class MockDataStoreAcesso : IDataStore<Acesso>
    {
        List<Acesso> items;
        public MockDataStoreAcesso()
        {
            items = new List<Acesso>();
            var mockItems = new List<Acesso>
            {
                new Acesso { Id = 1, Nome="Fulano de tal", Email="lucasfaquino@gmail.com",  },
                new Acesso { Id = 2, Nome="Fulano de tal",  Email="lucasfaquino@gmail.com" },
                new Acesso { Id = 3, Nome="Fulano de tal",  Email="lucasfaquino@gmail.com"},
                new Acesso { Id = 4, Nome="Fulano de tal", Email="lucasfaquino@gmail.com"   },
                new Acesso { Id = 5, Nome="Fulano de tal", Email="lucasfaquino@gmail.com" },
                new Acesso { Id = 6, Nome="Fulano de tal",  Email="lucasfaquino@gmail.com" },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }
        public async Task<bool> AddItemAsync(Acesso item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where(arg => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Acesso> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Acesso>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<bool> UpdateItemAsync(Acesso item)
        {
            var oldItem = items.Where((arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }
    }
}
