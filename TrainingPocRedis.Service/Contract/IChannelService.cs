using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPocRedis.Service.Contract
{
    public interface IChannelService
    {
        void PublhishOnChannel(string channelName, string message);
        bool SubscribeChannel(string channelName);
        
    }
}
