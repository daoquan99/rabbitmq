using Newtonsoft.Json;

using RabbitMQ.Client;

using System;
using System.Text;

namespace RabbitMQ.Producer
{
    static class Program
    {
        static void Main(string[] args)
        {
            var host = "123.31.38.181";
            var port = 5672;
            var userName = "admin";
            var password = "vgy7ujm";
            var queueName = "ddth-lichhop";
            var factory = new ConnectionFactory
            {
                HostName = host,
                Port = port,
                UserName = userName,
                Password = password,
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
            
            var index = 1;
            while (true)
            {
                Console.WriteLine("================"+ (index++).ToString() + "====================" );
                Console.Write("Name: ");
                var name = Console.ReadLine();
                Console.Write("Message: ");
                var message = Console.ReadLine();
                var obj = new { Name = name, Message = message };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj));
                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                channel.BasicPublish("", queueName, null, body);
            }
        }
    }
}
