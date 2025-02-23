namespace Microwave.Presentation.DesktopClient.Models
{
    public abstract class ModelBase(Guid id)
    {
        public Guid Id { get; } = id;
    }
}
