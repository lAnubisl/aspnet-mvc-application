namespace DomainService.DomainModels
{
    public interface IDomainObject
    {
        long Id { get; set; }

        bool IsTransient();
    }
}