using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Send
{
    public class QueueProducer
    {
      

        public static void Publish(IModel channel)
        {
            channel.QueueDeclare(queue: "demo-queue",
                                          durable: false,
                                          exclusive: false,
                                          autoDelete: false,
                                          arguments: null);

           

            var count = 0;

            while (true)
            {
                var message = new { Name = "Producer", Message = $"Zdravo broju:{count}" };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                channel.BasicPublish("","demo-queue",null, body);
                count++; ;
                Thread.Sleep(1000);
            }
    
        }
    }
}
