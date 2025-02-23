using Microwave.Application.UseCases.User.Authentication;
using Microwave.Test.IntegrationTest.Commons;

namespace Microwave.Test.IntegrationTest.Application.UseCases.User.Auth
{
    public class AuthenticationHandlerTestFixture : FixtureBase
    {
        public AuthenticationRequest MakeAuthenticationRequest() => new(
            username: Faker.Internet.UserName(),
            password: Faker.Internet.Password());
    }
}
