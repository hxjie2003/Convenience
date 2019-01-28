using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
//using RepositoryDocument = ETong.Mongo.Sdk.MongoDocument;

namespace ETong.Mongo.Sdk
{
    //public class MongoUpdateBuilder<TDocument> where TDocument : MongoDocument
    public class MongoUpdateBuilder<TDocument>
    {
        private UpdateDefinition<TDocument> _mongoUpdate = null;

        //private MongoUpdateBuilder()
        //{
        //}

        public static MongoUpdateBuilder<TDocument> Update()
        {
            return new MongoUpdateBuilder<TDocument>();
        }

        public MongoUpdateBuilder<TDocument> Set<TField>(Expression<Func<TDocument, TField>> field, TField value)
        {
            if (_mongoUpdate == null)
            {
                _mongoUpdate = Builders<TDocument>.Update.Set(field, value);
            }
            else
            {
                _mongoUpdate = _mongoUpdate.Set(field, value);
            }

            return this;
        }

        public UpdateDefinition<TDocument> GetMongoUpdate()
        {
            return _mongoUpdate;
        }
    }
}
