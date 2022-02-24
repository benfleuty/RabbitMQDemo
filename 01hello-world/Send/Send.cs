using System;
using RabbitMQ.Client;
using System.Text;

class Send
{
    public static void Main()
    {
        // Create the connection factory
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using var connection = factory.CreateConnection();

        // Create the channel for sending the message
        using var channel = connection.CreateModel();
        // define queue name and properties
        channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

        // define the message
        string message = "Hello, World!";
        // encode the message 
        var body = Encoding.UTF8.GetBytes(message);

        // publish (send) the message to the queue
        channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: body);

        Console.WriteLine(" [x] Sent {0}", message);

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
    }
}