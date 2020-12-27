using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReceiveQeue2
{
 public static   class FanotExchangeConsumer2
    {
        public static void Consume(IModel channel)
        {
            channel.ExchangeDeclare("demo-fanout-exchange", ExchangeType.Fanout);

            channel.QueueDeclare(queue: "demo-fanout-queue2",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);


            channel.QueueBind("demo-fanout-queue2", "demo-fanout-exchange", string.Empty);
            var consumer = new EventingBasicConsumer(channel);


            consumer.Received += (model, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };
            channel.BasicConsume(queue: "demo-fanout-queue2",
                                 autoAck: true,
                                 consumer: consumer);

            Console.ReadLine();
        }
    }
}
