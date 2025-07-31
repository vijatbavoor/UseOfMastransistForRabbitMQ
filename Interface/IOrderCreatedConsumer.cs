using MassTransit;
using UseOfMastransistForRabbitMQ.Models;

public interface IOrderCreatedConsumer
{
    Task Consume(ConsumeContext<Product> context);
}
