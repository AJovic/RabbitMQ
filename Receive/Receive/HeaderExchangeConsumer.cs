using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Receive
{
    public static class HeaderExchangeConsumer
    {
        public static void Consume(IModel channel)
        {
            channel.ExchangeDeclare("demo-header-exchange", ExchangeType.Headers);

            channel.QueueDeclare(queue: "demo-header-queue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

            var header = new Dictionary<string, object> { { "account", "new" } };

            channel.QueueBind("demo-header-queue", "demo-header-exchange",string.Empty, header);
            var consumer = new EventingBasicConsumer(channel);

          
            consumer.Received += (model, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };
            channel.BasicConsume(queue: "demo-header-queue",
                                 autoAck: true,
                                 consumer: consumer);

            Console.ReadLine();
        }
    }
}
