namespace Microwave.Presentation.DesktopClient.Microwave.Dtos
{
    public class CreateProgramRequest(
        int seconds,
        int power,
        char character,
        string name,
        string food,
        string? instructions)
    {
        public int Seconds { get; } = seconds;
        public int Power { get; } = power;
        public char Character { get; } = character;
        public string Name { get; } = name;
        public string Food { get; } = food;
        public string? Instructions { get; } = instructions;
    }
}
