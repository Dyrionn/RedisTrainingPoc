using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPocRedis.Service;

namespace TrainingPocRedis.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelService channel = new ChannelService();

            string subscriptChannel = "Batman";

            
            if(channel.SubscribeChannel(subscriptChannel)) {

                Console.WriteLine("Subscription Success");

            }

            PublishMessage();
            bool flKeepPublishing = KeepPublishing();

            while (flKeepPublishing) {
                PublishMessage();
                flKeepPublishing = KeepPublishing();
            };
            Console.ReadKey();

            void PublishMessage() {
                Console.WriteLine("Publish a message:");
                var message = Console.ReadLine();
                channel.PublhishOnChannel(subscriptChannel, message);
            }

            bool KeepPublishing() {
                Console.WriteLine("One More? Yes / No");
                return Console.ReadLine() == "Yes" ? true : false;
            }

        }
    }
}
