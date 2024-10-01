namespace NotificationMicroservice.Application.Model.Abstractions
{
    public interface IBaseModel<TKey> where TKey : struct, IEquatable<TKey>
    {
        TKey Id { get; }
    }
}
