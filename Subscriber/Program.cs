using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory
{
    HostName = "localhost"
};
 var connection = factory.CreateConnection();
 using var channel = connection.CreateModel();
 channel.QueueDeclare("users",exclusive:false);
 var consumer = new EventingBasicConsumer(channel);
consumer.Received += (IModel, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"message recieved  : {message}");
};
 channel.BasicConsume(queue:"users",autoAck:true,consumer:consumer);    
 Console.ReadLine();
