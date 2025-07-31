using MassTransit;
using UseOfMastransistForRabbitMQ.Models;

public class ProductCreatePublisher(IPublishEndpoint publishEndpoint, ILogger<ProductCreatePublisher> logger) : IProductCreatePublisher
{
    private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;
    private readonly ILogger<ProductCreatePublisher> _logger = logger;

    public async Task PublishProductCreated(Product product)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));

        await _publishEndpoint.Publish(product, context =>
        {
            context.SetRoutingKey("product.created"); // Set the routing key for the published message
        });
        _logger.LogInformation($"Product Published: {product.Name} (ID: {product.Id}) - Price: ₹{product.Price}");
    }
}