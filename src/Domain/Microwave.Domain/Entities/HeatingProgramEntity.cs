using Microwave.Domain.SeedWork;

namespace Microwave.Domain.Entities
{
    public class HeatingProgramEntity : EntityBase
    {
        public bool Predefined { get; }
        public int Seconds { get; }
        public int Power { get; }
        public string Name { get; }
        public string Food { get; }
        public char Character { get; }
        public string? Instructions { get; }
    }
}
