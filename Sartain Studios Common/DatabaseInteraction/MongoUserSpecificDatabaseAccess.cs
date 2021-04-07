using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseInteraction.Interfaces;
using DatabaseInteraction.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace DatabaseInteraction
{
    public class MongoUserSpecificDatabaseAccess<TEntity> : IUserSpecificDatabaseAccess<TEntity> where TEntity : EntityBase
    {
        protected IMongoDatabase MongoDatabase;
        protected IMongoCollection<TEntity> Items;

        protected MongoUserSpecificDatabaseAccess(IConfiguration configuration)
        {
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(string userId)
        {
            return await CheckExceptions(async () => (await Items.FindAsync(item => true && item.UserId.Equals(userId))).ToList());
        }

        public async Task<TEntity> GetByIdAsync(string userId, string id)
        {
            return await CheckExceptions(async () => (await Items.FindAsync(item => item.Id == id && item.UserId.Equals(userId))).FirstOrDefault());
        }

        public async Task UpdateAsync(string userId, string id, TEntity entity)
        {
            await CheckExceptions(async () => await Items.ReplaceOneAsync(item => item.Id == id && item.UserId.Equals(userId), entity));
        }

        public async Task<string> CreateAsync(string userId, TEntity entity)
        {
            entity.UserId = userId;

            await CheckExceptions(async () => await Items.InsertOneAsync(entity));

            return entity.Id;
        }

        public async Task DeleteAsync(string userId, string id)
        {
            await CheckExceptions(async () => await Items.DeleteOneAsync(item => item.Id == id && item.UserId.Equals(userId)));
        }

        public void SetupConnectionAsync(ConnectionModel connectionModel)
        {
            try
            {
                var mongoClient = new MongoClient(connectionModel.ConnectionString);
                MongoDatabase = mongoClient.GetDatabase(connectionModel.DatabaseName);
            }
            catch (NullReferenceException nullReferenceException)
            {
                throw new NullReferenceException("Unable to connect to the database", nullReferenceException);
            }
            catch (ArgumentNullException argumentNullException)
            {
                throw new ArgumentNullException("Unable to connect to the database", argumentNullException);
            }
            catch (MongoClientException mongoClientException)
            {
                throw new MongoClientException("Unable to connect to the database", mongoClientException);
            }
            catch (Exception exception)
            {
                throw new Exception("Unknown exception has occurred", exception);
            }
        }

        private static T CheckExceptions<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (ArgumentNullException argumentNullException)
            {
                throw new ArgumentNullException("Unable to connect to the database", argumentNullException);
            }
            catch (TimeoutException timeoutException)
            {
                throw new TimeoutException("Unable to connect to the database", timeoutException);
            }
            catch (Exception exception)
            {
                throw new Exception("Unknown exception has occurred", exception);
            }
        }
    }
}