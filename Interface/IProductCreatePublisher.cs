using UseOfMastransistForRabbitMQ.Models;

public interface IProductCreatePublisher
{
    Task PublishProductCreated(Product product);
}
