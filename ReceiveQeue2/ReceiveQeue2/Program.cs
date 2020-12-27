using RabbitMQ.Client;
using System;

namespace ReceiveQeue2
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                //QueueConsumer.Consume(channel);
                //DirectExchangeConsumer.Consume(channel);
                //TopicExchangeConsumer.Consume(channel);
                //HeaderExchangeConsumer.Consume(channel);
                FanotExchangeConsumer2.Consume(channel);
            }
        }
    }
}
