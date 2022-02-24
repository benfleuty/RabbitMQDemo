using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

class Receive
{
    public static void Main()
    {
        // Create the connection factory
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using var connection = factory.CreateConnection();

        // Create the channel for receiving the message
        using var channel = connection.CreateModel();
        // define the queue name to listen to 
        channel.QueueDeclare(queue: "task_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);

        Console.WriteLine(" [*] Waiting for messages.");

        // create a new consumer that has events
        var consumer = new EventingBasicConsumer(channel);

        // event: when the consumer has received a message...
        // this event will trigger on every message until the program exits
        consumer.Received += (model, ea) =>
        {
            // ...received message converted to an array of bytes
            var body = ea.Body.ToArray();
            // 'body' is converted from UTF8 encoded bytes into a string
            var message = Encoding.UTF8.GetString(body);
            // output the received message to the console
            Console.WriteLine(" [x] Received {0}", message);
        };

        // consume and acknowledge the message
        channel.BasicConsume(queue: "task_queue", autoAck: true, consumer: consumer);

        // when enter is hit, the listener will terminate
        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();

    }
}