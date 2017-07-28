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
        private RedisRepository<Object> _testRepository;
        public ChannelService()
        {
            _testRepository = new Repository.RedisRepository<Object>("localhost");
        }

        public void PublhishOnChannel(string channelName, string message)
        {
            _testRepository.redis.GetSubscriber().Publish(channelName, message);
        }

        public bool SubscribeChannel(string channelName)
        {
            //Test on ConsoleApp
            _testRepository.redis.GetSubscriber().Subscribe(channelName, (c, v) =>
            {
                Console.WriteLine("Got notification: " + (string)v);
            });

            //_testRepository.redis.GetSubscriber().Subscribe(channelName, (c, v) => {
            //    _testRepository.Add("channel:" + channelName + ":" + new Guid().ToString(), "notification: "  +  (string)v);
            //});

            return _testRepository.redis.GetSubscriber().IsConnected(channelName);
        }
    }
}
