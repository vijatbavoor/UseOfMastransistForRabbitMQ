using MassTransit;
using UseOfMastransistForRabbitMQ.Models;

public class ProductCreatedConsumer(ILogger<ProductCreatedConsumer> logger) : IConsumer<Product>, IProductCreatedConsumer
{
    public async Task Consume(ConsumeContext<Product> context)
    {
        var product = context.Message;
        if (product == null)
        {
            logger.LogError("Received null product message.");
            return;
        }
        logger.LogInformation($"Product Created: {product.Name} (ID: {product.Id}) - Price: ₹{product.Price}");

        // You can add further logic here, e.g., storing in a database
        await Task.CompletedTask;
    }
}