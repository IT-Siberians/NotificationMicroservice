namespace NotificationMicroservice.Application.Model.Abstractions
{
    public interface IBaseModel<Tkey> where Tkey : struct
    {
        Tkey Id { get; }
    }
}
