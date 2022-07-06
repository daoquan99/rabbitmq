using RabbitMQ.Client;
using RabbitMQ.Client.Events;

using System;
using System.Text;

namespace RabbitMQ.Consumer
{
    static class Program
    {
        static void Main(string[] args)
        {
            var host = "localhost";
            var port = 5672;
            var userName = "manhquan";
            var password = "manhquan";
            var factory = new ConnectionFactory
            {
                HostName = host,
                Port = port,
                UserName = userName,
                Password = password,
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("demo-queue", durable: true, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) => { 
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };

            channel.BasicConsume("demo-queue", true, consumer);

            Console.ReadLine();
        }
    }
}
