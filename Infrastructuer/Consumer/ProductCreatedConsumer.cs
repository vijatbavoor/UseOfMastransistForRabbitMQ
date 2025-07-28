using MassTransit;
using UseOfMastransistForRabbitMQ.Models;

public class ProductCreatedConsumer : IConsumer<Product>, IProductCreatedConsumer
{
    public async Task Consume(ConsumeContext<Product> context)
    {
        var product = context.Message;
        Console.WriteLine($"Product Received: {product.Name} (ID: {product.Id}) - Price: ₹{product.Price}");

        // You can add further logic here, e.g., storing in a database
        await Task.CompletedTask;
    }
}