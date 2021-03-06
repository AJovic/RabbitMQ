﻿using RabbitMQ.Client;
using System;
using System.Text;

namespace Send
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                //QueueProducer.Publish(channel);
                //DirectExchangePublisher.Publish(channel);
                //TopicExchangeProducher.Publish(channel);
                //HeaderExchangeProducher.Publish(channel);
                FanoutExchangeProducher.Publish(channel);
            }
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
} 
