using MongoDB.Bson;
using MongoDB.Driver;
using SmartSearch.Models;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace SmartSearch.Services
{
    public class MongoService
    {
        string dbName = "smartsearch";
        string collectionName = "reports";

        IMongoCollection<BsonDocument> relatorioCollection;
        IMongoCollection<BsonDocument> RelatorioCollection
        {
            get
            {
                if (relatorioCollection == null)
                {
                    MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb+srv://henrique:asdarugina@cluster0-jsaku.mongodb.net/smartsearch?retryWrites=true&w=majority"));
                    
                    var mongoClient = new MongoClient(settings);
                    var db = mongoClient.GetDatabase(dbName);

                    var collectionSettings = new MongoCollectionSettings { ReadPreference = ReadPreference.Nearest };
                    relatorioCollection = db.GetCollection<BsonDocument>(collectionName, collectionSettings);
                }
                return relatorioCollection;
            }
        }

        public async Task<List<BsonDocument>> GetAllTasks()
        {
            try
            {
                var allTasks = await RelatorioCollection
                    .Find(new BsonDocument())
                    .ToListAsync();

                return allTasks;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
