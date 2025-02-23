namespace Microwave.Presentation.Client.Models
{
    public class ProgramModel(
        Guid programId,
        bool predefined,
        char character,
        string name,
        string food,
        string? instructions)
    {
        public Guid ProgramId { get; } = programId;
        public bool Predefined { get; } = predefined;
        public char Character { get; } = character;
        public string Name { get; } = name;
        public string Food { get; } = food;
        public string? Instructions { get; } = instructions;
    }
}
