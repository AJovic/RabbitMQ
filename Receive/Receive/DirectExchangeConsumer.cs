using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Receive
{
   public static class DirectExchangeConsumer
    {
        public static void Consume(IModel channel)
        {
            channel.ExchangeDeclare("demo-direct-exchange", ExchangeType.Direct);

            channel.QueueDeclare(queue: "demo-direct-queue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

            channel.QueueBind("demo-direct-queue", "demo-direct-exchange", "account.init");
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };
            channel.BasicConsume(queue: "demo-direct-queue",
                                 autoAck: true,
                                 consumer: consumer);

            Console.ReadLine();
        }
    }
}
