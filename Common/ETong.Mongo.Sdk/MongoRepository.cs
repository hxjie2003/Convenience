using MongoDB.Bson;
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
    //public class MongoRepository<TDocument> where TDocument : MongoDocument
    public class MongoRepository<TDocument>
    {

        private string _collectionName;

        public MongoRepository(string collectionName = null)
        {
            this._collectionName = collectionName;
        }
        
        public IMongoCollection<TDocument> GetCollection(string collectionName = null)
        {
            //IMongoCollection<TDocument> docs = MongoConnection.GetCollection<TDocument>(collectionName);
            IMongoCollection<TDocument> docs = MongoCollection<TDocument>.GetCollection<TDocument>(collectionName);

            return docs;
        }

        public IMongoCollection<TOutput> GetCollection<TOutput>(string collectionName = null) where TOutput : TDocument
        {
            //OfType是依靠mongodb.net自动在monogodb的collection中增加了_t属性记下的类名做判断
            //IMongoCollection<TOutput> docs = MongoConnection.GetCollection<TDocument>(collectionName).OfType<TOutput>();
            IMongoCollection<TOutput> docs = MongoCollection<TDocument>.GetCollection<TDocument>(collectionName).OfType<TOutput>();

            return docs;
        }

        public bool Clear()
        {
            return MongoCollection<TDocument>.DelCollection<TDocument>();
        }

        public void Insert(TDocument newDoc)
        {
            var docs = GetCollection();

            docs.InsertOneAsync(newDoc).Wait();
        }

        public void Insert(List<TDocument> newDocList)
        {
            var docs = GetCollection();

            docs.InsertManyAsync(newDocList).Wait();
        }

        public DeleteResult Delete(Expression<Func<TDocument, bool>> filter = null)
        {
            if (filter == null)
            {
                return null;
            }

            var docs = GetCollection();

            var taskResult = docs.DeleteManyAsync(filter);
            taskResult.Wait();

            return taskResult.Result;
        }

        public TDocument SearchFirst(Expression<Func<TDocument, bool>> filter)
        {
            var docs = GetCollection();
            
            var taskResult = docs.Find<TDocument>(filter).FirstOrDefaultAsync();
            taskResult.Wait();

            return taskResult.Result;
        }

        public TOutput SearchFirst<TOutput>(Expression<Func<TOutput, bool>> filter) where TOutput : TDocument
        {
            var docs = GetCollection<TOutput>();

            var taskResult = docs.Find<TOutput>(filter).FirstOrDefaultAsync();
            taskResult.Wait();

            return taskResult.Result;
        }

        public List<TDocument> Search(Expression<Func<TDocument, bool>> filter, MongoPager pager = null)
        {
            if (filter == null)
            {
                return null;
            }

            var docs = GetCollection();
            var task = docs.Find<TDocument>(filter);
            if (pager != null)
            {
                task = task.Skip((pager.PageNo - 1) * pager.PageSize).Limit(pager.PageSize);
            }

            var taskResult = task.ToListAsync();
            taskResult.Wait();

            return taskResult.Result;
        }

        public List<TOutput> Search<TOutput>(Expression<Func<TOutput, bool>> filter, MongoPager pager = null) where TOutput : TDocument
        {
            if (filter == null)
            {
                return null;
            }

            var docs = GetCollection<TOutput>();
            var task = docs.Find<TOutput>(filter);
            if (pager != null)
            {
                task = task.Skip((pager.PageNo - 1) * pager.PageSize).Limit(pager.PageSize);
            }

            var taskResult = task.ToListAsync();
            taskResult.Wait();

            return taskResult.Result;
            //泛型列表向下转型例子
            //List<TOutput> outputList = docList.ConvertAll<TOutput>(new Converter<TDocument, TOutput>(o => (o as TOutput)));
        }

        public IQueryable<TDocument> AsQueryable()
        {
            var docs = GetCollection();
            return docs.AsQueryable<TDocument>();
        }

        public IQueryable<TOutput> AsQueryable<TOutput>() where TOutput : TDocument
        {
            var docs = GetCollection<TOutput>();
            return docs.AsQueryable<TOutput>();
        }

        public ReplaceOneResult Replace(Expression<Func<TDocument, bool>> filter, TDocument newDoc)
        {
            var docs = GetCollection();

            var taskResult = docs.ReplaceOneAsync(filter, newDoc);
            taskResult.Wait();

            return taskResult.Result;
        }

        public ReplaceOneResult Replace<T>(Expression<Func<T, bool>> filter, TDocument newDoc) where T : TDocument
        {
            var docs = GetCollection<T>();

            var taskResult = docs.ReplaceOneAsync(filter, (T)newDoc);
            taskResult.Wait();

            return taskResult.Result;
        }

        public UpdateResult Modify(Expression<Func<TDocument, bool>> filter, MongoUpdateBuilder<TDocument> updates)
        {
            if (filter == null)
            {
                return null;
            }

            var docs = GetCollection();
            UpdateDefinition<TDocument> update = updates.GetMongoUpdate();
            var taskResult = docs.UpdateManyAsync(filter, update);
            taskResult.Wait();

            return taskResult.Result;
        }

        public UpdateResult Modify<T>(Expression<Func<T, bool>> filter, MongoUpdateBuilder<T> updates) where T : TDocument
        {
            if (filter == null)
            {
                return null;
            }

            var docs = GetCollection<T>();
            UpdateDefinition<T> update = updates.GetMongoUpdate();
            var taskResult = docs.UpdateManyAsync(filter, update);
            taskResult.Wait();

            return taskResult.Result;
        }

        public long Count(Expression<Func<TDocument, bool>> filter)
        {
            if (filter == null)
            {
                return 0;
            }

            var docs = GetCollection();
            var task = docs.Find<TDocument>(filter);

            var taskResult = task.CountAsync();
            taskResult.Wait();

            return taskResult.Result;
        }

    }

    public class MongoPager
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
    }
}
