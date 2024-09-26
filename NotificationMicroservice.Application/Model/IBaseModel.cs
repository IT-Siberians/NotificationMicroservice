namespace NotificationMicroservice.Application.Model
{
    public interface IBaseModel<Tkey> where Tkey : struct
    {
        Tkey Id { get; }
    }
}
