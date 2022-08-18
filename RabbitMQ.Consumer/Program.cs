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

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) => { 
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };

            channel.BasicConsume(queueName, true, consumer);

            Console.ReadLine();
        }
    }
}
