# C# & RabbitMQ
This repo is following the C# RabbitMQ [tutorial](https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html).

### Docker information
**This is required:**  
```docker run -d -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.9-management```


## 01 - Hello, World!

This simple application creates a producer (Send) and a consumer (Receive). 
The consumer retrieves all messages in the queue 'hello'.
The producer creates a message containing "Hello World!" and sends the message to the queue. 

Running the producer script multiple times will send as many "Hello World"'s as were ran.
As long as the docker container is running, messages can be sent. Messages will remain in the queue until a consumer comes online to receive the messages.

## 01.5 - Hello, Input!

This is a modification of `01 - Hello, World!` which allows the user to input a message to be sent to the queue.


## 02 - Hello, Work Queues

This exercise introduces work queues, allowing for multiple consumers to work on tasks in a queue.

QoS balancing prevents inbalances in workloads as workers are only assigned a new task when they complete their current one.