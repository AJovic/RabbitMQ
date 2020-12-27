using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Receive
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
                FanoutExchangeConsumer.Consume(channel);
            }
        }
    }
}
