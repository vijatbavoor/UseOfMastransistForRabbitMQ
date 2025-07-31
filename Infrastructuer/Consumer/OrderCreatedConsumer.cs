using MassTransit;
using UseOfMastransistForRabbitMQ.Models;

public class OrderCreatedConsumer(ILogger<ProductCreatedConsumer> logger) : IConsumer<Product>, IOrderCreatedConsumer
{
    public async Task Consume(ConsumeContext<Product> context)
    {
        var product = context.Message;
        if (product == null)
        {
            logger.LogError("Order received null product message.");
            return;
        }
        logger.LogInformation($"Order for product created: {product.Name} (ID: {product.Id}) - Price: ₹{product.Price}");

        // You can add further logic here, e.g., storing in a database
        await Task.CompletedTask;
    }
}