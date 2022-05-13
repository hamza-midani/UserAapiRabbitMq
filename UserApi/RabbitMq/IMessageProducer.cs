namespace UserApi.RabbitMq
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T Message);
    }
}
