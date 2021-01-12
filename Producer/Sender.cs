using System;
using System.Text;
using RabbitMQ.Client;

namespace Producer
{
    public class Sender
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("BasicText", false, false, false, null);
                const string message = "Started RabbitMQ .Net core";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", "BasicText", null, body);
                Console.WriteLine("Sent message {0}....", message);

            }
            Console.WriteLine("Please press any key for exit");
            Console.ReadLine();
        }
    }
}
