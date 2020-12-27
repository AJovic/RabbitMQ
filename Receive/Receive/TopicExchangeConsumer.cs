using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Receive
{
    public static class TopicExchangeConsumer
    {
        public static void Consume(IModel channel)
        {
            channel.ExchangeDeclare("demo-topic-exchange", ExchangeType.Topic);

            channel.QueueDeclare(queue: "demo-topic-queue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

            channel.QueueBind("demo-topic-queue", "demo-topic-exchange", "account.*");
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };
            channel.BasicConsume(queue: "demo-topic-queue",
                                 autoAck: true,
                                 consumer: consumer);

            Console.ReadLine();
        }
    }
}
