using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Mongo.Sdk
{
    public class MongoCollection<TDocument>
    {

        private static IMongoCollection<TDocument> _current;
        public static IMongoCollection<TDocument> Current(string collectionName = null)
        {
            if (!string.IsNullOrWhiteSpace(collectionName))
            {
                //set
                _current = MongoCollection<TDocument>.GetCollection<TDocument>(collectionName);
            }
            else if (_current == null)
            {
                //get
                _current = MongoCollection<TDocument>.GetCollection<TDocument>(collectionName);
            }

            return _current;
        }

        public static IMongoCollection<TDocument> GetCollection<TDocument>(string collectionName = null)
        {
            collectionName = string.IsNullOrWhiteSpace(collectionName) ? typeof(TDocument).ToString().Split('.').LastOrDefault() : collectionName;
            return MongoConnection.DB.GetCollection<TDocument>(collectionName);
        }

        public static bool DelCollection<TDocument>(string collectionName = null)
        {
            var result = false;

            collectionName = string.IsNullOrWhiteSpace(collectionName) ? typeof(TDocument).ToString().Split('.').LastOrDefault() : collectionName;
            var collection = MongoConnection.DB.GetCollection<TDocument>(collectionName);
            if (collection != null)
            {
                var taskResult = MongoConnection.DB.DropCollectionAsync(collectionName);
                taskResult.Wait();
                result = taskResult.Status == TaskStatus.RanToCompletion; 
            }

            return result;
        }

    }
}
