using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Mongo.Sdk
{
    public class MongoConnection
    {
        private static string _mongoServerUri = System.Configuration.ConfigurationManager.AppSettings["MongoServerUri"] ?? "mongodb://127.0.0.1:27017";
        private static string _mongoDataBase = System.Configuration.ConfigurationManager.AppSettings["MongoDataBase"] ?? "";

        private static MongoClient _client = null;
        public static MongoClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new MongoClient(_mongoServerUri);
                }
                
                return _client;
            }
        }

        private static IMongoDatabase _db = null;
        public static IMongoDatabase DB
        {
            get
            {
                if (_db == null)
                {
                    _db = Client.GetDatabase(_mongoDataBase);
                }

                return _db;
            }
        }

        //public static IMongoCollection<T> GetCollection<T>(string collectionName = null)
        //{
        //    collectionName = string.IsNullOrWhiteSpace(collectionName) ? typeof(T).ToString().Split('.').LastOrDefault() : collectionName;
        //    return MongoConnection.DB.GetCollection<T>(collectionName);
        //}

    }
}
