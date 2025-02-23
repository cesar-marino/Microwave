namespace Microwave.Presentation.DesktopClient.Models
{
    public class ProgramModel(
        Guid programId,
        bool predefined,
        int seconds,
        int power,
        char character,
        string name,
        string food,
        string? instructions) : ModelBase(programId)
    {
        public bool Predefined { get; } = predefined;
        public int Seconds { get; } = seconds;
        public int Power { get; } = power;
        public char Character { get; } = character;
        public string Name { get; } = name;
        public string Food { get; } = food;
        public string? Instructions { get; } = instructions;
    }
}
