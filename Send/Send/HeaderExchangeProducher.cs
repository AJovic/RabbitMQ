using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Send
{
    public static class HeaderExchangeProducher
    {
        public static void Publish(IModel channel)
        {
            channel.ExchangeDeclare("demo-header-exchange", ExchangeType.Headers);




            var count = 0;

            while (true)
            {
                var message = new { Name = "Producer", Message = $"Zdravo broju:{count}" };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                var properties = channel.CreateBasicProperties();
                properties.Headers = new Dictionary<string, object> { { "account", "new" } };
                channel.BasicPublish("demo-header-exchange",string.Empty, properties, body);
                count++; ;
                Thread.Sleep(1000);
            }
        }
    }
}