using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Send
{
    public static class FanoutExchangeProducher
    {
        public static void Publish(IModel channel)
        {
            channel.ExchangeDeclare("demo-fanout-exchange", ExchangeType.Fanout);




            var count = 0;

            while (true)
            {
                var message = new { Name = "Producer", Message = $"Zdravo broju:{count}" };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));


                channel.BasicPublish("demo-fanout-exchange", string.Empty, null, body);
                count++; ;
                Thread.Sleep(1000);
            }
        }
    }
}