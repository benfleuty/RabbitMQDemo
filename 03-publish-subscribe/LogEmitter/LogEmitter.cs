using System;
using RabbitMQ.Client;
using System.Text;
using System.Threading;

class LogEmitter
{
    public static void Main(string[] args)
    {
        // Create the connection factory
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using var connection = factory.CreateConnection();

        // Create the channel for sending the message
        using var channel = connection.CreateModel();
        // define queue name and properties
        channel.QueueDeclare(queue: "task_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);

        // define the message
        string message = GetMessage(args);
        // encode the message 
        var body = Encoding.UTF8.GetBytes(message);

        // create the properties for the task
        var properties = channel.CreateBasicProperties();
        properties.Persistent = true;

        // publish (send) the message to the queue
        for (var i = 0; i < 10000; i++)
        {
            channel.BasicPublish(exchange: "", routingKey: "task_queue", basicProperties: properties, body: body);
            Thread.Sleep(100);
        }

        Console.WriteLine($" [x] Sent {message}");
        Console.WriteLine("Exiting.");
    }

    private static string GetMessage(string[] args)
    {
        return ((args.Length > 0) ? string.Join(" ", args) : "Hello, World!");
    }
}