using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microwave.Domain.Entities;
using Microwave.Infrastructure.Data.Contexts;

namespace Microwave.Test.IntegrationTest.Commons
{
    public abstract class FixtureBase
    {
        public CancellationToken CancellationToken { get; } = default;
        public Faker Faker { get; } = new();

        public MicrowaveContext MakeMicrowaveContext() => new(
            new DbContextOptionsBuilder<MicrowaveContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);

        public IConfiguration MakeConfiguration()
        {
            var myConfiguration = new Dictionary<string, string>
            {
                { "JWT:SecretKey", "Minha@Super#Secreta&Chave*Privada!2024" },
                { "JWT:AccessTokenValidityInMinutes", "1440" },
                { "JWT:ValidIssuer", "localhost:8080" },
                { "JWT:ValidAudience", "localhost:8080" },
                { "JWT:RefreshTokenValidityInMinutes", "10080" },
            };

            return new ConfigurationBuilder()
                .AddInMemoryCollection(initialData: myConfiguration!)
                .Build();
        }

        public HeatingProgramEntity MakeHeatingProgramEntity(bool predefined = false) => new(
            heatingProgramId: Faker.Random.Guid(),
            predefined: predefined,
            seconds: Faker.Random.Int(1, 120),
            power: Faker.Random.Int(1, 10),
            character: Faker.Random.Char(),
            name: Faker.Random.String(),
            food: Faker.Random.String(),
            instructions: Faker.Random.String());

        public UserEntity MakeUserEntity(string? password = null) => new(
            userId: Faker.Random.Guid(),
            username: Faker.Internet.UserName(),
            password: password ?? Faker.Internet.Password(),
            token: Faker.Random.Guid().ToString());

        public MicrowaveServiceEntity MakeMicrowaveServiceEntity(HeatingProgramEntity heatingProgram) => new(heatingProgram);
    }
}
