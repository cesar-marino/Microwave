namespace Microwave.Domain.SeedWork
{
    public abstract class EntityBase(Guid? id = null)
    {
        public Guid Id { get; } = id ?? Guid.NewGuid();
    }
}
