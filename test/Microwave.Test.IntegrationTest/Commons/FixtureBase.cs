using Bogus;

namespace Microwave.Test.IntegrationTest.Commons
{
    public abstract class FixtureBase
    {
        public CancellationToken CancellationToken { get; } = default;
        public Faker Faker { get; } = new();
    }
}
