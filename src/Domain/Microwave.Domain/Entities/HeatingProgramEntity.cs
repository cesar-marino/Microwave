using Microwave.Domain.Exceptions;
using Microwave.Domain.SeedWork;

namespace Microwave.Domain.Entities
{
    public class HeatingProgramEntity : EntityBase
	{
		public bool Predefined { get; }
		public int Seconds { get; }
		public int Power { get; }
		public char Character { get; }
		public string Name { get; }
		public string Food { get; }
		public string? Instructions { get; }
		
		public HeatingProgram(int seconds = 30, int power = 10)
		{
			if (seconds > 120 || seconds < 1)
				throw new EntityValidationException("Tempo inválido");
				
			if (power < 1 || power > 10)
				throw new EntityValidationException("Potência inválida");
			
			Seconds = seconds;
			Power = power;
			Character = '.';
			Predefined = false;
			Name = "Default";
			Food = "Default";
		}
		
		public HeatingProgram(
			int seconds, 
			int power, 
			char character, 
			string name, 
			string food, 
			string? instructions)
		{
			Predefined = false;
			Seconds = seconds;
			Power = power;
			Character = character;
			Name = name;
			Food = food;
			Instructions = instructions;
		}
		
		protected HeatingProgram(
			Guid heatingProgramId,
			bool predefined,
			int seconds, 
			int power, 
			char character, 
			string name, 
			string food, 
			string? instructions) : base(heatingProgramId)
		{
			Predefined = predefined;
			Seconds = seconds;
			Power = power;
			Character = character;
			Name = name;
			Food = food;
			Instructions = instructions;
		}
		
		public void Update(
			int seconds,
			int power,
			char character,
			string name,
			string food,
			string? instructions)
		{
			if(Predefined)
				throw new EntityValidationException("Não é permitido a alteração de programas pré-definidos");
				
			Seconds = seconds;
			Power = power;
			Character = character;
			Name = name;
			Food = food;
			Instructions = instructions;
		}
		
		public void AddTime()
		{
			if(Predefined)
				throw new EntityValidationException("Não é permitido acrescentar tempo à programas pré-definidos");
			
			Seconds += 30;
		}
		
		public void DecreaseTime() => Seconds -=1;
	}
}
