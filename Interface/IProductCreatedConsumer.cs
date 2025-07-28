using MassTransit;
using UseOfMastransistForRabbitMQ.Models;

public interface IProductCreatedConsumer
{
    Task Consume(ConsumeContext<Product> context);
}
