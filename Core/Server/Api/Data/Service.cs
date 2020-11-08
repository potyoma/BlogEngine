using BlogEngineApi.Models;
using Microsoft.AspNetCore.Mvc.Controllers;
using MongoDB.Driver;

namespace BlogEngineApi.Data
{
    public class Service
    {
        protected MongoClient Client { get; set; }
        protected IMongoDatabase Database { get; set; }

        public Service(IDatabaseSettings settings)
        {
            Client = new MongoClient(settings.ConnectionString);
            Database = Client.GetDatabase(settings.DatabaseName);
        }
    }
}