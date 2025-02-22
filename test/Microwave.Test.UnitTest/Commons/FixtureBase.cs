using Bogus;
using Microwave.Domain.Entities;

namespace Microwave.Test.UnitTest.Commons
{
    public abstract class FixtureBase
    {
        public CancellationToken CancellationToken { get; } = default;
        public Faker Faker { get; } = new("pt_BR");

        public HeatingProgramEntity MakeHeatingProgramEntity(bool predefined = false) => new(
            heatingProgramId: Faker.Random.Guid(),
            predefined: predefined,
            seconds: Faker.Random.Int(1, 120),
            power: Faker.Random.Int(1, 10),
            character: Faker.Random.Char(),
            name: Faker.Random.String(),
            food: Faker.Random.String(),
            instructions: Faker.Random.String());

        public UserEntity MakeUserEntity() => new(
            userId: Faker.Random.Guid(),
            username: Faker.Internet.UserName(),
            password: Faker.Internet.Password(),
            token: Faker.Random.Guid().ToString());
    }
}
