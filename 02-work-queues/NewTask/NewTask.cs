using System;
using RabbitMQ.Client;
using System.Text;

class Send
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
        channel.BasicPublish(exchange: "", routingKey: "task_queue", basicProperties: properties, body: body);

        Console.WriteLine($" [x] Sent {message}");
        Console.WriteLine("Exiting.");
    }

    private static string GetMessage(string[] args)
    {
        return ((args.Length > 0) ? string.Join(" ", args) : "Hello, World!");
    }
}