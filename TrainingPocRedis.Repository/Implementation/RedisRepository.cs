using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RedisBoost;
using StackExchange.Redis;
using TrainingPocRedis.Domain;

namespace TrainingPocRedis.Repository
{
    public class RedisRepository<T> : IRedisRepository<T> where T : class
    {
        //private IRedisClientsPool redisDataCache;
        private IDatabase redisDataCache;
        ConfigurationOptions databaseConfig;
        public ConnectionMultiplexer redis { get; set; }
        IRedisClient redisClient;

        public RedisRepository()
        {

        }

        public RedisRepository(string dbcontext)
        {
            databaseConfig = new ConfigurationOptions();

            databaseConfig.EndPoints.Add(dbcontext + ":6379");
            databaseConfig.Password = "testeSenha";
            databaseConfig.ConnectTimeout = 100000;
            databaseConfig.SyncTimeout = 100000;


            redis = ConnectionMultiplexer.Connect(databaseConfig); //Placeholder
            redisDataCache = redis.GetDatabase();

            // Criando com o REDIS BOOST
            //redisDataCache = RedisClient.CreateClientsPool();
            //redisClient = redisDataCache.CreateClientAsync("data source = localhost:6379; initial catalog = 0").Result;
            //redisClient.AuthAsync("testeSenha");

        }


        public bool Add(string key, T entity)
        {
            // Reference for this "TEST" = https://stackoverflow.com/questions/4273743/static-implicit-operator
            RedisValue valueToInsert = JsonConvert.SerializeObject(entity);
            return redisDataCache.StringSet(key, valueToInsert);

        }

        public bool AddWithExpiration(string key, int expireTime, T entity)
        {
            //Same reference as "ADD"
            RedisValue valueToInsert = JsonConvert.SerializeObject(entity);
            return redisDataCache.StringSet(key, valueToInsert, TimeSpan.FromSeconds(expireTime));
        }

        public bool Delete(string key)
        {
            return redisDataCache.KeyDelete(key);
        }

        public Object ListById(string key)
        {

            RedisValue valueToReturn = redisDataCache.StringGet(key);

            //CAST Horroroso que deveria ser substituído na Business
            return JsonConvert.DeserializeObject<Client>(valueToReturn);
        }

        public bool Update(string key, T entity)
        {
            throw new NotImplementedException();
        }

    }
}
