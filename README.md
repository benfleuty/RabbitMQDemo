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