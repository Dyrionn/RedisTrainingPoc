using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPocRedis.Repository;
using TrainingPocRedis.Service.Contract;

namespace TrainingPocRedis.Service
{
    public class ChannelService : IChannelService
    {
        RedisRepository<Object> testRepository = new Repository.RedisRepository<Object>("localhost");

        public void PublhishChannel()
        {
            //testRepository.redis.GetDatabase().PublishAsync();
        }

        public void StopChannel()
        {
            throw new NotImplementedException();
        }
    }
}
