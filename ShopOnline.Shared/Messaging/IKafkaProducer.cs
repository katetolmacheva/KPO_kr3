namespace ShopOnline.Shared.Messaging;

public interface IKafkaProducer
{
    Task PublishAsync(string topic, string key, string value, CancellationToken cancellationToken = default);
}