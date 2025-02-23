using Microwave.Application.UseCases.User.Authentication;
using Microwave.Test.IntegrationTest.Commons;

namespace Microwave.Test.IntegrationTest.Application.UseCases.User.Auth
{
    public class AuthenticationHandlerTestFixture : FixtureBase
    {
        public AuthenticationRequest MakeAuthenticationRequest(
            string? username = null,
            string? password = null) => new(
                username: username ?? Faker.Internet.UserName(),
                password: password ?? Faker.Internet.Password());
    }
}
